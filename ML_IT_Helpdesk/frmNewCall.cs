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
using ML_IT_Helpdesk.Models;

namespace ML_IT_Helpdesk
{
    public partial class frmNewCall : Form
    {
        private Employee currentOperator;
        
        private DatabaseHelper db;               // Database Helper
        private DataTable employees;             // Employee List 
        private DataTable equipment;
        public frmNewCall(Employee operatorUser)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            currentOperator = operatorUser;
            lblOperator.Text = "Operator: " + operatorUser.EmployeeName;
            txtCallDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");


            LoadEmployees();
            LoadEquipment();
            LoadProblemTypes();
           
        }

        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT EmployeeID, EmployeeName, JobTitle, Department, OfficeID FROM Employee WHERE EmploymentEndDate IS NULL";
                employees = db.ExecuteQuery(query);

                if (employees.Rows.Count == 0)
                {
                    MessageBox.Show("No employees found in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "EmployeeName";
                cmbEmployee.ValueMember = "EmployeeID";

                
                // MessageBox.Show($"Employees loaded: {employees.Rows.Count} rows");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEquipment()
        {
            try
            {
                string query = "SELECT EquipmentID, SerialNumber FROM Equipment";
                equipment = db.ExecuteQuery(query);

                if (equipment.Rows.Count == 0)
                {
                    MessageBox.Show("No equipment found in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbEquipment.DataSource = equipment;
                cmbEquipment.DisplayMember = "SerialNumber";
                cmbEquipment.ValueMember = "EquipmentID";

                // Debug
                 MessageBox.Show($"Equipment loaded: {equipment.Rows.Count} rows");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProblemTypes()
        {
            cmbProblemType.Items.Clear();
            cmbProblemType.Items.AddRange(new string[] { "Hardware", "Software", "Network", "Other" });
        }


       

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cmbProblemType.Text))
            {
                MessageBox.Show("Please select a problem type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtProblemDescription.Text))
            {
                MessageBox.Show("Please enter a problem description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    INSERT INTO HelpdeskProblem (
                        EmployeeID, OperatorID, EquipmentID, ProblemType, 
                        CallDateTime, Reason, ProblemDescription, Status
                    ) VALUES (
                        @Emp, @Op, @Eq, @Type, 
                        @Date, @Reason, @Desc, 'Open'
                    );
                    SELECT SCOPE_IDENTITY();";

                SqlParameter[] p = {
                    new SqlParameter("@Emp", cmbEmployee.SelectedValue),
                    new SqlParameter("@Op", currentOperator.EmployeeID),
                    new SqlParameter("@Eq", cmbEquipment.SelectedValue ?? DBNull.Value),
                    new SqlParameter("@Type", cmbProblemType.Text),
                    new SqlParameter("@Date", DateTime.Now),
                    new SqlParameter("@Reason", txtReason.Text),
                    new SqlParameter("@Desc", txtProblemDescription.Text)
                };

                object result = db.ExecuteScalar(query, p);
                if (result != null)
                {
                    MessageBox.Show($"Call logged successfully!\nProblem Number: {result}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving problem: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbProblemType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue != null && cmbEmployee.SelectedValue is int)
            {
                int id = (int)cmbEmployee.SelectedValue;
                DataRow[] rows = employees.Select($"EmployeeID = {id}");
                if (rows.Length > 0)
                {
                    txtJobTitle.Text = rows[0]["JobTitle"].ToString();
                    txtDepartment.Text = rows[0]["Department"].ToString();

                    int officeId = Convert.ToInt32(rows[0]["OfficeID"]);
                    try
                    {
                        DataTable office = db.ExecuteQuery($"SELECT OfficeName FROM Office WHERE OfficeID = {officeId}");
                        if (office.Rows.Count > 0)
                        {
                            txtOffice.Text = office.Rows[0]["OfficeName"].ToString();
                        }
                        else
                        {
                            txtOffice.Text = "Unknown Office";
                        }
                    }
                    catch (Exception ex)
                    {
                        txtOffice.Text = "Error loading office";
                        MessageBox.Show($"Error loading office: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
