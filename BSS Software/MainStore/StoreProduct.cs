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

namespace BSSSoftware.MainStore
{
    public partial class StoreProduct : Form
    {
        
            #region Variables
        private StoreProductControl m_controller = null;
        string key = null;
        #endregion

        #region Constructor
        public StoreProduct()
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
            m_controller = new StoreProductControl();
            GridViewDataBind();
            ProductCodBind();
        }
        public void ProductCodBind()
        {
            cboProductcode.DataSource = m_controller.SelectAll();
            cboProductcode.DisplayMember = "ProductCode";
            cboProductcode.ValueMember = "ProductId";
        }

        public void GridViewDataBind()
        {
            dgvStoreProduct.DataSource = m_controller.SelectAll();
            dgvStoreProduct.AutoGenerateColumns = false;
        }
        
        public void Save(string key)
        {
            if (txtCode.Text.Equals(null)) return;
            BSSInfo.xsdMainstore.StoreProductRow dataRow = (new BSSInfo.xsdMainstore.StoreProductDataTable()).NewStoreProductRow();
            try
            {
                dataRow.ProductCode = txtCode.Text.Trim();
                dataRow.ProductName = txtName.Text.Trim();
                dataRow.Price = Convert.ToInt32(numericUpDownPrice.Value);

                if (string.IsNullOrEmpty(key))
                    this.m_controller.Insert(dataRow);
                else
                {
                    dataRow.ProductId = key;
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
            if ((this.dgvStoreProduct.SelectedRows == null) || (this.dgvStoreProduct.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvStoreProduct.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "ProductId", string.Empty);
                this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductCode", string.Empty);
                this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductName", string.Empty);
                this.numericUpDownPrice.Value = Global.GetDataFromRow<int>(dataRowView.Row, "Price", 0);

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

            try
            {
                if ((this.dgvStoreProduct.SelectedRows == null) || (this.dgvStoreProduct.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvStoreProduct.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    key = Global.GetDataFromRow<string>(dataRowView.Row, "ProductId", string.Empty);
                }
                this.Delete(key);
                GridViewDataBind();
            }
            catch 
            {
                MessageBox.Show("This Product has Invoice");
            }
        }

        private void btnStoreRecord_Click(object sender, EventArgs e)
        {
            StoreRecord sr = new StoreRecord();
            sr.Show();
        }
        private void btnPrintReport_Click(object sender, EventArgs e)
        {

        }

        private void cboProductcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cboProductcode.SelectedValue.ToString()))
                {

                    cboProductcode.Focus();
                    return;
                }
                BSSInfo.xsdMainstore.StoreProductRow row = m_controller.SelectByCode(cboProductcode.SelectedValue.ToString());
                string productId = row.ProductId;
              //  txtname.Text = row.ProductName;
                //txtprice.Text = row.Price.ToString();
            }
            catch
            {

                //MessageBox.Show("Please Check Product Code Number and Try Again!","Sale",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //txtcode.Clear();
                //txtcode.Select();
            }
        }
    }
}
