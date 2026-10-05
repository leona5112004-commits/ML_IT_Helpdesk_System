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
using ML_IT_Helpdesk.Models;
using System.Data.SqlClient;

namespace ML_IT_Helpdesk
{
    public partial class frmLogin : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string findQuery = "SELECT EmployeeID, EmployeeName, JobTitle, Department, OfficeID, Password FROM Employee WHERE EmployeeCode = @Username";
            DataTable dt = db.ExecuteQuery(findQuery, new SqlParameter[] { new SqlParameter("@Username", username) });

            if (dt.Rows.Count == 0)
            {
                
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                db.LogAudit(null, "LOGIN_FAILED", $"Username '{username}' not found.");
                return;
            }

            DataRow row = dt.Rows[0];
            int empId = Convert.ToInt32(row["EmployeeID"]);
            string storedPassword = row["Password"].ToString();

            
            if (password == storedPassword) 
            {
                
                db.LogAudit(empId, "LOGIN_SUCCESS", "User logged in successfully.");

                Employee user = new Employee()
                {
                    EmployeeID = empId,
                    EmployeeName = row["EmployeeName"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    Department = row["Department"].ToString(),
                    OfficeID = Convert.ToInt32(row["OfficeID"])
                };

                this.Hide();
                frmMainMenu main = new frmMainMenu(user);
                main.ShowDialog();
                this.Close();
            }
            else
            {
                
                db.LogAudit(empId, "LOGIN_FAILED", $"Invalid password attempt for user '{username}'.");

                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

     }
 }
