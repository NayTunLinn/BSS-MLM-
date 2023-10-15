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
    public partial class Product : Form
    {
            #region Variables
        private ProductControl m_controller = null;
        private ProfitrateControl p_controller = null;
        string key = null;
        #endregion

        #region Constructor
        public Product()
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
            m_controller = new ProductControl();
            p_controller = new ProfitrateControl();
            GridViewDataBind();
        }
        public void GridViewDataBind()
        {
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = p_controller.SelectAll();
            
        }
       
        
        public void Save(string key)
        {
            if (txtCode.Text.Equals(string.Empty)) return;
            if (string.IsNullOrEmpty(txtName.Text)) return;
            if (numericUpDownPrice.Value<0) return;
            if (string.IsNullOrEmpty(txtmerchantrate.Text)) return;
            if (string.IsNullOrEmpty(txtsmerchantrate.Text)) return;
            if (string.IsNullOrEmpty(txtretailerrate.Text)) return;
            if (string.IsNullOrEmpty(txtwsalerate.Text)) return;
            xsdCodeSetup.ProductRow ProductRow = (new xsdCodeSetup.ProductDataTable()).NewProductRow();
            xsdCodeSetup.ProfitRatingsRow dataRow = (new xsdCodeSetup.ProfitRatingsDataTable()).NewProfitRatingsRow();
            try
            {
                ProductRow.ProductCode = txtCode.Text.Trim();
                ProductRow.ProductName = txtName.Text.Trim();
                ProductRow.Price = Convert.ToInt32(numericUpDownPrice.Value);
                ProductRow.Desp = txtDesp.Text.Trim();

                /// for Rate
                /// 
                dataRow.MerchantRate = Convert.ToDecimal(txtmerchantrate.Text.Trim());
                dataRow.SMerchantRate = Convert.ToDecimal(txtsmerchantrate.Text.Trim());
                dataRow.WsaleRate = Convert.ToDecimal(txtwsalerate.Text.Trim());
                dataRow.RetailRate = Convert.ToDecimal(txtretailerrate.Text.Trim());

                if (string.IsNullOrEmpty(key))
                    this.m_controller.InsertAll(ProductRow,dataRow);
                else
                {
                    ProductRow.ProductId = key;
                    this.m_controller.Update(ProductRow);
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
            groupBox1.Enabled = true;
            Utility.AllClear(panelEntry);
            Utility.AllClear(groupBox1);

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
            groupBox1.Enabled = false;
            if ((this.dgvProduct.SelectedRows == null) || (this.dgvProduct.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvProduct.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "ProductId", string.Empty);
                this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductCode", string.Empty);
                this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductName", string.Empty); 
                this.numericUpDownPrice.Value = Global.GetDataFromRow<int>(dataRowView.Row, "Price", 0);
                this.txtmerchantrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantRate", string.Empty);
                this.txtsmerchantrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantRate", string.Empty);
                this.txtwsalerate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleRate", string.Empty);
                this.txtretailerrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailRate", string.Empty);

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

            try
            {
                if ((this.dgvProduct.SelectedRows == null) || (this.dgvProduct.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvProduct.SelectedRows[0].DataBoundItem as DataRowView;
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPrice_Enter(object sender, EventArgs e)
        {
            numericUpDownPrice.Select(0, numericUpDownPrice.Text.Length);
        }

       }
}
