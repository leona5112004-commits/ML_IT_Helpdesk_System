
namespace ML_IT_Helpdesk
{
    partial class frmProblemResolution
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbProblem = new System.Windows.Forms.ComboBox();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtCallDateTime = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtProblemType = new System.Windows.Forms.TextBox();
            this.txtTechnician = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.grpResolution = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResolutionHours = new System.Windows.Forms.TextBox();
            this.txtResolutionDescription = new System.Windows.Forms.TextBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpDetails.SuspendLayout();
            this.grpResolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(76, 58);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(193, 17);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Problem (In Progress):";
            // 
            // cmbProblem
            // 
            this.cmbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProblem.FormattingEnabled = true;
            this.cmbProblem.Location = new System.Drawing.Point(337, 51);
            this.cmbProblem.Name = "cmbProblem";
            this.cmbProblem.Size = new System.Drawing.Size(185, 24);
            this.cmbProblem.TabIndex = 1;
            this.cmbProblem.SelectedIndexChanged += new System.EventHandler(this.cmbProblem_SelectedIndexChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.label5);
            this.grpDetails.Controls.Add(this.label4);
            this.grpDetails.Controls.Add(this.label3);
            this.grpDetails.Controls.Add(this.txtStatus);
            this.grpDetails.Controls.Add(this.txtCallDateTime);
            this.grpDetails.Controls.Add(this.txtDescription);
            this.grpDetails.Controls.Add(this.txtReason);
            this.grpDetails.Controls.Add(this.txtProblemType);
            this.grpDetails.Controls.Add(this.txtTechnician);
            this.grpDetails.Controls.Add(this.txtEmployee);
            this.grpDetails.Location = new System.Drawing.Point(88, 130);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(848, 364);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Problem Details";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(579, 317);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(228, 22);
            this.txtStatus.TabIndex = 6;
            // 
            // txtCallDateTime
            // 
            this.txtCallDateTime.Location = new System.Drawing.Point(579, 246);
            this.txtCallDateTime.Name = "txtCallDateTime";
            this.txtCallDateTime.ReadOnly = true;
            this.txtCallDateTime.Size = new System.Drawing.Size(228, 22);
            this.txtCallDateTime.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(579, 153);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(228, 22);
            this.txtDescription.TabIndex = 4;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(15, 128);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(544, 211);
            this.txtReason.TabIndex = 3;
            // 
            // txtProblemType
            // 
            this.txtProblemType.Location = new System.Drawing.Point(583, 58);
            this.txtProblemType.Name = "txtProblemType";
            this.txtProblemType.ReadOnly = true;
            this.txtProblemType.Size = new System.Drawing.Size(224, 22);
            this.txtProblemType.TabIndex = 2;
            // 
            // txtTechnician
            // 
            this.txtTechnician.Location = new System.Drawing.Point(310, 58);
            this.txtTechnician.Name = "txtTechnician";
            this.txtTechnician.ReadOnly = true;
            this.txtTechnician.Size = new System.Drawing.Size(232, 22);
            this.txtTechnician.TabIndex = 1;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(15, 58);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(212, 22);
            this.txtEmployee.TabIndex = 0;
            // 
            // grpResolution
            // 
            this.grpResolution.Controls.Add(this.label2);
            this.grpResolution.Controls.Add(this.label1);
            this.grpResolution.Controls.Add(this.txtResolutionHours);
            this.grpResolution.Controls.Add(this.txtResolutionDescription);
            this.grpResolution.Location = new System.Drawing.Point(88, 520);
            this.grpResolution.Name = "grpResolution";
            this.grpResolution.Size = new System.Drawing.Size(848, 167);
            this.grpResolution.TabIndex = 7;
            this.grpResolution.TabStop = false;
            this.grpResolution.Text = "Resolution Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resolution Hours ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolution Description:";
            // 
            // txtResolutionHours
            // 
            this.txtResolutionHours.Location = new System.Drawing.Point(172, 125);
            this.txtResolutionHours.Name = "txtResolutionHours";
            this.txtResolutionHours.Size = new System.Drawing.Size(100, 22);
            this.txtResolutionHours.TabIndex = 1;
            // 
            // txtResolutionDescription
            // 
            this.txtResolutionDescription.Location = new System.Drawing.Point(172, 34);
            this.txtResolutionDescription.Multiline = true;
            this.txtResolutionDescription.Name = "txtResolutionDescription";
            this.txtResolutionDescription.Size = new System.Drawing.Size(502, 85);
            this.txtResolutionDescription.TabIndex = 0;
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(965, 529);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(160, 31);
            this.btnResolve.TabIndex = 8;
            this.btnResolve.Text = "✅ Mark as Resolved";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(965, 591);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Employee:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Teachnician:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Problem Type";
            // 
            // frmProblemResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 754);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.grpResolution);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.cmbProblem);
            this.Controls.Add(this.lblSelect);
            this.Name = "frmProblemResolution";
            this.Text = "frmProblemResolution";
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpResolution.ResumeLayout(false);
            this.grpResolution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cmbProblem;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtCallDateTime;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtProblemType;
        private System.Windows.Forms.TextBox txtTechnician;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.GroupBox grpResolution;
        private System.Windows.Forms.TextBox txtResolutionHours;
        private System.Windows.Forms.TextBox txtResolutionDescription;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}