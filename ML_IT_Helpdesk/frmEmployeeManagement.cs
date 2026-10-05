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
using System.Data.SqlClient;



namespace ML_IT_Helpdesk
{
    
    public partial class frmEmployeeManagement : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private int selectedEmployeeID = 0; // 0 = New Mode, >0 = Edit Mode
        private DataTable employees; // For DataGridView binding

        public frmEmployeeManagement()
        {
            InitializeComponent();
            LoadEmployees();
            LoadOffices();            
            ClearFields();
            btnDelete.Enabled = false;
        }

        private void LoadOffices()
        {
            string query = "SELECT OfficeID, OfficeName FROM Office";
            DataTable dt = db.ExecuteQuery(query);
            cmbOffice.DataSource = dt;
            cmbOffice.DisplayMember = "OfficeName";
            cmbOffice.ValueMember = "OfficeID";
        }

        private void ClearFields()
        {
            selectedEmployeeID = 0;
            txtEmployeeCode.Clear();
            txtEmployeeName.Clear();
            txtContactPhone.Clear();
            txtEmail.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();
            if (cmbOffice.Items.Count > 0) cmbOffice.SelectedIndex = 0;
            btnDelete.Enabled = false;
            btnSave.Text = "💾 Save";
        }

        private void LoadEmployees()
        {
            string query = @"
                SELECT e.EmployeeID, e.EmployeeCode, e.EmployeeName, e.ContactPhone, 
                       e.Email, e.JobTitle, e.Department, o.OfficeName
                FROM Employee e
                INNER JOIN Office o ON e.OfficeID = o.OfficeID
                WHERE e.EmploymentEndDate IS NULL
                ORDER BY e.EmployeeName";
            employees = db.ExecuteQuery(query);
            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns["EmployeeID"].Visible = false;
            dgvEmployees.Columns["EmployeeCode"].HeaderText = "Code";
            dgvEmployees.Columns["EmployeeName"].HeaderText = "Name";
            dgvEmployees.Columns["ContactPhone"].HeaderText = "Phone";
            dgvEmployees.Columns["Email"].HeaderText = "Email";
            dgvEmployees.Columns["JobTitle"].HeaderText = "Title";
            dgvEmployees.Columns["Department"].HeaderText = "Dept";
            dgvEmployees.Columns["OfficeName"].HeaderText = "Office";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            string query = $@"
                SELECT EmployeeCode, EmployeeName, JobTitle, Department 
                FROM Employee 
                WHERE EmploymentEndDate IS NULL 
                AND (EmployeeName LIKE '%{filter}%' OR Department LIKE '%{filter}%')";
            DataTable dt = db.ExecuteQuery(query);
            dgvEmployees.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            string query = $@"
                SELECT e.EmployeeID, e.EmployeeCode, e.EmployeeName, e.ContactPhone, 
                       e.Email, e.JobTitle, e.Department, o.OfficeName
                FROM Employee e
                INNER JOIN Office o ON e.OfficeID = o.OfficeID
                WHERE e.EmploymentEndDate IS NULL 
                AND (e.EmployeeName LIKE '%{filter}%' OR e.Department LIKE '%{filter}%' OR e.EmployeeCode LIKE '%{filter}%')
                ORDER BY e.EmployeeName";
            employees = db.ExecuteQuery(query);
            dgvEmployees.DataSource = employees;
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                selectedEmployeeID = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                txtEmployeeCode.Text = row.Cells["EmployeeCode"].Value.ToString();
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
                txtContactPhone.Text = row.Cells["ContactPhone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                cmbOffice.Text = row.Cells["OfficeName"].Value.ToString();

                btnDelete.Enabled = true;
                btnSave.Text = "💾 Update"; // Update Mode
                btnAddNew.Enabled = true;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtEmployeeCode.ReadOnly = false; 
            txtEmployeeCode.Focus();
            btnSave.Text = "💾 Save New";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeCode.Text) || string.IsNullOrEmpty(txtEmployeeName.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Code, Name, and Email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedEmployeeID == 0) // ⭐ INSERT (New Employee)
                {
                    string query = @"
                        INSERT INTO Employee (EmployeeCode, EmployeeName, ContactPhone, Email, EmploymentStartDate, JobTitle, Department, OfficeID, Password)
                        VALUES (@Code, @Name, @Phone, @Email, @StartDate, @Title, @Dept, @OfficeID, @Password)";

                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@Code", txtEmployeeCode.Text),
                        new SqlParameter("@Name", txtEmployeeName.Text),
                        new SqlParameter("@Phone", (object)txtContactPhone.Text ?? DBNull.Value),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@StartDate", DateTime.Now), // ဒီနေ့နဲ့စပါစို့
                        new SqlParameter("@Title", txtJobTitle.Text),
                        new SqlParameter("@Dept", txtDepartment.Text),
                        new SqlParameter("@OfficeID", cmbOffice.SelectedValue),
                        new SqlParameter("@Password", "password123") // Default Password
                    };
                    db.ExecuteNonQuery(query, p);
                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // ⭐ UPDATE (Edit Employee)
                {
                    string query = @"
                        UPDATE Employee 
                        SET EmployeeName = @Name, ContactPhone = @Phone, Email = @Email, 
                            JobTitle = @Title, Department = @Dept, OfficeID = @OfficeID
                        WHERE EmployeeID = @ID";

                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@Name", txtEmployeeName.Text),
                        new SqlParameter("@Phone", (object)txtContactPhone.Text ?? DBNull.Value),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Title", txtJobTitle.Text),
                        new SqlParameter("@Dept", txtDepartment.Text),
                        new SqlParameter("@OfficeID", cmbOffice.SelectedValue),
                        new SqlParameter("@ID", selectedEmployeeID)
                    };
                    db.ExecuteNonQuery(query, p);
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadEmployees(); // Refresh DataGridView
                ClearFields();
            }
            catch (SqlException ex) // Handle unique constraint violation (Code already exists)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    MessageBox.Show("Employee Code already exists. Please use a different Code.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == 0) return;

            // Confirm Delete
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete employee '{txtEmployeeName.Text}'?\nThis action cannot be undone!",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    
                    string query = "UPDATE Employee SET EmploymentEndDate = GETDATE() WHERE EmployeeID = @ID";
                    db.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@ID", selectedEmployeeID) });

                    MessageBox.Show("Employee marked as inactive (Soft Delete).", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees(); // Refresh
                    ClearFields();
                }
                catch (SqlException ex)
                {
                    
                    if (ex.Number == 547) // Foreign key constraint error
                    {
                        MessageBox.Show("Cannot delete this employee because they have associated Helpdesk Calls. Please archive or reassign first.",
                            "Referential Integrity Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Delete Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
