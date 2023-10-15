 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.ReportingControls;
using BSSInfo;
using BSSCommon;
using BSSBussinessLogic.FourStepsControls;

namespace BSSSoftware.SaleReturnReport
{
    public partial class SearchInvoice : Form
    {
        public SearchInvoice()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private StoreProductControl str_controller = null;
        private SaleReportControl s_controller = null;
        private string productId = null;
        private string recordId = null;
        bool isFirst = true;
        string PostSql="";
        public AutoCompleteStringCollection InvoiceAutoCompleteCollection = null;
        public AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;

     private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
        private CompanyControl Co_control = null;

        
        #endregion
        public void Initializing()
        {
            str_controller = new StoreProductControl();
            s_controller = new SaleReportControl();

            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();

            dtpkDay.Enabled = false;
            dtpkMonth.Enabled = false;
            dtpkFrom.Enabled = false;
            dtpkTo.Enabled = false;
            InvoiceDataBind();
            DataBind();
            btnSearch.PerformClick();
        }
        #region AutoComplete Data Binding

        #region Merchant
        private void BindMerchantCode()
        {
            //rank = "Merchant";
            xsdRegister.MerchantDataTable dt = m_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["MerchantCode"].ToString());
            }

            txtMerchantCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }


        #endregion

        #region Small Merchant
        private void BindSmallMerchantCode()
        {
            //rank = "SmallMerchant";
            xsdRegister.SmallMerchantDataTable dt = sm_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["SmerchantCode"].ToString());
            }
            txtMerchantCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #region Wholesale
        private void BindWholesaleCode()
        {
            //rank = "Wholesale";
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["WsaleCode"].ToString());
            }
            txtMerchantCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #region Retailer
        private void BindRetailerCode()
        {
            //rank = "Retailer";
            xsdRegister.RetailerDataTable dt = r_controller.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["RetailerCode"].ToString());
            }
            txtMerchantCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        #endregion

        #endregion

        private void check(Control ctrl)
        {
            if ((ctrl as CheckBox).Checked)
            {

                switch ((ctrl as CheckBox).Name)
                {
                    case "cboMonth":
                        {
                            dtpkDay.Enabled = false;
                            dtpkFrom.Enabled = false;
                            dtpkTo.Enabled = false;
                            dtpkMonth.Enabled = true;

                            cboDay.Checked = false;
                            cboFromTo.Checked = false;
                            // cboMonth.Checked = false;
                        } break;
                    case "cboDay":
                        {
                            dtpkDay.Enabled = true;
                            dtpkFrom.Enabled = false;
                            dtpkTo.Enabled = false;
                            dtpkMonth.Enabled = false;

                            //cboDay.Checked = false;
                            cboFromTo.Checked = false;
                            cboMonth.Checked = false;
                        } break;
                    case "cboFromTo":
                        {
                            dtpkDay.Enabled = false;
                            dtpkFrom.Enabled = true;
                            dtpkTo.Enabled = true;
                            dtpkMonth.Enabled = false;

                            cboDay.Checked = false;
                            //cboFromTo.Checked = false;
                            cboMonth.Checked = false;
                        } break;
                }
            }
            else
            {
                dtpkDay.Enabled = false;
                dtpkFrom.Enabled = false;
                dtpkTo.Enabled = false;
                dtpkMonth.Enabled = false;
            }
        }

        public void DataBind()
        {
            dgvInvoiceView.AutoGenerateColumns = false;
            dgvInvoiceView.DataSource = s_controller.InvoiceSelectByThisMonth();
      
        }

           private void SearchInvoice_SizeChanged(object sender, EventArgs e)
        {

        }

        private void dgvInvoiceView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == -1) return;
           

            string InvId = dgvInvoiceView.Rows[e.RowIndex].Cells["colInvId"].Value.ToString();
            //string status = dgvProperty.Rows[e.RowIndex].Cells[colServiceStatus.Index].Value.ToString();
            dgvInvoiceDetails.AutoGenerateColumns = false;
            dgvInvoiceDetails.DataSource = s_controller.InvoiceDetailsSelectById(InvId);
            //General.ViewProperty p = new General.ViewProperty(propertyId, status);
            //p.ShowDialog(this);

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
                    if (gridView.Name.Equals("dgvInvoiceDetails")) AmountBind(row.Index);
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

        private void AmountBind(int Index)
        {
             DataRowView dataRowView = this.dgvInvoiceDetails.Rows[Index].DataBoundItem as DataRowView;
             if (dataRowView != null)
             {
                 decimal Price = Global.GetDataFromRow<decimal>(dataRowView.Row, "Price", 0);
                 int Qty = Global.GetDataFromRow<int>(dataRowView.Row, "ProductQty", 0);
                 decimal Amount = Price * Qty;
                 dgvInvoiceDetails.Rows[Index].Cells["Amount"].Value= Amount.ToString();
             }

        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvInvoiceView.DataSource = null;
            dgvInvoiceDetails.DataSource = null;
            DataBind();
        }

        private void InvoiceDataBind()
        {
            xsdSaleReport.Invoice_ReportDataTable dt = s_controller.InvoiceSelect();
            InvoiceAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                InvoiceAutoCompleteCollection.Add(row["InvNo"].ToString());
            }
            txtinvoiceno.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtinvoiceno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtinvoiceno.AutoCompleteCustomSource = InvoiceAutoCompleteCollection;
           
        }

        private void txtinvoiceno_TextChanged(object sender, EventArgs e)
        {
        
            txtMerchantCode.Text = string.Empty;
            string str = txtinvoiceno.Text.Trim();
            if (str.Length >= 2) GridViewBinding();
           
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            check((Control)sender);
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewBinding();
          
        }
        private void GridViewBinding()
        {
            GeneralSearch();
            BindInvoice();
        }

        private void BindInvoice()
        {
            dgvInvoiceView.AutoGenerateColumns = false;
            dgvInvoiceView.DataSource = s_controller.InvoiceSelectByGeneral(PostSql);
        }

        private void GeneralSearch()
        {
            PostSql = "";
            isFirst = true;
     
            if (!txtinvoiceno.Text.Equals(string.Empty))
            {
                if (isFirst)
                {
                    PostSql += " WHERE InvNo LIKE" + "'%" + txtinvoiceno.Text.Trim() + "%'";
                    isFirst = false;
                }
                else
                {
                    PostSql += " AND InvNo LIKE" + "'%" + txtinvoiceno.Text.Trim() + "%'";
                }
            }
            if (!txtMerchantCode.Text.Equals(string.Empty))
            {
                if (isFirst)
                {
                    PostSql += " WHERE UpperdistCode LIKE " + "'%" + txtMerchantCode.Text + "%'"; 
                    isFirst = false;
                }
                else PostSql += " AND UpperdistCode LIKE" + "'%" + txtMerchantCode.Text + "%'"; 
                     
            }
            if (cboDay.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where day(InvDate)=" + dtpkDay.Value.Day + " and month(InvDate)=" + dtpkDay.Value.Month + " and year(InvDate)=" + dtpkDay.Value.Year;
                    isFirst = false;
                }
                else PostSql += @"AND day(InvDate)=" + dtpkDay.Value.Day + " and month(InvDate)=" + dtpkDay.Value.Month + " and year(InvDate)=" + dtpkDay.Value.Year;
            }
         if (cboMonth.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where  month(InvDate)=" + dtpkMonth.Value.Month + " and year(InvDate)=" + dtpkMonth.Value.Year; isFirst = false;
                }
                else PostSql += @"AND month(InvDate)=" + dtpkMonth.Value.Month + " and year(InvDate)=" + dtpkMonth.Value.Year;
            }
             if (cboFromTo.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where InvDate>='" + dtpkFrom.Value.Date + "' and '" + dtpkTo.Value.Date + "'>=InvDate"; isFirst = false;
                }

                else PostSql += @"AND InvDate>='" + dtpkFrom.Value.Date + "' and '" + dtpkTo.Value.Date + "'>=InvDate";

            }
            
        }

        private void txtMerchantCode_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dtpkMonth_ValueChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void txtMerchantCode_TextChanged(object sender, EventArgs e)
        {
            txtinvoiceno.Text = string.Empty;
          
            if (string.IsNullOrWhiteSpace(txtMerchantCode.Text)) return;

            string str = txtMerchantCode.Text.ToUpper();
            char ch = str[0];

            switch (ch)
            {
                case 'A':
                    {
                        BindMerchantCode();
                    } break;
                case 'B':
                    {
                        BindSmallMerchantCode();
                    } break;
                case 'C':
                    {
                        BindWholesaleCode();
                    } break;
                case 'D':
                    {
                        BindRetailerCode();
                    } break;
                default:
                    {
                        // add company Code And Name in Upper Distributor
                    } break;

            }
            if (str.Length >2) GridViewBinding();

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaleReturnReport.ReturnInvoiceDetails InvDetail = new ReturnInvoiceDetails();
            InvDetail.Show();
            this.Close();
        }

        private void dtpkFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkTo.Value = dtpkFrom.Value;
        }

        private void dtpkTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkFrom.Value = dtpkTo.Value;
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if ((this.dgvInvoiceView.SelectedRows == null) || (this.dgvInvoiceView.SelectedRows.Count < 1)) return;
             string key="";
            DataRowView dataRowView = this.dgvInvoiceView.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                key = Global.GetDataFromRow<string>(dataRowView.Row, "InvId", string.Empty);
            }
            if (key != string.Empty)
            {
                Reporting.SaleReport sp = new Reporting.SaleReport(key,"Sale");
                sp.ShowDialog();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //ProductSale.InvoiceMasterDetailReport imd = new InvoiceMasterDetailReport();
            //imd.Show(this);
            SaleReturnReport.ReportInvoice ri = new ReportInvoice(PostSql);
            ri.Show(this);
        }

    }
}
