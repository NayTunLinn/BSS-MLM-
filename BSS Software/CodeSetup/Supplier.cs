using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSInfo;
using BSSCommon;

namespace BSSSoftware.CodeSetup
{
    public partial class Supplier : Form
    {

          #region Variables
        private SupplierControl m_controller = null;
        string gender = null;
        string key = null;
        #endregion

        #region Constructor
        public Supplier()
        {
            InitializeComponent();
            Initializing();
        } 
        #endregion

        #region Methods

        #region For Row Number
        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null)
            {
                gridView.RowHeadersWidth = 50;
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    gridView.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null)
            {
                gridView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }
        #endregion

        public void Initializing()
        {
            m_controller = new SupplierControl();
            GridViewDataBind();
        }
        public void GridViewDataBind()
        {
            dgvSupplier.DataSource = m_controller.SelectAll();
            dgvSupplier.AutoGenerateColumns = false;
        }
        
        public void Save(string key)
        {
            if (txtsupname.Text.Equals(null)) return;
            xsdCodeSetup.SupplierRow dataRow = (new xsdCodeSetup.SupplierDataTable()).NewSupplierRow();
            try
            {

                dataRow.SupplierName = txtsupname.Text.Trim();


                dataRow.SupplierName = txtsupname.Text.Trim();
                dataRow.Email = txtEmail.Text.Trim();
                dataRow.Phone = txtPhNo.Text.Trim();
                dataRow.Address = txtAddress.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.m_controller.Insert(dataRow);
                else
                {
                    dataRow.SupplierId = key;
                    this.m_controller.Update(dataRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
                

            //row.TchrImg
        }

        public void Delete(string key)      
        {
            if (key.Equals(null)) return;
            this.m_controller.Delete(key);
        }
        #endregion

      
        private void btnNew_Click(object sender, EventArgs e)
        {
           
            Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Save(null);
                GridViewDataBind();
                btnNew.Focus();
               
            }
            Utility.AllClear(this.panelEntry);
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((this.dgvSupplier.SelectedRows == null) || (this.dgvSupplier.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvSupplier.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "SupplierId", string.Empty);
                this.txtsupname.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SupplierName", string.Empty);
                this.txtEmail.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Email", string.Empty);
                this.txtPhNo.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Phone", string.Empty);
                this.txtAddress.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Address", string.Empty);
                this.txtDesp.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Desp", string.Empty);

                Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Save(key);
                    GridViewDataBind();
                    btnNew.Focus();

                }
                Utility.AllClear(this.panelEntry);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if ((this.dgvSupplier.SelectedRows == null) || (this.dgvSupplier.SelectedRows.Count < 1)) return;
             DataRowView dataRowView = this.dgvSupplier.SelectedRows[0].DataBoundItem as DataRowView;
             if (dataRowView != null)
             {
                 key = Global.GetDataFromRow<string>(dataRowView.Row, "SupplierId", string.Empty);
             }
             this.Delete(key);
             GridViewDataBind();
        }
    }
}
