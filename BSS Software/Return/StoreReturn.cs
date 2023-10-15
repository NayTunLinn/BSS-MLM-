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
using BSSBussinessLogic.ReportingControls;
using BSSBussinessLogic.ReturnControls;
using BSSInfo;
using BSSCommon;
using BSSSoftware.Reporting;

namespace BSSSoftware.Return
{
    public partial class StoreReturn : Form
    {
        public StoreReturn()
        {
            InitializeComponent();
            Initializing();
        }


        #region Variables
        MainStore.StoreToSale StoreToSale = null;
        private StoreProductControl m_controller = null;
        private SubStoreReturnControl s_controller = null;
        private ProductControl P_controller = null;
        private GeneralControl g_controller = null;

        private string productId = null;

        xsdReturn.InsertProductDataTable RetProduct = null;

        xsdReturn.StoreReturnRow datarow = null;
        //xsdSubStore.InvoiceStoreRow datarow = null;

        xsdReturn.StoreReturnDataTable mStore = null;
        // xsdSubStore.InvoiceStoreDataTable InvStore = null;

        xsdMainstore.MainStoreInvoiceDetailDataTable mStoreDetail = null;

        int Total = 0;

        AutoCompleteStringCollection CodeAutoCompleteCollection;

        //  private produ
        string ReturnType = null;
        #endregion


        public void Initializing()
        {
            m_controller = new StoreProductControl();
            s_controller = new SubStoreReturnControl();
            P_controller = new ProductControl();
            g_controller = new GeneralControl();
            StoreToSale = new MainStore.StoreToSale();
            mStore = new xsdReturn.StoreReturnDataTable();

            RetProduct = new xsdReturn.InsertProductDataTable();

            mStoreDetail = new xsdMainstore.MainStoreInvoiceDetailDataTable();
            //datarow = new BSSInfo.MainStore.InvoiceStoreRow();
            rdoSubToMain.Checked = true;
            lblInvNo.Text = g_controller.FakeGenerateCode("StReturn");
            lblDate.Text = DateTime.Now.ToString("dd / MMMM / yyyy");
            ReturnType = "SubToSale";
            ProductCodeBinding();
            //this.DataBinding();
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



        public void ProductCodeBinding()
        {
            xsdCodeSetup.ProductDataTable dt = P_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["ProductCode"].ToString());
            }
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            StoreToSale.BalanceProductStoreBind();
            StoreToSale.BalanceProductSaleBind();
            StoreToSale.AllClear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCode.Text) || !string.IsNullOrEmpty(txtqty.Text))
                {

                    xsdReturn.InsertProductRow s_row = RetProduct.NewInsertProductRow();

                    s_row.ProductId = productId;
                    s_row.ProductCode = txtCode.Text;
                    s_row.ProductName = txtname.Text;
                    s_row.Total = Convert.ToInt16(txtqty.Text);

                    //s_row. = Convert.ToInt32(txtPrice.Text);

                    Total += Convert.ToInt32(txtqty.Text);

                 
                    RetProduct.AddInsertProductRow(s_row);

                    dgvStoreReturn.AutoGenerateColumns = false;
                    dgvStoreReturn.DataSource = RetProduct;

                    dgvStoreReturn.Refresh();
                    textboxClear();
                    txtCode.Select();
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
                if ((this.dgvStoreReturn.SelectedRows == null) || (this.dgvStoreReturn.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvStoreReturn.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dr = RetProduct.Rows[dgvStoreReturn.CurrentCell.RowIndex];

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
            txtCode.Clear();
            txtqty.Clear();
            
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.dgvStoreReturn.SelectedRows == null) || (this.dgvStoreReturn.SelectedRows.Count < 1)) return;
                if (MessageBox.Show("\" Please Check Your Return Type. \"" + " \n" + lblDisplay.Text, "Sub Store Return", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (ReturnType == "SaleToSub") SaveHeaderDetail_SaleToSub();
                    else SaveHeaderDetail_SubToMain();

                    lblInvNo.Text = g_controller.FakeGenerateCode("StReturn");
                    dgvStoreReturn.ClearSelection();
                }
                StoreToSale.btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveHeaderDetail_SaleToSub()
        {
            try
            {
                //if (TheGeek.Controls.ConfirmDialog.Show(//this, "Are you sure to save?", "Confirmation")// == DialogResult.Yes)

                if (MessageBox.Show(this, "Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datarow = getHeader();
                    s_controller.Insert_SaleToSub(datarow, RetProduct);  //StoreInvoiceInsert(datarow, RetProduct);

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
        private void SaveHeaderDetail_SubToMain()
        {
            try
            {
                //if (TheGeek.Controls.ConfirmDialog.Show(//this, "Are you sure to save?", "Confirmation")// == DialogResult.Yes)

                if (MessageBox.Show(this, "Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datarow = getHeader();
                    s_controller.Insert_SubToMain(datarow, RetProduct);  //StoreInvoiceInsert(datarow, RetProduct);

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

        private xsdReturn.StoreReturnRow getHeader()
        {
            xsdReturn.StoreReturnRow InvRow = mStore.NewStoreReturnRow();

            InvRow.RetNo = g_controller.AutoGenerateCode("StReturn");

            InvRow.RetDate = DateTime.Now;
            InvRow.Total = Total;
           

            return InvRow;
        }
        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.Text)) return;

            xsdSubStore.StoreProductRow productRow = m_controller.SelectByCode(txtCode.Text);

            if (productRow != null)
            {
                this.txtname.Tag = productRow;
                productId = productRow.ProductId;
                txtname.Text = productRow.ProductName;
                txtprice.Text = Convert.ToString(productRow.Price);
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSubToMain.Checked)
            {
                rdoSaleToSub.Checked = false;
                lblDisplay.Text = rdoSubToMain.Text + " Return";
                rdoSubToMain.ForeColor = Color.Blue;
                rdoSaleToSub.ForeColor = Color.White;
                ReturnType = "SubToMain";
            }
            else
            {
                rdoSubToMain.Checked = false;
                rdoSaleToSub.Checked = true;
                lblDisplay.Text = rdoSaleToSub.Text + " Return";
                rdoSaleToSub.ForeColor = Color.Blue;
                rdoSubToMain.ForeColor = Color.White;
                ReturnType = "SaleToSub";
            }
        }

        private void StoreReturn_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(lblDisplay);
            Utility.CenterMyControl(lblTitle);
        }

        private void btnreport_Click(object sender, EventArgs e)
        {

        }

        private void StoreReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
