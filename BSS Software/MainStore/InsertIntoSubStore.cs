using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSInfo;
using BSSBussinessLogic.StoreControls;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.ProductSaleControl;
using BSSBussinessLogic.ReturnControls;

namespace BSSSoftware.MainStore
{
    public partial class InsertIntoSubStore : Form
    {
        public InsertIntoSubStore()
        {
            InitializeComponent();
            Initalizing();
        }
        #region Variables
        MainStore.StoreToSale StoreToSale = null;
        private StoreProductControl m_controller = null;
        private SubStoreReturnControl s_controller = null;
        private ProductControl P_controller = null;
        private GeneralControl g_controller = null;

        private string productId = null;
        xsdMainstore.StoreProductInsertDataTable MsToSubStore = null;
        xsdReturn.InsertProductDataTable RetProduct = null;

        xsdReturn.StoreReturnRow datarow = null;
        //xsdSubStore.InvoiceStoreRow datarow = null;

        xsdReturn.StoreReturnDataTable mStore = null;
        // xsdSubStore.InvoiceStoreDataTable InvStore = null;
        private MainStoreToSubStoreControl st_controller = null;
        xsdMainstore.MainStoreInvoiceDetailDataTable mStoreDetail = null;
        xsdMainstore.StoreProductInsertDataTable OtherToSub = null;
        int Total = 0;

        AutoCompleteStringCollection CodeAutoCompleteCollection;

        //  private produ
        string ReturnType = null;
        #endregion
        private void Initalizing()
        {

            m_controller = new StoreProductControl();
            s_controller = new SubStoreReturnControl();
            P_controller = new ProductControl();
            g_controller = new GeneralControl();
            StoreToSale = new MainStore.StoreToSale();
            mStore = new xsdReturn.StoreReturnDataTable();
            MsToSubStore = new xsdMainstore.StoreProductInsertDataTable();
            RetProduct = new xsdReturn.InsertProductDataTable();
            st_controller = new MainStoreToSubStoreControl();
            mStoreDetail = new xsdMainstore.MainStoreInvoiceDetailDataTable();
            //datarow = new BSSInfo.MainStore.InvoiceStoreRow();

            lblInvNo.Text = g_controller.FakeGenerateCode("MStore");
            lblDate.Text = DateTime.Now.ToString("dd / MMMM / yyyy");
            BalanceProductSubStoreBind();
            ProductCodeBinding();
            //this.DataBinding();
        }
        private void btnreport_Click(object sender, EventArgs e)
        {

        }
        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.Text)) return;

            xsdSubStore.StoreProductRow productRow = m_controller.SelectByCode(txtCode.Text);

            if (productRow != null)
            {
                this.txtproductname.Tag = productRow;
                productId = productRow.ProductId;
                txtproductname.Text = productRow.ProductName;
                txtPrice.Text = productRow.Price.ToString();
            }
        }
        public void ProductCodeBinding()
        {
            xsdCodeSetup.ProductDataTable dt = P_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["ProductCode"].ToString() + "     " + row["ProductName"].ToString());
            }
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
        }
        private void txtCode_Validated(object sender, EventArgs e)
        {
            int i = txtCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtCode.Text = (txtCode.Text.Remove(i)).Trim();

        }
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

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTotal.Text) < 0) return;
                if (!string.IsNullOrEmpty(txtCode.Text) || !string.IsNullOrEmpty(txtTotal.Text))
                {

                    xsdReturn.InsertProductRow s_row = RetProduct.NewInsertProductRow();

                    s_row.ProductId = productId;
                    s_row.ProductCode = txtCode.Text;
                    s_row.ProductName = txtproductname.Text;
                    s_row.Total = Convert.ToInt16(txtTotal.Text);

                    //s_row. = Convert.ToInt32(txtPrice.Text);

                    Total += Convert.ToInt16(txtTotal.Text);

                    // txtTotalProduct.Text = Total.ToString();

                    RetProduct.AddInsertProductRow(s_row);

                    dgvProductInsertIntoSubStore.AutoGenerateColumns = false;
                    dgvProductInsertIntoSubStore.DataSource = RetProduct;

                    dgvProductInsertIntoSubStore.Refresh();
                   textboxClear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtCode.Select();
        }
        private void textboxClear()
        {
            txtCode.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            txtDescp.Clear();
            txtproductname.Clear();
        }
            private void BalanceProductSubStoreBind()
        {
            dgvBalanceSubStore.DataSource = st_controller.BalanceStoreProductSelect();
            dgvBalanceSubStore.AutoGenerateColumns = false;
        }
         
            private void btnRemove_Click(object sender, EventArgs e)
            {
                try
                {
                    if ((this.dgvProductInsertIntoSubStore.SelectedRows == null) || (this.dgvProductInsertIntoSubStore.SelectedRows.Count < 1)) return;
                    DataRowView dataRowView = this.dgvProductInsertIntoSubStore.SelectedRows[0].DataBoundItem as DataRowView;
                    if (dataRowView != null)
                    {
                        DataRow dr = RetProduct.Rows[dgvProductInsertIntoSubStore.CurrentCell.RowIndex];

                        Total -= Convert.ToInt32(dr["Total"]);

                        dr.Delete();
                        //textboxClear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

         private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvProductInsertIntoSubStore.SelectedRows == null) || (this.dgvProductInsertIntoSubStore.SelectedRows.Count < 1)) return;

                SaveHeaderDetail_OtherToSub();
                BalanceProductSubStoreBind();
                lblInvNo.Text = g_controller.FakeGenerateCode("MStore");
                dgvProductInsertIntoSubStore.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private xsdReturn.StoreReturnRow getHeader()
        {
            xsdReturn.StoreReturnRow InvRow = mStore.NewStoreReturnRow();

            InvRow.RetNo = g_controller.AutoGenerateCode("StReturn");

            InvRow.RetDate = DateTime.Now;
            InvRow.Total = Total;


            return InvRow;
        }
        private void SaveHeaderDetail_OtherToSub()
        {
            try
            {
             

                if (MessageBox.Show(this, "Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datarow = getHeader();
                    s_controller.Insert_OtherToSub(datarow, RetProduct);  //StoreInvoiceInsert(datarow, RetProduct);

                    MessageBox.Show("Save Successfully");
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your  product amount is greater than actual product amount of Store");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BalanceProductSubStoreBind();
            AllClear();
        }
        private void AllClear()
        {
            txtCode.Clear();
            txtproductname.Clear();
            txtPrice.Clear();
            txtDescp.Clear();
            txtTotal.Clear();
            RetProduct.Clear();
            dgvProductInsertIntoSubStore.DataSource = null;
            txtCode.Select();
        }

        private void InsertIntoSubStore_FormClosing(object sender, FormClosingEventArgs e)
        {

            MainStore.StoreToSale sts = new MainStore.StoreToSale();
            sts.Show();
        }
    }
}
