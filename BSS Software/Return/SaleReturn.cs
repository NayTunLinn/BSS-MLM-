using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.FourStepsControls;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.ReportingControls;
using BSSBussinessLogic.ProductSaleControl;
using BSSInfo;
using BSSBussinessLogic.StoreControls;
using BSSCommon;
using BSSBussinessLogic.ReturnControls;
using BSSSoftware.Reporting;

namespace BSSSoftware.Return
{
    

    public partial class SaleReturn : Form
    {

        #region Variables
        private SaleReturnControl S_controller = null;
        private SaleReportControl sr_controller = null;
        private ProductControl P_controller = null;
        private GeneralControl G_controller = null;

        private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
        private CompanyControl Co_control = null;

        StoreToSaleControl st_controller = null;
        private AllProductSummeryControls su_controller = null;
        private CustomerControl c_controller = null;
        string ProductId = null;
        string UpperdistId = null;
        decimal Total = 0;

        bool itclick = false;
        string InvId = null;
        //  string InvId;
        int Quantity;
        decimal Price, TotalAmount;
        string rank;

        xsdRegister.MerchantRow m_row = null;
        xsdRegister.SmallMerchantRow sm_row = null;
        xsdRegister.WholesaleRow w_row = null;
        xsdRegister.RetailerRow r_row = null;
        xsdCodeSetup.CompanyRow co_row = null;

       xsdReturn.SaleReturnInsertDataTable SaleInsertDt = null;
        xsdReturn.SaleReturnInvoiceDataTable InvoiceDT = null;

        AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;
        #endregion

        #region Constructor
        public SaleReturn()
        {
            InitializeComponent();
            Initializing();
        }
        #endregion

        public void Initializing()
        {
            txtUpperDistCode.Select();
            this.dgvSale.ColumnHeadersHeight = 40;
            this.dgvSale.RowTemplate.Height = 35;
            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();
            sr_controller = new SaleReportControl();
            c_controller = new CustomerControl();
            Co_control = new CompanyControl();
            S_controller = new SaleReturnControl();
            P_controller = new ProductControl();
            su_controller = new AllProductSummeryControls();
            G_controller = new GeneralControl();
            SaleInsertDt = new xsdReturn.SaleReturnInsertDataTable();
            InvoiceDT = new xsdReturn.SaleReturnInvoiceDataTable();

            AutoCompleteAllBind();
            st_controller = new StoreToSaleControl();
            lblInvNo.Text = G_controller.FakeGenerateCode("StReturn");
            lblDate.Text = DateTime.Now.ToString("dd / MMMM / yyyy");
            
            MyRefresh();

        }

        private void AutoCompleteAllBind()
        {
            xsdRegister.MerchantDataTable m = m_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in m.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["MerchantCode"].ToString() + "     " + row["MerchantName"].ToString());
            }
            xsdRegister.SmallMerchantDataTable sm = sm_controller.SelectAll();
           

            foreach (DataRow row in sm.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["SmerchantCode"].ToString() + "     " + row["SmerchantName"].ToString());
            }
            xsdRegister.WholesaleDataTable w = w_controller.SelectAll();
           
            foreach (DataRow row in w.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["WsaleCode"].ToString() + "     " + row["WsaleName"].ToString());
            }
            xsdRegister.RetailerDataTable r = r_controller.SelectAll();

            foreach (DataRow row in r.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["RetailerCode"].ToString() + "     " + row["RetailerName"].ToString());
            }

            txtUpperDistCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }

        #region AutoComplete Data Binding

       

        #region Merchant
        private void BindMerchantCode()
        {
            rank = "Merchant";
            xsdRegister.MerchantDataTable dt = m_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["MerchantCode"].ToString() + "     " + row["MerchantName"].ToString());
            }

            txtUpperDistCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }


        #endregion

        #region Small Merchant
        private void BindSmallMerchantCode()
        {
            rank = "SmallMerchant";
            xsdRegister.SmallMerchantDataTable dt = sm_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["SmerchantCode"].ToString() + "     " + row["SmerchantName"].ToString());
            }
            txtUpperDistCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #region Wholesale
        private void BindWholesaleCode()
        {
            rank = "Wholesale";
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["WsaleCode"].ToString() + "     " + row["WsaleName"].ToString());
            }
            txtUpperDistCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #region Retailer
        private void BindRetailerCode()
        {
            rank = "Retailer";
            xsdRegister.RetailerDataTable dt = r_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["RetailerCode"].ToString() + "     " + row["RetailerName"].ToString());
            }
            txtUpperDistCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            CodeSetup.Customer fc = new CodeSetup.Customer();
            fc.Show();
            this.Close();
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

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            Saveing();
            if (string.IsNullOrEmpty(InvId))
            {
                MessageBox.Show("Please Save Firstly");
                return;
            }
            try
            {
              
                Reporting.SaleReport sp = new SaleReport(InvId,"");
                sp.ShowDialog();
                itclick = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SaveHeaderDetail()
        {
            if (string.IsNullOrWhiteSpace(txtUpperDistCode.Text)) return;
            if (string.IsNullOrWhiteSpace(txtUpperDistName.Text)) return;
            try
            {
                if (MessageBox.Show(this, "Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                     xsdReturn.SaleReturnInvoiceRow datarow = getHeader();
                    xsdReturn.SaleReturnInsertDataTable dt = GetItem();
                    InvId = S_controller.Insert(datarow, dt);

                    if (string.IsNullOrEmpty(InvId)) return;
                    else MessageBox.Show("Save Successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private xsdReturn.SaleReturnInvoiceRow getHeader()
        {
            xsdReturn.SaleReturnInvoiceRow InvRow = InvoiceDT.NewSaleReturnInvoiceRow();
                // InvRow.CustomerId = customerId;
            InvRow.UpperDistributerId = UpperdistId;
            InvRow.InvNo = G_controller.AutoGenerateCode("StReturn");
            InvRow.InvDate = DateTime.Now.Date;
            InvRow.Title = "";
            InvRow.TotalAmount = TotalAmount;// Convert.ToDecimal(txtTotal.Text.Trim());
            InvRow.Desp = txtRemark.Text;

            InvRow.UpperDistCode = txtUpperDistCode.Text;
            InvRow.UpperDistName = txtUpperDistName.Text;
            InvRow.IntroName = lblIntroName.Text;
            InvRow.IntroCode = lblIntroCode.Text;

            InvRow.Rank = txtRank.Text;
            return InvRow;
        }

   private   xsdReturn.SaleReturnInsertDataTable GetItem()
        {
            SaleInsertDt = new xsdReturn.SaleReturnInsertDataTable();
            xsdReturn.SaleReturnInsertRow d_row;

            foreach (DataGridViewRow row in dgvSale.Rows)
            {
                d_row = SaleInsertDt.NewSaleReturnInsertRow();

                if (row.Cells["colProductName"].Value == null)
                {
                    break;
                }

                d_row.ProductId = Convert.ToString(row.Cells["colProductId"].Value);
                d_row.ProductPrice = Convert.ToDecimal(row.Cells["colProductPrice"].Value);
                d_row.ProductName = Convert.ToString(row.Cells["colProductName"].Value);
                d_row.ProductCode = Convert.ToString(row.Cells["colProductCode"].Value);
                d_row.Qty = Convert.ToInt32(row.Cells["colProductQty"].Value);
                d_row.Amount = d_row.ProductPrice * d_row.Qty;
                SaleInsertDt.AddSaleReturnInsertRow(d_row);
            }

            return SaleInsertDt;

        }

        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSale.RowCount == 0) return;
            if (e.RowIndex < 0) return;
            string colName = dgvSale.Columns[dgvSale.CurrentCell.ColumnIndex].Name;
            DataRowView dataRowView = this.dgvSale.SelectedRows[0].DataBoundItem as DataRowView;
            if (colName == "colDelete")
            {

                if (dataRowView != null)
                {

                    TotalAmount -= Convert.ToDecimal(dataRowView["Amount"]);
                    txtTotal.Text = string.Format("{0:#,##0} Ks", TotalAmount);
                    dgvSale.Rows.RemoveAt(dgvSale.CurrentRow.Index);
                }
            }
        }

        private void sAVEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutoBnding()
        {
            string Key = null;

            try
            {
                string str = txtUpperDistCode.Text.ToUpper();
                if (string.IsNullOrWhiteSpace(txtUpperDistCode.Text)) return;
                char ch = str[0];
                switch (ch)
                {
                    case 'A':
                        rank = "Merchant";
                        m_row = m_controller.SelectByCodeRow(txtUpperDistCode.Text.Trim());
                        Key = m_row.CompanyId;
                        UpperdistId = m_row.MerchantId;
                        txtUpperDistCode.Text = m_row.MerchantCode;
                        txtUpperDistName.Text = m_row.MerchantName;
                        txtRank.Text = m_row.Rank;


                        co_row = Co_control.SelectByKey(Key);
                        lblIntroCode.Text = co_row.CompanyCode;
                        lblIntroName.Text = co_row.CompanyName;
                        lblIntroRank.Text = co_row.Rank;

                        break;

                    case 'B':
                        rank = "SmallMerchant";
                        sm_row = sm_controller.SelectByCodeRow(txtUpperDistCode.Text.Trim());
                        Key = sm_row.MerchantId;
                        UpperdistId = sm_row.SmerchantId;
                        txtUpperDistCode.Text = sm_row.SmerchantCode;
                        txtUpperDistName.Text = sm_row.SmerchantName;
                        txtRank.Text = sm_row.Rank;

                        m_row = m_controller.SelectByKey(Key);
                        lblIntroCode.Text = m_row.MerchantCode;
                        lblIntroName.Text = m_row.MerchantName;
                        lblIntroRank.Text = m_row.Rank;
                        break;

                    case 'C':
                        rank = "Wholesale";
                        w_row = w_controller.SelectByCodeRow(txtUpperDistCode.Text.Trim());
                        Key = w_row.SmerchantId;
                        UpperdistId = w_row.WsaleId;
                        txtUpperDistCode.Text = w_row.WsaleCode;
                        txtUpperDistName.Text = w_row.WsaleName;
                        txtRank.Text = w_row.Rank;

                        sm_row = sm_controller.SelectByKey(Key);
                        lblIntroCode.Text = sm_row.SmerchantCode;
                        lblIntroName.Text = sm_row.SmerchantName;
                        lblIntroRank.Text = sm_row.Rank;
                        break;
                    case 'D':
                        rank = "Retailer ";
                        r_row = r_controller.SelectByCodeRow(txtUpperDistCode.Text.Trim());
                        Key = r_row.WsaleId;
                        UpperdistId = r_row.RetailerId;
                        txtUpperDistCode.Text = r_row.RetailerCode;
                        txtUpperDistName.Text = r_row.RetailerName;
                        txtRank.Text = r_row.Rank;

                        w_row = w_controller.SelectByKey(Key);
                        lblIntroCode.Text = w_row.WsaleCode;
                        lblIntroName.Text = w_row.WsaleName;
                        lblIntroRank.Text = w_row.Rank;
                        break;

                    default:
                       
                        co_row = Co_control.SelectAllRow();
                        UpperdistId = co_row.CompanyId;
                        txtUpperDistCode.Text = co_row.CompanyCode;
                        txtUpperDistName.Text = co_row.CompanyName;
                        txtRank.Text = co_row.Rank;
                        break;
                }
               
                //cboInvNo.ValueMember = "InvId";
                //cboInvNo.DisplayMember = "InvNo";
                //cboInvNo.DataSource = sr_controller.InvoiceSelectByPersonId(txtUpperDistCode.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Please Check  Code Number and Try Again!", "Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Sale_SizeChanged(object sender, EventArgs e)
        {
           Utility.CenterMyControl(lblTitle);
        }

        private void MyRefresh()
        {
            txtUpperDistCode.Clear();
            txtUpperDistName.Clear();
            txtRank.Clear();
            lblInvNo.Text = G_controller.FakeGenerateCode("Invoice");
            lblIntroCode.Text = "";
            lblIntroName.Text = "";
            lblIntroRank.Text = "";
            txtRemark.Text = "";

            txtTotal.Clear();
            txtCash.Clear();
          
            SaleInsertDt = new xsdReturn.SaleReturnInsertDataTable();
            dgvSale.DataSource = SaleInsertDt;
            dgvSale.Refresh();
            txtUpperDistCode.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSale_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvSale.SelectedCells.Count > 0)
            {
                int SelectIndex = dgvSale.SelectedCells[0].RowIndex;
                if (dgvSale.Rows[SelectIndex].Cells["colProductCode"].Value == DBNull.Value)
                {
                    dgvSale.CurrentCell = dgvSale.Rows[SelectIndex].Cells["colProductCode"];
                    return;
                }
                dgvSale.CurrentCell = dgvSale.Rows[SelectIndex].Cells["colProductQty"];
            }

        }

        #region dgv properties
        private void dgvSale_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvSale.SelectedCells.Count > 0)
                {
                    int SelectIndex = dgvSale.SelectedCells[0].RowIndex;

                    if (dgvSale.Rows[SelectIndex].Cells["colProductCode"].Value == null) return;
                    DataGridViewRow selectedRow = dgvSale.Rows[SelectIndex];

                    string ProductCode = Convert.ToString(selectedRow.Cells["colProductCode"].Value);
                    if (string.IsNullOrEmpty(ProductCode)) return;
                    xsdCodeSetup.ProductRow row = P_controller.SelectByCode(ProductCode);
                    if (row == null) return;
                    dgvSale.Rows[SelectIndex].Cells["colProductId"].Value = row.ProductId;
                    dgvSale.Rows[SelectIndex].Cells["colProductName"].Value = row.ProductName;
                    dgvSale.Rows[SelectIndex].Cells["colProductPrice"].Value = row.Price;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSale_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSale.Rows[e.RowIndex].Cells["colProductCode"].Value == null) return;

            try
            {
                if (dgvSale.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.Equals("colProductQty"))
                {
                    if (dgvSale.Rows[e.RowIndex].Cells["colProductQty"].EditedFormattedValue.ToString() == string.Empty)
                    {
                        dgvSale.Rows[e.RowIndex].Cells["colProductQty"].Value = 0;
                    }
                    Quantity = Convert.ToInt32(dgvSale.Rows[e.RowIndex].Cells["colProductQty"].Value);
                    Price = Convert.ToDecimal(dgvSale.Rows[e.RowIndex].Cells["colProductPrice"].EditedFormattedValue);

                    dgvSale.Rows[e.RowIndex].Cells["colAmount"].Value = Quantity * Price;

                    Show_TotalAmount(e);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Show_TotalAmount(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TotalAmount = 0;

                foreach (DataGridViewRow row in dgvSale.Rows)
                {
                    TotalAmount += Convert.ToDecimal(row.Cells["colAmount"].Value);
                }
                txtTotal.Text = TotalAmount.ToString();
                txtTotal.Text = string.Format("{0:#,##0} Ks", TotalAmount);
            }
        } 
        #endregion

        private void dgvSale_Enter(object sender, EventArgs e)
        {
            AutoBnding();
        }

      

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnPrint.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MyRefresh();
            itclick = false;
        }

        private void btnRetutn_Click(object sender, EventArgs e)
        {
            Return.SaleReturn sr = new Return.SaleReturn();
            sr.Show();
            this.Close();
        }

        private void txtUpperDistCode_Leave(object sender, EventArgs e)
        {
            int i = txtUpperDistCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtUpperDistCode.Text = (txtUpperDistCode.Text.Remove(i)).Trim();

            AutoBnding();
            
        }
        private void Saveing()
        {
            if (itclick == false)
            {
                if (txtTotal.Text == string.Empty) return;
                if (txtUpperDistCode.Text == string.Empty) return;
                SaveHeaderDetail();
                itclick = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Successfully");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Reporting.SaleReport sp = new SaleReport(InvId);
                //sp.ShowDialog();
                itclick = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void SaleReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saveing();
        }
    }
}
