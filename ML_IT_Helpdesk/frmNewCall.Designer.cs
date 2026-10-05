
namespace ML_IT_Helpdesk
{
    partial class frmNewCall
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
            this.gbCaller = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.gbEquipment = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEquipment = new System.Windows.Forms.ComboBox();
            this.gbProblem = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProblemDescription = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtCallDateTime = new System.Windows.Forms.TextBox();
            this.cmbProblemType = new System.Windows.Forms.ComboBox();
            this.gbCaller.SuspendLayout();
            this.gbEquipment.SuspendLayout();
            this.gbProblem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCaller
            // 
            this.gbCaller.Controls.Add(this.label4);
            this.gbCaller.Controls.Add(this.label3);
            this.gbCaller.Controls.Add(this.label2);
            this.gbCaller.Controls.Add(this.label1);
            this.gbCaller.Controls.Add(this.txtOffice);
            this.gbCaller.Controls.Add(this.txtDepartment);
            this.gbCaller.Controls.Add(this.txtJobTitle);
            this.gbCaller.Controls.Add(this.cmbEmployee);
            this.gbCaller.Controls.Add(this.lblOperator);
            this.gbCaller.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCaller.Location = new System.Drawing.Point(0, 0);
            this.gbCaller.Name = "gbCaller";
            this.gbCaller.Size = new System.Drawing.Size(1284, 352);
            this.gbCaller.TabIndex = 0;
            this.gbCaller.TabStop = false;
            this.gbCaller.Text = "Caller Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Office:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Department:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Employee:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Job Title:";
            // 
            // txtOffice
            // 
            this.txtOffice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtOffice.Location = new System.Drawing.Point(188, 291);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.ReadOnly = true;
            this.txtOffice.Size = new System.Drawing.Size(274, 22);
            this.txtOffice.TabIndex = 4;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDepartment.Location = new System.Drawing.Point(188, 237);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(274, 22);
            this.txtDepartment.TabIndex = 3;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtJobTitle.Location = new System.Drawing.Point(188, 179);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.ReadOnly = true;
            this.txtJobTitle.Size = new System.Drawing.Size(274, 22);
            this.txtJobTitle.TabIndex = 2;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(188, 114);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(274, 24);
            this.cmbEmployee.TabIndex = 1;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.ForeColor = System.Drawing.Color.Blue;
            this.lblOperator.Location = new System.Drawing.Point(35, 51);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(83, 17);
            this.lblOperator.TabIndex = 0;
            this.lblOperator.Text = "Operator: ";
            // 
            // gbEquipment
            // 
            this.gbEquipment.Controls.Add(this.label5);
            this.gbEquipment.Controls.Add(this.cmbEquipment);
            this.gbEquipment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbEquipment.Location = new System.Drawing.Point(0, 571);
            this.gbEquipment.Name = "gbEquipment";
            this.gbEquipment.Size = new System.Drawing.Size(1284, 130);
            this.gbEquipment.TabIndex = 5;
            this.gbEquipment.TabStop = false;
            this.gbEquipment.Text = "Equipment Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Choose Equipment";
            // 
            // cmbEquipment
            // 
            this.cmbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipment.FormattingEnabled = true;
            this.cmbEquipment.Location = new System.Drawing.Point(188, 56);
            this.cmbEquipment.Name = "cmbEquipment";
            this.cmbEquipment.Size = new System.Drawing.Size(222, 24);
            this.cmbEquipment.TabIndex = 0;
            // 
            // gbProblem
            // 
            this.gbProblem.Controls.Add(this.label9);
            this.gbProblem.Controls.Add(this.label8);
            this.gbProblem.Controls.Add(this.label7);
            this.gbProblem.Controls.Add(this.label6);
            this.gbProblem.Controls.Add(this.btnCancel);
            this.gbProblem.Controls.Add(this.btnSave);
            this.gbProblem.Controls.Add(this.txtProblemDescription);
            this.gbProblem.Controls.Add(this.txtReason);
            this.gbProblem.Controls.Add(this.txtCallDateTime);
            this.gbProblem.Controls.Add(this.cmbProblemType);
            this.gbProblem.Location = new System.Drawing.Point(12, 358);
            this.gbProblem.Name = "gbProblem";
            this.gbProblem.Size = new System.Drawing.Size(1337, 231);
            this.gbProblem.TabIndex = 6;
            this.gbProblem.TabStop = false;
            this.gbProblem.Text = "Problem Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Call Date Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(646, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Problem Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Reasons:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Choose Problem Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(306, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "💾 Save Problem";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProblemDescription
            // 
            this.txtProblemDescription.Location = new System.Drawing.Point(636, 127);
            this.txtProblemDescription.Multiline = true;
            this.txtProblemDescription.Name = "txtProblemDescription";
            this.txtProblemDescription.Size = new System.Drawing.Size(604, 98);
            this.txtProblemDescription.TabIndex = 3;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(345, 127);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(272, 22);
            this.txtReason.TabIndex = 2;
            // 
            // txtCallDateTime
            // 
            this.txtCallDateTime.Location = new System.Drawing.Point(6, 127);
            this.txtCallDateTime.Name = "txtCallDateTime";
            this.txtCallDateTime.ReadOnly = true;
            this.txtCallDateTime.Size = new System.Drawing.Size(305, 22);
            this.txtCallDateTime.TabIndex = 1;
            // 
            // cmbProblemType
            // 
            this.cmbProblemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProblemType.FormattingEnabled = true;
            this.cmbProblemType.Items.AddRange(new object[] {
            "Hardware, Software, Network, Other"});
            this.cmbProblemType.Location = new System.Drawing.Point(229, 49);
            this.cmbProblemType.Name = "cmbProblemType";
            this.cmbProblemType.Size = new System.Drawing.Size(305, 24);
            this.cmbProblemType.TabIndex = 0;
            this.cmbProblemType.SelectedIndexChanged += new System.EventHandler(this.cmbProblemType_SelectedIndexChanged);
            // 
            // frmNewCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.gbEquipment);
            this.Controls.Add(this.gbCaller);
            this.Controls.Add(this.gbProblem);
            this.Name = "frmNewCall";
            this.Text = "frmNewCall";
            this.gbCaller.ResumeLayout(false);
            this.gbCaller.PerformLayout();
            this.gbEquipment.ResumeLayout(false);
            this.gbEquipment.PerformLayout();
            this.gbProblem.ResumeLayout(false);
            this.gbProblem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCaller;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.GroupBox gbEquipment;
        private System.Windows.Forms.ComboBox cmbEquipment;
        private System.Windows.Forms.GroupBox gbProblem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProblemDescription;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtCallDateTime;
        private System.Windows.Forms.ComboBox cmbProblemType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}