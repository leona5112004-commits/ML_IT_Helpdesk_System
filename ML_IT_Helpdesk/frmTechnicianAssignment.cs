using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ML_IT_Helpdesk.Data;

namespace ML_IT_Helpdesk
{
    public partial class frmTechnicianAssignment : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int selectedProblem;

        public frmTechnicianAssignment()
        {
            InitializeComponent();
            LoadOpenProblems();
            LoadSkills();
        }
        private void LoadOpenProblems()
        {
            try
            {
                string query = @"
                    SELECT hp.ProblemNumber, e.EmployeeName, hp.ProblemType, hp.Reason, hp.Status 
                    FROM HelpdeskProblem hp
                    INNER JOIN Employee e ON hp.EmployeeID = e.EmployeeID
                    WHERE hp.Status IN ('Open', 'In Progress') AND hp.TechnicianID IS NULL
                    ORDER BY hp.CallDateTime DESC";

                DataTable dt = db.ExecuteQuery(query);

                
                cmbProblem.DataSource = null;  
                cmbProblem.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    cmbProblem.DataSource = dt;
                    cmbProblem.DisplayMember = "ProblemNumber";
                    cmbProblem.ValueMember = "ProblemNumber";
                    cmbProblem.DropDownStyle = ComboBoxStyle.DropDownList;

                    
                    Console.WriteLine($"Loaded {dt.Rows.Count} problems");
                }
                else
                {
                    cmbProblem.Text = "No open problems found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading problems: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSkills()
        {
            try
            {
                
                string query = "SELECT SkillID, SkillName FROM Skill ORDER BY SkillName";
                DataTable dt = db.ExecuteQuery(query);

                cmbSkill.DataSource = null;
                cmbSkill.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    cmbSkill.DataSource = dt;
                    cmbSkill.DisplayMember = "SkillName";    
                    cmbSkill.ValueMember = "SkillID";        
                    cmbSkill.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    cmbSkill.Text = "No skills found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading skills: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
               
                if (cmbProblem.DataSource == null)
                {
                    ClearDetails();
                    return;
                }

                
                if (cmbProblem.SelectedValue == null || cmbProblem.SelectedValue == DBNull.Value)
                {
                    ClearDetails();
                    return;
                }

                
                if (!int.TryParse(cmbProblem.SelectedValue.ToString(), out selectedProblem))
                {
                    ClearDetails();
                    return;
                }

                if (selectedProblem == 0)
                {
                    ClearDetails();
                    return;
                }

                
                string query = $@"
                    SELECT hp.ProblemType, e.EmployeeName, e.Department, hp.Reason, hp.ProblemDescription, hp.Status 
                    FROM HelpdeskProblem hp
                    INNER JOIN Employee e ON hp.EmployeeID = e.EmployeeID
                    WHERE hp.ProblemNumber = {selectedProblem}";

                DataTable dt = db.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    txtProblemType.Text = dt.Rows[0]["ProblemType"].ToString();
                    txtCaller.Text = dt.Rows[0]["EmployeeName"].ToString();
                    txtDepartment.Text = dt.Rows[0]["Department"].ToString();
                    txtReason.Text = dt.Rows[0]["Reason"].ToString();
                    txtDescription.Text = dt.Rows[0]["ProblemDescription"].ToString();
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();
                }
                else
                {
                    ClearDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading problem details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearDetails();
            }
        }
     

        private void btnFindTechnicians_Click(object sender, EventArgs e)
        {
            if (cmbSkill.SelectedValue == null || cmbSkill.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a skill.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int skillId = Convert.ToInt32(cmbSkill.SelectedValue);

            try
            {
               
                string query = @"
            SELECT t.TechnicianID, t.TechnicianName, t.Email, ts.SkillLevel,
                   COUNT(hp.ProblemNumber) AS CurrentJobs
            FROM Technician t
            INNER JOIN TechnicianSkill ts ON t.TechnicianID = ts.TechnicianID
            LEFT JOIN HelpdeskProblem hp ON t.TechnicianID = hp.TechnicianID 
                AND hp.Status IN ('Open', 'In Progress')
            WHERE t.Status = 'Active' AND ts.SkillID = @SkillID
            GROUP BY t.TechnicianID, t.TechnicianName, t.Email, ts.SkillLevel
            ORDER BY CurrentJobs ASC, SkillLevel DESC";

                SqlParameter[] p = { new SqlParameter("@SkillID", skillId) };
                DataTable dt = db.ExecuteQuery(query, p);

                dgvTechnicians.DataSource = dt;
                dgvTechnicians.Columns["TechnicianID"].Visible = false;
                dgvTechnicians.Columns["TechnicianName"].HeaderText = "Technician";
                dgvTechnicians.Columns["Email"].HeaderText = "Email";
                dgvTechnicians.Columns["SkillLevel"].HeaderText = "Skill Level";
                dgvTechnicians.Columns["CurrentJobs"].HeaderText = "Current Jobs";
                dgvTechnicians.AutoResizeColumns();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No technicians found with this skill.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding technicians: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (selectedProblem == 0)
            {
                MessageBox.Show("Please select a problem first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvTechnicians.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a technician from the list.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int technicianId = Convert.ToInt32(dgvTechnicians.SelectedRows[0].Cells["TechnicianID"].Value);

                string query = "UPDATE HelpdeskProblem SET TechnicianID = @T, Status = 'In Progress' WHERE ProblemNumber = @P";
                SqlParameter[] p = {
                    new SqlParameter("@T", technicianId),
                    new SqlParameter("@P", selectedProblem)
                };
                db.ExecuteNonQuery(query, p);

                MessageBox.Show($"Technician assigned successfully to Problem #{selectedProblem}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh
                LoadOpenProblems();
                dgvTechnicians.DataSource = null;
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning technician: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetails()
        {
            txtProblemType.Text = "";
            txtCaller.Text = "";
            txtDepartment.Text = "";
            txtReason.Text = "";
            txtDescription.Text = "";
            txtStatus.Text = "";
            selectedProblem = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
