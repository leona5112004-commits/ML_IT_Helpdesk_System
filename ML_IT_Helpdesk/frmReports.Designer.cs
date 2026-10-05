
namespace ML_IT_Helpdesk
{
    partial class frmReports
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
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.tabOffice = new System.Windows.Forms.TabPage();
            this.tabTechnician = new System.Windows.Forms.TabPage();
            this.tabMonthlySummary = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.dgvMonthlySummary = new System.Windows.Forms.DataGridView();
            this.dgvTechnicianReport = new System.Windows.Forms.DataGridView();
            this.dgvOfficeReport = new System.Windows.Forms.DataGridView();
            this.dgvEquipmentReport = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.tabEquipment.SuspendLayout();
            this.tabOffice.SuspendLayout();
            this.tabTechnician.SuspendLayout();
            this.tabMonthlySummary.SuspendLayout();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicianReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.btnExportReport);
            this.tabEquipment.Controls.Add(this.btnRefresh);
            this.tabEquipment.Controls.Add(this.dgvEquipmentReport);
            this.tabEquipment.Location = new System.Drawing.Point(4, 25);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquipment.Size = new System.Drawing.Size(1259, 596);
            this.tabEquipment.TabIndex = 3;
            this.tabEquipment.Text = "🖥️ Equipment Report";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // tabOffice
            // 
            this.tabOffice.Controls.Add(this.dgvOfficeReport);
            this.tabOffice.Location = new System.Drawing.Point(4, 25);
            this.tabOffice.Name = "tabOffice";
            this.tabOffice.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffice.Size = new System.Drawing.Size(1259, 596);
            this.tabOffice.TabIndex = 2;
            this.tabOffice.Text = "🏢 Office Report";
            this.tabOffice.UseVisualStyleBackColor = true;
            // 
            // tabTechnician
            // 
            this.tabTechnician.Controls.Add(this.dgvTechnicianReport);
            this.tabTechnician.Location = new System.Drawing.Point(4, 25);
            this.tabTechnician.Name = "tabTechnician";
            this.tabTechnician.Padding = new System.Windows.Forms.Padding(3);
            this.tabTechnician.Size = new System.Drawing.Size(1259, 596);
            this.tabTechnician.TabIndex = 1;
            this.tabTechnician.Text = "👨‍🔧 Technician Report";
            this.tabTechnician.UseVisualStyleBackColor = true;
            // 
            // tabMonthlySummary
            // 
            this.tabMonthlySummary.Controls.Add(this.dgvMonthlySummary);
            this.tabMonthlySummary.Location = new System.Drawing.Point(4, 25);
            this.tabMonthlySummary.Name = "tabMonthlySummary";
            this.tabMonthlySummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonthlySummary.Size = new System.Drawing.Size(1259, 596);
            this.tabMonthlySummary.TabIndex = 0;
            this.tabMonthlySummary.Text = "📅 Monthly Summary";
            this.tabMonthlySummary.UseVisualStyleBackColor = true;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabMonthlySummary);
            this.tabReports.Controls.Add(this.tabTechnician);
            this.tabReports.Controls.Add(this.tabOffice);
            this.tabReports.Controls.Add(this.tabEquipment);
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Location = new System.Drawing.Point(0, 0);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(1267, 625);
            this.tabReports.TabIndex = 0;
            // 
            // dgvMonthlySummary
            // 
            this.dgvMonthlySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthlySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonthlySummary.Location = new System.Drawing.Point(3, 3);
            this.dgvMonthlySummary.Name = "dgvMonthlySummary";
            this.dgvMonthlySummary.ReadOnly = true;
            this.dgvMonthlySummary.RowHeadersWidth = 51;
            this.dgvMonthlySummary.RowTemplate.Height = 24;
            this.dgvMonthlySummary.Size = new System.Drawing.Size(1253, 590);
            this.dgvMonthlySummary.TabIndex = 0;
            // 
            // dgvTechnicianReport
            // 
            this.dgvTechnicianReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnicianReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTechnicianReport.Location = new System.Drawing.Point(3, 3);
            this.dgvTechnicianReport.Name = "dgvTechnicianReport";
            this.dgvTechnicianReport.ReadOnly = true;
            this.dgvTechnicianReport.RowHeadersWidth = 51;
            this.dgvTechnicianReport.RowTemplate.Height = 24;
            this.dgvTechnicianReport.Size = new System.Drawing.Size(1253, 590);
            this.dgvTechnicianReport.TabIndex = 0;
            // 
            // dgvOfficeReport
            // 
            this.dgvOfficeReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOfficeReport.Location = new System.Drawing.Point(3, 3);
            this.dgvOfficeReport.Name = "dgvOfficeReport";
            this.dgvOfficeReport.ReadOnly = true;
            this.dgvOfficeReport.RowHeadersWidth = 51;
            this.dgvOfficeReport.RowTemplate.Height = 24;
            this.dgvOfficeReport.Size = new System.Drawing.Size(1253, 590);
            this.dgvOfficeReport.TabIndex = 0;
            // 
            // dgvEquipmentReport
            // 
            this.dgvEquipmentReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipmentReport.Location = new System.Drawing.Point(3, 3);
            this.dgvEquipmentReport.Name = "dgvEquipmentReport";
            this.dgvEquipmentReport.ReadOnly = true;
            this.dgvEquipmentReport.RowHeadersWidth = 51;
            this.dgvEquipmentReport.RowTemplate.Height = 24;
            this.dgvEquipmentReport.Size = new System.Drawing.Size(1253, 590);
            this.dgvEquipmentReport.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(777, 532);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Refresh All";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(931, 532);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(129, 32);
            this.btnExportReport.TabIndex = 2;
            this.btnExportReport.Text = "📤 Export CSV";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 625);
            this.Controls.Add(this.tabReports);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.tabEquipment.ResumeLayout(false);
            this.tabOffice.ResumeLayout(false);
            this.tabTechnician.ResumeLayout(false);
            this.tabMonthlySummary.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicianReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabEquipment;
        private System.Windows.Forms.TabPage tabOffice;
        private System.Windows.Forms.TabPage tabTechnician;
        private System.Windows.Forms.TabPage tabMonthlySummary;
        private System.Windows.Forms.DataGridView dgvMonthlySummary;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvEquipmentReport;
        private System.Windows.Forms.DataGridView dgvOfficeReport;
        private System.Windows.Forms.DataGridView dgvTechnicianReport;
    }
}