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
    public partial class frmMainMenu : Form
    {
        private Employee currentUser;
        DatabaseHelper db = new DatabaseHelper();
        public frmMainMenu(Employee user)
        {
            InitializeComponent();
            currentUser = user;
            lblUser.Text = "Welcome, " + user.EmployeeName;
            lblRole.Text = "Role: " + user.JobTitle;

            if (user.JobTitle == "Office Manager")
            {
                btnNewCall.Enabled = false;
                btnBackup.Enabled = false;
                btnRestore.Enabled = false;
                btnCompact.Enabled = false;
            }
            if (user.JobTitle == "Helpdesk Operator")
            {
                btnReports.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                db.LogAudit(currentUser.EmployeeID, "LOGOUT", "User logged out.");
            }
            this.Close();
            Application.Restart();
        }

        private void btnNewCall_Click(object sender, EventArgs e)
        {
            frmNewCall frm = new frmNewCall(currentUser);
            frm.ShowDialog();
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeManagement frm = new frmEmployeeManagement();
            frm.ShowDialog();
        }

        private void btnSearchEquipment_Click(object sender, EventArgs e)
        {
            frmEquipmentManagement frm = new frmEquipmentManagement();
            frm.ShowDialog();
        }

        private void btnAssignTechnician_Click(object sender, EventArgs e)
        {
            frmTechnicianAssignment frm = new frmTechnicianAssignment();
            frm.ShowDialog();
        }

        private void btnResolveProblem_Click(object sender, EventArgs e)
        {
            frmProblemResolution frm = new frmProblemResolution();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // Backup Folder ကို C:\Backup ဆိုပြီး သတ်မှတ်မယ်
            string backupFolder = @"C:\BACKUP";

            
            if (!System.IO.Directory.Exists(backupFolder))
            {
                System.IO.Directory.CreateDirectory(backupFolder);
            }

            
            string fileName = $"MLHelpdesk_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string fullPath = System.IO.Path.Combine(backupFolder, fileName);

            string errorMsg;
            if (db.BackupDatabase(fullPath, out errorMsg))
            {
                MessageBox.Show($"Database backup completed successfully!\nSaved to: {fullPath}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Backup Failed!\n\nError Details:\n{errorMsg}",
                    "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup Files (*.bak)|*.bak";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Overwrite database?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string errorMsg;
                    if (db.RestoreDatabase(ofd.FileName, out errorMsg))  
                    {
                        MessageBox.Show($"Restore successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Restore failed!\n\nError Details:\n{errorMsg}", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCompact_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will shrink the database file (Compact). Are you sure?",
       "Confirm Compact", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string errorMsg;
                if (db.CompactDatabase(out errorMsg))
                {
                    MessageBox.Show("Database compacted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Compact failed.\n\nError Details:\n{errorMsg}",
                        "Compact Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            frmEmployeeManagement frm = new frmEmployeeManagement();
            frm.ShowDialog();
        }

        private void btnManageEquipment_Click(object sender, EventArgs e)
        {
            frmEquipmentManagement frm = new frmEquipmentManagement();
            frm.ShowDialog();
        }
    }
}
