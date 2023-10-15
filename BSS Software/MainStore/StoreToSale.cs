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
    public partial class StoreToSale : Form
    {
        public StoreToSale()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private StoreToSaleControl st_controller = null;
        private StoreProductControl m_controller = null;

        private ProductControl P_controller = null;
        private GeneralControl g_controller = null;

        private string productId = null;

        xsdSubStore.StoreProductInsertDataTable StoreToSaleDT = null;

        xsdSubStore.InvoiceStoreRow datarow = null;
        xsdSubStore.InvoiceStoreDataTable InvStore = null;
        xsdSubStore.InvoiceDetailStoreDataTable invDetailStore = null;

        int Total = 0;

        AutoCompleteStringCollection CodeAutoCompleteCollection;

        //  private produ
        #endregion

        public void Initializing()
        {
            m_controller = new StoreProductControl();
            st_controller = new StoreToSaleControl();
            P_controller = new ProductControl();
            g_controller = new GeneralControl();

            InvStore = new xsdSubStore.InvoiceStoreDataTable();
            StoreToSaleDT = new xsdSubStore.StoreProductInsertDataTable();
            invDetailStore = new xsdSubStore.InvoiceDetailStoreDataTable();
            //datarow = new BSSInfo.MainStore.InvoiceStoreRow();

            lblInvNo.Text = g_controller.FakeGenerateCode("Store");
            lblDate.Text = DateTime.Now.ToString("dd / MMMM / yyyy");

            BalanceProductStoreBind();
            BalanceProductSaleBind();
            ProductCodeBinding();
            cboCategoryBind();
            this.DataBinding();

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
            txtcode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(lblTitle);
        }

        public void BalanceProductStoreBind()
        {
            dgvBalanceStore.DataSource = st_controller.BalanceStoreProductSelect();
            dgvBalanceStore.AutoGenerateColumns = false;
        }
        public void BalanceProductSaleBind()
        {
            dgvBalanceSale.DataSource = st_controller.BalanceSaleProductSelect();
            dgvBalanceSale.AutoGenerateColumns = false;
        }

        private void cboCategoryBind() 
        {
            CategoryControl d_control = new CategoryControl();
            cboCategory.DataSource = d_control.SelectAll();
            cboCategory.DisplayMember = "CategoryType";
            cboCategory.ValueMember = "CategoryType";
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

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null)
            {
                gridView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTotal.Text) < 0) return;
                if (!string.IsNullOrEmpty(txtcode.Text) || !string.IsNullOrEmpty(txtTotal.Text))
                {

                    xsdSubStore.StoreProductInsertRow s_row = StoreToSaleDT.NewStoreProductInsertRow();

                    s_row.ProductId = productId;
                    s_row.ProductCode = txtcode.Text;
                    s_row.ProductName = txtproductname.Text;
                    s_row.Total = Convert.ToInt16(txtTotal.Text);

                    //s_row. = Convert.ToInt32(txtPrice.Text);

                    Total += Convert.ToInt16(txtTotal.Text);

                    StoreToSaleDT.AddStoreProductInsertRow(s_row);
                    dgvStoreToSale.AutoGenerateColumns = false;
                    dgvStoreToSale.DataSource = StoreToSaleDT;

                    dgvStoreToSale.Refresh();
                    textboxClear();
                    txtcode.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvStoreToSale.SelectedRows == null) || (this.dgvStoreToSale.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvStoreToSale.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = StoreToSaleDT.Rows[dgvStoreToSale.CurrentCell.RowIndex];

                    Total -= Convert.ToInt32(dr["Total"]);

              

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
            txtcode.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
           // txtDescp.Clear();
        }
        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvStoreToSale.SelectedRows == null) || (this.dgvStoreToSale.SelectedRows.Count < 1)) return;

                SaveHeaderDetail();

                BalanceProductStoreBind();
                BalanceProductSaleBind();
                lblInvNo.Text = g_controller.FakeGenerateCode("Store");
                dgvStoreToSale.ClearSelection();
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

                    st_controller.StoreInvoiceInsert(datarow, StoreToSaleDT);
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
        private xsdSubStore.InvoiceStoreRow getHeader()
        {
            xsdSubStore.InvoiceStoreRow InvRow = InvStore.NewInvoiceStoreRow();

            InvRow.InvNo = g_controller.AutoGenerateCode("Store");
            InvRow.InvType = cboCategory.SelectedValue.ToString();
            InvRow.InvDate = DateTime.Now;
            InvRow.TotalProduct = Total;
            InvRow.Desp = txtDescp.Text;

            return InvRow;
        }
        private void btnStoreRecord_Click(object sender, EventArgs e)
        {
            StoreRecord sr = new StoreRecord();
            sr.Show();
            this.Close();
        }
        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtcode.Text)) return;

            xsdSubStore.StoreProductRow productRow = m_controller.SelectByCode(txtcode.Text);

            if (productRow != null)
            {
                this.txtproductname.Tag = productRow;
                productId = productRow.ProductId;
                txtproductname.Text = productRow.ProductName;
                txtPrice.Text = Convert.ToString(productRow.Price);
            }
        }

        private void btnreport_Click_1(object sender, EventArgs e)
        {
            StoreToSaleReport str = new StoreToSaleReport();
            str.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Return.StoreReturn rt = new Return.StoreReturn();
            rt.Show();
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            StoerCategory sc = new StoerCategory();
            sc.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BalanceProductStoreBind();
            BalanceProductSaleBind();
            AllClear();
        }
        public void AllClear()
        {
            txtcode.Clear();
            txtproductname.Clear();
            txtPrice.Clear();
            txtDescp.Clear();
            txtTotal.Clear();
            StoreToSaleDT.Clear();
            dgvStoreToSale.DataSource = null;
            txtcode.Select();
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            int i = txtcode.Text.Trim().IndexOf("     ");
            if (i > 0) txtcode.Text = (txtcode.Text.Remove(i)).Trim();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return.StoreReturn rt = new Return.StoreReturn();
            rt.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoerCategory sc = new StoerCategory();
            sc.ShowDialog();
        }

        private void subStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreRecord sr = new StoreRecord();
            sr.Show();
            this.Close();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreToSaleReport str = new StoreToSaleReport();
            str.Show();
        }

        private void btnPdInsert_Click(object sender, EventArgs e)
        {
            MainStore.InsertIntoSubStore sub = new InsertIntoSubStore();
            sub.ShowDialog();
             this.Close();
        }

        private void productInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainStore.InsertIntoSubStore sub = new InsertIntoSubStore();
            sub.ShowDialog( );
            this.Close();
        }
    }
}
