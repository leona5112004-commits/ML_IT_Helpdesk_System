
namespace ML_IT_Helpdesk
{
    partial class frmTechnicianAssignment
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
            this.lblSelectProblem = new System.Windows.Forms.Label();
            this.cmbProblem = new System.Windows.Forms.ComboBox();
            this.txtProblemType = new System.Windows.Forms.TextBox();
            this.txtCaller = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmbSkill = new System.Windows.Forms.ComboBox();
            this.btnFindTechnicians = new System.Windows.Forms.Button();
            this.dgvTechnicians = new System.Windows.Forms.DataGridView();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicians)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectProblem
            // 
            this.lblSelectProblem.AutoSize = true;
            this.lblSelectProblem.Location = new System.Drawing.Point(49, 75);
            this.lblSelectProblem.Name = "lblSelectProblem";
            this.lblSelectProblem.Size = new System.Drawing.Size(146, 17);
            this.lblSelectProblem.TabIndex = 0;
            this.lblSelectProblem.Text = "Select Open Problem:";
            // 
            // cmbProblem
            // 
            this.cmbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProblem.FormattingEnabled = true;
            this.cmbProblem.Location = new System.Drawing.Point(224, 75);
            this.cmbProblem.Name = "cmbProblem";
            this.cmbProblem.Size = new System.Drawing.Size(323, 24);
            this.cmbProblem.TabIndex = 1;
            this.cmbProblem.SelectedIndexChanged += new System.EventHandler(this.cmbProblem_SelectedIndexChanged);
            // 
            // txtProblemType
            // 
            this.txtProblemType.Location = new System.Drawing.Point(52, 151);
            this.txtProblemType.Name = "txtProblemType";
            this.txtProblemType.ReadOnly = true;
            this.txtProblemType.Size = new System.Drawing.Size(202, 22);
            this.txtProblemType.TabIndex = 2;
            // 
            // txtCaller
            // 
            this.txtCaller.Location = new System.Drawing.Point(275, 151);
            this.txtCaller.Name = "txtCaller";
            this.txtCaller.ReadOnly = true;
            this.txtCaller.Size = new System.Drawing.Size(272, 22);
            this.txtCaller.TabIndex = 3;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(51, 255);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(212, 22);
            this.txtDepartment.TabIndex = 4;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(275, 255);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(272, 124);
            this.txtReason.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(43, 470);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(211, 111);
            this.txtDescription.TabIndex = 6;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(275, 470);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(219, 22);
            this.txtStatus.TabIndex = 7;
            // 
            // cmbSkill
            // 
            this.cmbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill.FormattingEnabled = true;
            this.cmbSkill.Location = new System.Drawing.Point(569, 72);
            this.cmbSkill.Name = "cmbSkill";
            this.cmbSkill.Size = new System.Drawing.Size(235, 24);
            this.cmbSkill.TabIndex = 8;
            // 
            // btnFindTechnicians
            // 
            this.btnFindTechnicians.Location = new System.Drawing.Point(810, 72);
            this.btnFindTechnicians.Name = "btnFindTechnicians";
            this.btnFindTechnicians.Size = new System.Drawing.Size(210, 27);
            this.btnFindTechnicians.TabIndex = 9;
            this.btnFindTechnicians.Text = "🔎 Find Technicians";
            this.btnFindTechnicians.UseVisualStyleBackColor = true;
            this.btnFindTechnicians.Click += new System.EventHandler(this.btnFindTechnicians_Click);
            // 
            // dgvTechnicians
            // 
            this.dgvTechnicians.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnicians.Location = new System.Drawing.Point(569, 140);
            this.dgvTechnicians.MultiSelect = false;
            this.dgvTechnicians.Name = "dgvTechnicians";
            this.dgvTechnicians.ReadOnly = true;
            this.dgvTechnicians.RowHeadersWidth = 51;
            this.dgvTechnicians.RowTemplate.Height = 24;
            this.dgvTechnicians.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTechnicians.Size = new System.Drawing.Size(728, 352);
            this.dgvTechnicians.TabIndex = 10;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(611, 519);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(132, 35);
            this.btnAssign.TabIndex = 11;
            this.btnAssign.Text = "✅ Assign Selected";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(870, 519);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 35);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Problem Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Caller:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Reason:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Status:";
            // 
            // frmTechnicianAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 661);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.dgvTechnicians);
            this.Controls.Add(this.btnFindTechnicians);
            this.Controls.Add(this.cmbSkill);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtCaller);
            this.Controls.Add(this.txtProblemType);
            this.Controls.Add(this.cmbProblem);
            this.Controls.Add(this.lblSelectProblem);
            this.Name = "frmTechnicianAssignment";
            this.Text = "frmfrmTechnicianAssignment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicians)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectProblem;
        private System.Windows.Forms.ComboBox cmbProblem;
        private System.Windows.Forms.TextBox txtProblemType;
        private System.Windows.Forms.TextBox txtCaller;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ComboBox cmbSkill;
        private System.Windows.Forms.Button btnFindTechnicians;
        private System.Windows.Forms.DataGridView dgvTechnicians;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}