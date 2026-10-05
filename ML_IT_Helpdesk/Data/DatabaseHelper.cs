using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ML_IT_Helpdesk.Data
{
    class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ML_IT_HelpdeskDB"].ConnectionString;
        }

        // SELECT queries
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rows = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return rows;
        }

        // Get single value (e.g., new ID)
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        // Backup
        public bool BackupDatabase(string backupPath, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string directory = System.IO.Path.GetDirectoryName(backupPath);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                string dbName = "ML_IT_HelpdeskDB";
              
                string query = $@"
            USE master;
            BACKUP DATABASE [{dbName}] 
            TO DISK = '{backupPath}' 
            WITH INIT, FORMAT, STATS = 10;";

                ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // Restore
        public bool RestoreDatabase(string backupPath, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string dbName = "MLHelpdeskDB";
                string query = $@"
            USE master;
            ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [{dbName}] 
            FROM DISK = '{backupPath}' 
            WITH REPLACE, STATS = 10;
            ALTER DATABASE [{dbName}] SET MULTI_USER;";

                ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // Compact
        public bool CompactDatabase(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string dbName = "ML_IT_HelpdeskDB";
                string query = $@"
            USE [{dbName}];
            DBCC SHRINKDATABASE([{dbName}]);";

                ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // ---- Reports / Helpers ----

        public DataTable GetTechnicianWorkload()
        {
            string query = @"
                SELECT 
                    t.TechnicianID, t.TechnicianName,
                    COUNT(hp.ProblemNumber) AS TotalJobs,
                    SUM(CASE WHEN hp.Status IN ('Open','In Progress') THEN 1 ELSE 0 END) AS OpenJobs,
                    SUM(CASE WHEN hp.Status = 'Closed' THEN 1 ELSE 0 END) AS ClosedJobs,
                    ISNULL(SUM(hp.ResolutionHours), 0) AS TotalHours
                FROM Technician t
                LEFT JOIN HelpdeskProblem hp ON t.TechnicianID = hp.TechnicianID
                WHERE t.Status = 'Active'
                GROUP BY t.TechnicianID, t.TechnicianName";
            return ExecuteQuery(query);
        }

        public DataTable GetTechniciansBySkill(string skillName)
        {
            string query = @"
                SELECT t.TechnicianID, t.TechnicianName, t.Email, ts.SkillLevel,
                       COUNT(hp.ProblemNumber) AS CurrentJobs
                FROM Technician t
                INNER JOIN TechnicianSkill ts ON t.TechnicianID = ts.TechnicianID
                LEFT JOIN HelpdeskProblem hp ON t.TechnicianID = hp.TechnicianID 
                    AND hp.Status IN ('Open','In Progress')
                WHERE t.Status = 'Active' AND ts.SkillName = @SkillName
                GROUP BY t.TechnicianID, t.TechnicianName, t.Email, ts.SkillLevel
                ORDER BY CurrentJobs ASC, SkillLevel DESC";
            return ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@SkillName", skillName) });
        }

        public DataTable GetMonthlyCallSummary(int year, int month)
        {
            string query = @"
                SELECT 
                    DATEPART(MONTH, CallDateTime) AS Month,
                    COUNT(*) AS TotalCalls,
                    SUM(CASE WHEN Status = 'Open' THEN 1 ELSE 0 END) AS OpenCases,
                    SUM(CASE WHEN Status = 'Closed' THEN 1 ELSE 0 END) AS ClosedCases,
                    ISNULL(SUM(ResolutionHours), 0) AS TotalTimeSpent
                FROM HelpdeskProblem
                WHERE YEAR(CallDateTime) = @Year AND MONTH(CallDateTime) = @Month
                GROUP BY DATEPART(MONTH, CallDateTime)";
            return ExecuteQuery(query, new SqlParameter[] {
                new SqlParameter("@Year", year),
                new SqlParameter("@Month", month)
            });
        }

        public DataTable GetEquipmentReport()
        {
            string query = @"
                SELECT 
                    e.SerialNumber, e.EquipmentType, e.Manufacturer, e.Make, e.Model,
                    COUNT(hp.ProblemNumber) AS NumberOfJobs,
                    e.WarrantyStartDate, e.WarrantyEndDate, e.WarrantyStatus
                FROM Equipment e
                LEFT JOIN HelpdeskProblem hp ON e.EquipmentID = hp.EquipmentID
                GROUP BY e.SerialNumber, e.EquipmentType, e.Manufacturer, e.Make, e.Model,
                         e.WarrantyStartDate, e.WarrantyEndDate, e.WarrantyStatus
                ORDER BY COUNT(hp.ProblemNumber) DESC";
            return ExecuteQuery(query);
        }


        public void LogAudit(int? employeeId, string actionType, string details = null)
        {
            try
            {
                string query = @"
            INSERT INTO AuditLog (EmployeeID, ActionType, IPAddress, Details)
            VALUES (@EmpID, @Action, @IP, @Details)";

                // get Local IP Address  (Optional - for security)
                string ipAddress = "LocalHost";
                try
                {
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ip.ToString();
                            break;
                        }
                    }
                }
                catch { /* If not get IP, set LocalHost  */ }

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@EmpID", (object)employeeId ?? DBNull.Value),
            new SqlParameter("@Action", actionType),
            new SqlParameter("@IP", ipAddress),
            new SqlParameter("@Details", (object)details ?? DBNull.Value)
                };

                ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show($"Audit Log Error: {ex.Message}");
            }
        }
    }
}
