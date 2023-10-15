using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.ProductSaleControl;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.FourStepsControls;
using BSSBussinessLogic.ReportingControls;
using BSSBussinessLogic.StoreControls;
using BSSInfo;
using BSSCommon;
using BSSSoftware.Reporting;
namespace BSSSoftware.MainStore
{
    public partial class MainStoreToSubStore : Form
    {
        public MainStoreToSubStore()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private MainStoreControl ms_controller = null;
        private MainStoreToSubStoreControl st_controller = null;
        private StoreProductControl m_controller = null;
        private ProductControl P_controller = null;
        private GeneralControl g_controller = null;

        private string productId = null;

        xsdMainstore.StoreProductInsertDataTable MsToSubStore = null;

        xsdMainstore.MainStoreInvoiceRow datarow = null;
        //xsdSubStore.InvoiceStoreRow datarow = null;

        xsdMainstore.MainStoreInvoiceDataTable mStore = null;
       // xsdSubStore.InvoiceStoreDataTable InvStore = null;

        xsdMainstore.MainStoreInvoiceDetailDataTable mStoreDetail = null;

        int Total = 0;

        AutoCompleteStringCollection CodeAutoCompleteCollection;

        //  private produ

        int Quantity;
        decimal Price, TotalAmount;
        #endregion

        private void btnStoreRecord_Click(object sender, EventArgs e)
        {
            MainStoreRecord mstr = new MainStoreRecord();
            mstr.Show();
            this.Close();
        }

        public void Initializing()
        {
            ms_controller = new MainStoreControl();

            m_controller = new StoreProductControl();
            st_controller = new MainStoreToSubStoreControl();

            P_controller = new ProductControl();
            g_controller = new GeneralControl();

            mStore = new xsdMainstore.MainStoreInvoiceDataTable();
            MsToSubStore = new xsdMainstore.StoreProductInsertDataTable();

            mStoreDetail = new xsdMainstore.MainStoreInvoiceDetailDataTable();
            //datarow = new BSSInfo.MainStore.InvoiceStoreRow();

            lblInvNo.Text = g_controller.FakeGenerateCode("MStore");
            lblDate.Text = DateTime.Now.ToString("dd / MMMM / yyyy");

            BalanceProductMainStoreBind();
            BalanceProductSubStoreBind();
            ProductCodeBinding();
           // this.DataBinding();
        }
        public void DataBinding()
        {
            ProductCodeBinding();
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

        private void BalanceProductMainStoreBind()
        {
            dgvBalanceMainStore.DataSource = ms_controller.MainStoreProductSelect();
            dgvBalanceMainStore.AutoGenerateColumns = false;
        }

        private void BalanceProductSubStoreBind()
        {
            dgvBalanceSubStore.DataSource = st_controller.BalanceStoreProductSelect();
            dgvBalanceSubStore.AutoGenerateColumns = false;
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

        #region dgv properties
        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMainStoreToSubStore.RowCount == 0) return;
            if (e.RowIndex < 0) return;
            string colName = dgvMainStoreToSubStore.Columns[dgvMainStoreToSubStore.CurrentCell.ColumnIndex].Name;
            DataRowView dataRowView = this.dgvMainStoreToSubStore.SelectedRows[0].DataBoundItem as DataRowView;
            if (colName == "colDelete")
            {

                if (dataRowView != null)
                {

                    TotalAmount -= Convert.ToDecimal(dataRowView["Amount"]);
                    txtTotal.Text = string.Format("{0:#,##0} Ks", TotalAmount);
                    dgvMainStoreToSubStore.Rows.RemoveAt(dgvMainStoreToSubStore.CurrentRow.Index);

                }

            }

        }
        private void dgvMainStoreToSubStore_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMainStoreToSubStore.SelectedCells.Count > 0)
                {
                    int SelectIndex = dgvMainStoreToSubStore.SelectedCells[0].RowIndex;

                    if (dgvMainStoreToSubStore.Rows[SelectIndex].Cells["colProductCode"].Value == null) return;
                    DataGridViewRow selectedRow = dgvMainStoreToSubStore.Rows[SelectIndex];

                    string ProductCode = Convert.ToString(selectedRow.Cells["colProductCode"].Value);
                    if (string.IsNullOrEmpty(ProductCode)) return;
                    xsdCodeSetup.ProductRow row = P_controller.SelectByCode(ProductCode);
                    if (row == null) return;
                    dgvMainStoreToSubStore.Rows[SelectIndex].Cells["colProductId"].Value = row.ProductId;
                    dgvMainStoreToSubStore.Rows[SelectIndex].Cells["colProductName"].Value = row.ProductName;
                    //dgvMainStoreToSubStore.Rows[SelectIndex].Cells["colProductPrice"].Value = row.Price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                    xsdMainstore.StoreProductInsertRow s_row = MsToSubStore.NewStoreProductInsertRow();

                    s_row.ProductId = productId;
                    s_row.ProductCode = txtCode.Text;
                    s_row.ProductName = txtproductname.Text;
                    s_row.Total = Convert.ToInt16(txtTotal.Text);

                    //s_row. = Convert.ToInt32(txtPrice.Text);

                    Total += Convert.ToInt16(txtTotal.Text);

                   // txtTotalProduct.Text = Total.ToString();

                    MsToSubStore.AddStoreProductInsertRow(s_row);

                    dgvMainStoreToSubStore.AutoGenerateColumns = false;
                    dgvMainStoreToSubStore.DataSource = MsToSubStore;

                    dgvMainStoreToSubStore.Refresh();
                    textboxClear();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtCode.Select();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvMainStoreToSubStore.SelectedRows == null) || (this.dgvMainStoreToSubStore.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvMainStoreToSubStore.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = MsToSubStore.Rows[dgvMainStoreToSubStore.CurrentCell.RowIndex];

                    Total -= Convert.ToInt32(dr["Total"]);

                  //  txtTotalProduct.Text = Total.ToString();

                    dr.Delete();
                    textboxClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textboxClear()
        {
            txtCode.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            txtDescp.Clear();
            txtproductname.Clear();
        }
        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvMainStoreToSubStore.SelectedRows == null) || (this.dgvMainStoreToSubStore.SelectedRows.Count < 1)) return;

                SaveHeaderDetail();
                BalanceProductMainStoreBind();
                BalanceProductSubStoreBind();
                lblInvNo.Text = g_controller.FakeGenerateCode("MStore");
                dgvMainStoreToSubStore.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveHeaderDetail()
        {
            try
            {
                //if (TheGeek.Controls.ConfirmDialog.Show(//this, "Are you sure to save?", "Confirmation")// == DialogResult.Yes)

                if (MessageBox.Show(this, "Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datarow = getHeader();

                    st_controller.StoreInvoiceInsert(datarow, MsToSubStore);

                    MessageBox.Show("Save Successfully");
                    //Reporting.SaleReport sp = new SaleReport(SaleControl.InvId, txtCash.Text.Trim());
                    //sp.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your  product amount is greater than actual product amount of Store");
            }
        }
        private xsdMainstore.MainStoreInvoiceRow getHeader()
        {
            xsdMainstore.MainStoreInvoiceRow InvRow = mStore.NewMainStoreInvoiceRow();

            InvRow.InvNo = g_controller.AutoGenerateCode("MStore");

            InvRow.InvDate = DateTime.Now;
            InvRow.TotalProduct = Total;
            InvRow.Desp = txtDescp.Text;

            return InvRow;
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

        private void btnreport_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreToSubStoreReport msr = new MainStoreToSubStoreReport();
            msr.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BalanceProductMainStoreBind();
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
            MsToSubStore.Clear();
            dgvMainStoreToSubStore.DataSource = null;
            txtCode.Select();
        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(lblTitle);
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            Utility.Tab( e);
        }
    }
}