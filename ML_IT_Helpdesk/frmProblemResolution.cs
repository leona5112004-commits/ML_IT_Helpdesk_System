using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ML_IT_Helpdesk.Data;
using System.Windows.Forms;

namespace ML_IT_Helpdesk
{
    public partial class frmProblemResolution : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int selectedProblem=0;
        public frmProblemResolution()
        {
            InitializeComponent();
            LoadAssignedProblems();
        }
        private void LoadAssignedProblems()
        {
            try
            {
                string query = @"
                    SELECT hp.ProblemNumber, e.EmployeeName, t.TechnicianName, hp.ProblemType, hp.Status 
                    FROM HelpdeskProblem hp
                    INNER JOIN Employee e ON hp.EmployeeID = e.EmployeeID
                    INNER JOIN Technician t ON hp.TechnicianID = t.TechnicianID
                    WHERE hp.Status = 'In Progress'
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
                }
                else
                {
                    cmbProblem.Text = "No in-progress problems found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading problems: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (cmbProblem.DataSource == null)
                {
                    ClearFields();
                    return;
                }

                
                if (cmbProblem.SelectedValue == null || cmbProblem.SelectedValue == DBNull.Value)
                {
                    ClearFields();
                    return;
                }

                
                if (!int.TryParse(cmbProblem.SelectedValue.ToString(), out selectedProblem))
                {
                    ClearFields();
                    return;
                }

                if (selectedProblem == 0)
                {
                    ClearFields();
                    return;
                }

                
                string query = $@"
                    SELECT e.EmployeeName, t.TechnicianName, hp.ProblemType, hp.Reason, 
                           hp.ProblemDescription, hp.CallDateTime, hp.Status
                    FROM HelpdeskProblem hp
                    INNER JOIN Employee e ON hp.EmployeeID = e.EmployeeID
                    INNER JOIN Technician t ON hp.TechnicianID = t.TechnicianID
                    WHERE hp.ProblemNumber = {selectedProblem}";

                DataTable dt = db.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    txtEmployee.Text = dt.Rows[0]["EmployeeName"].ToString();
                    txtTechnician.Text = dt.Rows[0]["TechnicianName"].ToString();
                    txtProblemType.Text = dt.Rows[0]["ProblemType"].ToString();
                    txtReason.Text = dt.Rows[0]["Reason"].ToString();
                    txtDescription.Text = dt.Rows[0]["ProblemDescription"]?.ToString() ?? "";
                    txtCallDateTime.Text = Convert.ToDateTime(dt.Rows[0]["CallDateTime"]).ToString("yyyy-MM-dd HH:mm");
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();
                }
                else
                {
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading problem details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtEmployee.Text = "";
            txtTechnician.Text = "";
            txtProblemType.Text = "";
            txtReason.Text = "";
            txtDescription.Text = "";
            txtCallDateTime.Text = "";
            txtStatus.Text = "";
            txtResolutionDescription.Text = "";
            txtResolutionHours.Text = "";
            selectedProblem = 0;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            if (selectedProblem == 0)
            {
                MessageBox.Show("Please select a problem first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtResolutionDescription.Text))
            {
                MessageBox.Show("Please enter resolution description.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtResolutionHours.Text))
            {
                MessageBox.Show("Please enter resolution hours.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtResolutionHours.Text, out decimal hours) || hours < 0)
            {
                MessageBox.Show("Please enter a valid positive number for hours.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    UPDATE HelpdeskProblem 
                    SET Status = 'Closed', 
                        ResolutionDateTime = GETDATE(), 
                        ResolutionDescription = @Desc, 
                        ResolutionHours = @Hrs
                    WHERE ProblemNumber = @P";

                SqlParameter[] p = {
                    new SqlParameter("@Desc", txtResolutionDescription.Text),
                    new SqlParameter("@Hrs", hours),
                    new SqlParameter("@P", selectedProblem)
                };
                db.ExecuteNonQuery(query, p);

                MessageBox.Show($"Problem #{selectedProblem} resolved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh
                LoadAssignedProblems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resolving problem: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
