
namespace ML_IT_Helpdesk
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnNewCall = new System.Windows.Forms.Button();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.btnSearchEquipment = new System.Windows.Forms.Button();
            this.btnAssignTechnician = new System.Windows.Forms.Button();
            this.btnResolveProblem = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnCompact = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnManageEquipment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Red;
            this.lblUser.Location = new System.Drawing.Point(313, 71);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(549, 55);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Welcome,[Name]";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("PMingLiU-ExtB", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(122, 167);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(263, 38);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: [JobTitle]";
            // 
            // btnNewCall
            // 
            this.btnNewCall.Location = new System.Drawing.Point(58, 278);
            this.btnNewCall.Name = "btnNewCall";
            this.btnNewCall.Size = new System.Drawing.Size(97, 29);
            this.btnNewCall.TabIndex = 2;
            this.btnNewCall.Text = "📞 New Helpdesk Call";
            this.btnNewCall.UseVisualStyleBackColor = true;
            this.btnNewCall.Click += new System.EventHandler(this.btnNewCall_Click);
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Location = new System.Drawing.Point(166, 278);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(116, 29);
            this.btnSearchEmployee.TabIndex = 3;
            this.btnSearchEmployee.Text = "🔍 Search Employee";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // btnSearchEquipment
            // 
            this.btnSearchEquipment.Location = new System.Drawing.Point(437, 281);
            this.btnSearchEquipment.Name = "btnSearchEquipment";
            this.btnSearchEquipment.Size = new System.Drawing.Size(141, 29);
            this.btnSearchEquipment.TabIndex = 4;
            this.btnSearchEquipment.Text = "🖥️ Search Equipment";
            this.btnSearchEquipment.UseVisualStyleBackColor = true;
            this.btnSearchEquipment.Click += new System.EventHandler(this.btnSearchEquipment_Click);
            // 
            // btnAssignTechnician
            // 
            this.btnAssignTechnician.Location = new System.Drawing.Point(725, 276);
            this.btnAssignTechnician.Name = "btnAssignTechnician";
            this.btnAssignTechnician.Size = new System.Drawing.Size(124, 29);
            this.btnAssignTechnician.TabIndex = 5;
            this.btnAssignTechnician.Text = "🔧 Assign Technician\t";
            this.btnAssignTechnician.UseVisualStyleBackColor = true;
            this.btnAssignTechnician.Click += new System.EventHandler(this.btnAssignTechnician_Click);
            // 
            // btnResolveProblem
            // 
            this.btnResolveProblem.Location = new System.Drawing.Point(855, 278);
            this.btnResolveProblem.Name = "btnResolveProblem";
            this.btnResolveProblem.Size = new System.Drawing.Size(118, 29);
            this.btnResolveProblem.TabIndex = 6;
            this.btnResolveProblem.Text = "✅ Resolve Problem";
            this.btnResolveProblem.UseVisualStyleBackColor = true;
            this.btnResolveProblem.Click += new System.EventHandler(this.btnResolveProblem_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(58, 334);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(147, 32);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "📊 Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(211, 334);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(147, 32);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "💾 Backup DB";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(373, 334);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(143, 32);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "🔄 Restore DB";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCompact
            // 
            this.btnCompact.Location = new System.Drawing.Point(532, 334);
            this.btnCompact.Name = "btnCompact";
            this.btnCompact.Size = new System.Drawing.Size(125, 32);
            this.btnCompact.TabIndex = 10;
            this.btnCompact.Text = "📦 Compact DB";
            this.btnCompact.UseVisualStyleBackColor = true;
            this.btnCompact.Click += new System.EventHandler(this.btnCompact_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(938, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 33);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.Location = new System.Drawing.Point(303, 279);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(127, 26);
            this.btnManageEmployees.TabIndex = 12;
            this.btnManageEmployees.Text = "👥 Manage Employees\t";
            this.btnManageEmployees.UseVisualStyleBackColor = true;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnManageEquipment
            // 
            this.btnManageEquipment.Location = new System.Drawing.Point(584, 281);
            this.btnManageEquipment.Name = "btnManageEquipment";
            this.btnManageEquipment.Size = new System.Drawing.Size(135, 28);
            this.btnManageEquipment.TabIndex = 13;
            this.btnManageEquipment.Text = "🖥️ Manage Equipment";
            this.btnManageEquipment.UseVisualStyleBackColor = true;
            this.btnManageEquipment.Click += new System.EventHandler(this.btnManageEquipment_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 505);
            this.Controls.Add(this.btnManageEquipment);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCompact);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnResolveProblem);
            this.Controls.Add(this.btnAssignTechnician);
            this.Controls.Add(this.btnSearchEquipment);
            this.Controls.Add(this.btnSearchEmployee);
            this.Controls.Add(this.btnNewCall);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblUser);
            this.Name = "frmMainMenu";
            this.Text = "frmMainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnNewCall;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.Button btnSearchEquipment;
        private System.Windows.Forms.Button btnAssignTechnician;
        private System.Windows.Forms.Button btnResolveProblem;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnCompact;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnManageEquipment;
    }
}