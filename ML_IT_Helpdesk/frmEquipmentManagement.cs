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
    public partial class frmEquipmentManagement : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private int selectedEquipmentID = 0; 
        private DataTable equipmentList;
        public frmEquipmentManagement()
        {
            InitializeComponent();
            LoadEquipment();
            LoadOffices();            
            ClearFields();
            btnDelete.Enabled = false;
        }
        private void LoadOffices()
        {
            try
            {
                string query = "SELECT OfficeID, OfficeName FROM Office ORDER BY OfficeName";
                DataTable dt = db.ExecuteQuery(query);
                cmbOffice.DataSource = dt;
                cmbOffice.DisplayMember = "OfficeName";
                cmbOffice.ValueMember = "OfficeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading offices: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- Load Equipment List into DataGridView ----
        private void LoadEquipment()
        {
            try
            {
                string query = @"
                    SELECT e.EquipmentID, e.SerialNumber, e.EquipmentType, e.Manufacturer, 
                           e.Make, e.Model, o.OfficeName, e.WarrantyStartDate, e.WarrantyEndDate, e.WarrantyStatus
                    FROM Equipment e
                    INNER JOIN Office o ON e.OfficeID = o.OfficeID
                    ORDER BY e.SerialNumber";
                equipmentList = db.ExecuteQuery(query);
                dgvEquipment.DataSource = equipmentList;

                // Column Headers 
                dgvEquipment.Columns["EquipmentID"].Visible = false;
                dgvEquipment.Columns["SerialNumber"].HeaderText = "Serial Number";
                dgvEquipment.Columns["EquipmentType"].HeaderText = "Type";
                dgvEquipment.Columns["Manufacturer"].HeaderText = "Manufacturer";
                dgvEquipment.Columns["Make"].HeaderText = "Make";
                dgvEquipment.Columns["Model"].HeaderText = "Model";
                dgvEquipment.Columns["OfficeName"].HeaderText = "Office";
                dgvEquipment.Columns["WarrantyStartDate"].HeaderText = "Warranty Start";
                dgvEquipment.Columns["WarrantyEndDate"].HeaderText = "Warranty End";
                dgvEquipment.Columns["WarrantyStatus"].HeaderText = "Warranty Status";

                dgvEquipment.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            string query = $@"
                SELECT SerialNumber, EquipmentType, Manufacturer, Model, WarrantyStatus 
                FROM Equipment 
                WHERE SerialNumber LIKE '%{filter}%' OR EquipmentType LIKE '%{filter}%'";
            DataTable dt = db.ExecuteQuery(query);
            dgvEquipment.DataSource = dt;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            btnSave.Text = "💾 Save New";
            txtSerialNumber.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = txtSearch.Text.Trim();
                string query = $@"
                    SELECT e.EquipmentID, e.SerialNumber, e.EquipmentType, e.Manufacturer, 
                           e.Make, e.Model, o.OfficeName, e.WarrantyStartDate, e.WarrantyEndDate, e.WarrantyStatus
                    FROM Equipment e
                    INNER JOIN Office o ON e.OfficeID = o.OfficeID
                    WHERE e.SerialNumber LIKE '%{filter}%' OR e.EquipmentType LIKE '%{filter}%' 
                       OR e.Manufacturer LIKE '%{filter}%' OR e.Model LIKE '%{filter}%'
                    ORDER BY e.SerialNumber";
                equipmentList = db.ExecuteQuery(query);
                dgvEquipment.DataSource = equipmentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEquipment.Rows[e.RowIndex];
                selectedEquipmentID = Convert.ToInt32(row.Cells["EquipmentID"].Value);
                txtSerialNumber.Text = row.Cells["SerialNumber"].Value.ToString();
                txtEquipmentType.Text = row.Cells["EquipmentType"].Value.ToString();
                txtManufacturer.Text = row.Cells["Manufacturer"].Value.ToString();
                txtMake.Text = row.Cells["Make"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                cmbOffice.Text = row.Cells["OfficeName"].Value.ToString();

                // Warranty Dates ကို DateTimePicker ထဲထည့်ပါ
                if (row.Cells["WarrantyStartDate"].Value != DBNull.Value)
                    dtpWarrantyStart.Value = Convert.ToDateTime(row.Cells["WarrantyStartDate"].Value);
                if (row.Cells["WarrantyEndDate"].Value != DBNull.Value)
                    dtpWarrantyEnd.Value = Convert.ToDateTime(row.Cells["WarrantyEndDate"].Value);

                btnDelete.Enabled = true;
                btnSave.Text = "💾 Update";
                btnAddNew.Enabled = true;
            }
        }

        private void ClearFields()
        {
            selectedEquipmentID = 0;
            txtSerialNumber.Clear();
            txtEquipmentType.Clear();
            txtManufacturer.Clear();
            txtMake.Clear();
            txtModel.Clear();
            if (cmbOffice.Items.Count > 0) cmbOffice.SelectedIndex = 0;
            dtpWarrantyStart.Value = DateTime.Now;
            dtpWarrantyEnd.Value = DateTime.Now.AddYears(1);

            btnDelete.Enabled = false;
            btnSave.Text = "💾 Save";
            txtSerialNumber.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSerialNumber.Text) || string.IsNullOrEmpty(txtEquipmentType.Text))
            {
                MessageBox.Show("Serial Number and Equipment Type are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Warranty Date Validation
            if (dtpWarrantyEnd.Value < dtpWarrantyStart.Value)
            {
                MessageBox.Show("Warranty End Date must be later than or equal to Warranty Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedEquipmentID == 0) // ⭐ INSERT (New Equipment)
                {
                    string query = @"
                        INSERT INTO Equipment (SerialNumber, EquipmentType, Manufacturer, Make, Model, OfficeID, WarrantyStartDate, WarrantyEndDate)
                        VALUES (@Serial, @Type, @Mfr, @Make, @Model, @OfficeID, @WStart, @WEnd)";

                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@Serial", txtSerialNumber.Text.Trim()),
                        new SqlParameter("@Type", txtEquipmentType.Text.Trim()),
                        new SqlParameter("@Mfr", (object)txtManufacturer.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@Make", (object)txtMake.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@Model", (object)txtModel.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@OfficeID", cmbOffice.SelectedValue),
                        new SqlParameter("@WStart", dtpWarrantyStart.Value),
                        new SqlParameter("@WEnd", dtpWarrantyEnd.Value)
                    };
                    db.ExecuteNonQuery(query, p);
                    MessageBox.Show("Equipment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // ⭐ UPDATE (Edit Equipment)
                {
                    string query = @"
                        UPDATE Equipment 
                        SET SerialNumber = @Serial, EquipmentType = @Type, Manufacturer = @Mfr, 
                            Make = @Make, Model = @Model, OfficeID = @OfficeID,
                            WarrantyStartDate = @WStart, WarrantyEndDate = @WEnd
                        WHERE EquipmentID = @ID";

                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@Serial", txtSerialNumber.Text.Trim()),
                        new SqlParameter("@Type", txtEquipmentType.Text.Trim()),
                        new SqlParameter("@Mfr", (object)txtManufacturer.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@Make", (object)txtMake.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@Model", (object)txtModel.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@OfficeID", cmbOffice.SelectedValue),
                        new SqlParameter("@WStart", dtpWarrantyStart.Value),
                        new SqlParameter("@WEnd", dtpWarrantyEnd.Value),
                        new SqlParameter("@ID", selectedEquipmentID)
                    };
                    db.ExecuteNonQuery(query, p);
                    MessageBox.Show("Equipment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadEquipment(); // Refresh DataGridView
                ClearFields();
            }
            catch (SqlException ex) // Handle unique constraint violation (SerialNumber already exists)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    MessageBox.Show("Serial Number already exists. Please use a different Serial Number.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (selectedEquipmentID == 0) return;

            // Confirm Delete
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete equipment '{txtSerialNumber.Text}'?\nThis action cannot be undone!",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // ⭐ Try Hard Delete first (Due to FK constraint, it might fail)
                    string query = "DELETE FROM Equipment WHERE EquipmentID = @ID";
                    int rowsAffected = db.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@ID", selectedEquipmentID) });

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Equipment deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEquipment();
                        ClearFields();
                    }
                }
                catch (SqlException ex)
                {
                    // ⭐⭐ Distinction Level: Handle Foreign Key constraint (Error Number 547)
                    if (ex.Number == 547) // Foreign key constraint error
                    {
                        MessageBox.Show("Cannot delete this equipment because it is linked to existing Helpdesk Problems.\n\n" +
                                        "You can either:\n" +
                                        "1. Reassign those problems to other equipment.\n" +
                                        "2. Mark this equipment as 'Retired' using a status flag (future improvement).",
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

        // ---- Cancel Button ----
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

