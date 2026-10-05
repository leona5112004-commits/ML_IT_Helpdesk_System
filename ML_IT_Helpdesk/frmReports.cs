using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML_IT_Helpdesk.Data;

namespace ML_IT_Helpdesk
{
    public partial class frmReports : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public frmReports()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            // Monthly Summary
            DataTable dt1 = db.GetMonthlyCallSummary(DateTime.Now.Year, DateTime.Now.Month);
            dgvMonthlySummary.DataSource = dt1;

            // Technician Report
            DataTable dt2 = db.GetTechnicianWorkload();
            dgvTechnicianReport.DataSource = dt2;

            // Office Report
            string query3 = @"
                SELECT o.OfficeName, COUNT(hp.ProblemNumber) AS TotalJobs,
                       SUM(CASE WHEN hp.ProblemType = 'Hardware' THEN 1 ELSE 0 END) AS HardwareFaults,
                       SUM(CASE WHEN hp.ProblemType = 'Software' THEN 1 ELSE 0 END) AS SoftwareFaults,
                       ISNULL(SUM(hp.ResolutionHours), 0) AS TotalTime
                FROM Office o
                LEFT JOIN Employee e ON o.OfficeID = e.OfficeID
                LEFT JOIN HelpdeskProblem hp ON e.EmployeeID = hp.EmployeeID
                GROUP BY o.OfficeName";
            DataTable dt3 = db.ExecuteQuery(query3);
            dgvOfficeReport.DataSource = dt3;

            // Equipment Report
            DataTable dt4 = db.GetEquipmentReport();
            dgvEquipmentReport.DataSource = dt4;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
            MessageBox.Show("Reports refreshed!");
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // Simple export functionality
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataGridView grid = GetCurrentGrid();
                    if (grid != null && grid.DataSource != null)
                    {
                        ExportToCsv(grid, sfd.FileName);
                    }
                }
            }
        }

        private DataGridView GetCurrentGrid()
        {
            if (tabReports.SelectedTab == tabMonthlySummary)
                return dgvMonthlySummary;
            else if (tabReports.SelectedTab == tabTechnician)
                return dgvTechnicianReport;
            else if (tabReports.SelectedTab == tabOffice)
                return dgvOfficeReport;
            else if (tabReports.SelectedTab == tabEquipment)
                return dgvEquipmentReport;
            else
                return null;
        }
        private void ExportToCsv(DataGridView dgv, string filePath)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                // Headers
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        sb.Append(dgv.Columns[i].HeaderText);
                        if (i < dgv.Columns.Count - 1) sb.Append(",");
                    }
                }
                sb.AppendLine();

                // Data
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            sb.Append(row.Cells[i].Value?.ToString() ?? "");
                            if (i < dgv.Columns.Count - 1) sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                }
                System.IO.File.WriteAllText(filePath, sb.ToString());
                MessageBox.Show($"Exported to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export error: {ex.Message}");
            }
        }
    }
}
