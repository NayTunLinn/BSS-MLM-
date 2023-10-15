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
using BSSInfo;
using BSSCommon;
using BSSBussinessLogic.FourStepsControls;

namespace BSSSoftware.SaleReturnReport
{
    public partial class Bonus_View : Form
    {
   
        public Bonus_View()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variable
        BonusControls b_controller = null;

        private StoreProductControl str_controller = null;
        private SaleReportControl s_controller = null;
        private string productId = null;
        private string recordId = null;
        bool isFirst = true;
        string PostSql = "";
        public AutoCompleteStringCollection UpperNameAutoCompleteCollection = null;
        public AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;
        public AutoCompleteStringCollection InvoiceAutoCompleteCollection = null;
        private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
        private CompanyControl Co_control = null;
        #endregion

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

            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
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
            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
      

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
            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
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
            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
    
        #endregion
        private void MerchantNameBind()
        {
            //rank = "Retailer";
            xsdCodeSetup.BonusNameDataTable dt = b_controller.SelectName();
            UpperNameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperNameAutoCompleteCollection.Add(row["PersonName"].ToString());
            }
            txtName.AutoCompleteCustomSource = UpperNameAutoCompleteCollection;
        }
        #endregion

        private void InvoiceDataBind()
        {
            xsdSaleReport.Invoice_ReportDataTable dt = s_controller.InvoiceSelect();
            InvoiceAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                InvoiceAutoCompleteCollection.Add(row["InvNo"].ToString());
            }
            txtInvNo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtInvNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtInvNo.AutoCompleteCustomSource = InvoiceAutoCompleteCollection;

        }
        public void Initializing()
        {

            s_controller = new SaleReportControl();
            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();
            Co_control = new CompanyControl();
            b_controller = new BonusControls();

            BindBonusData();
            InvoiceDataBind();
            MerchantNameBind();
            dtpkDay.Enabled = false;
            dtpkMonth.Enabled = false;
            dtpkFrom.Enabled = false;
            dtpkTo.Enabled = false;

        }

        public void GridViewDataBind()
        {
            dgvBonusView.AutoGenerateColumns = false;
            dgvBonusView.DataSource = b_controller.SelectByMonth(DateTime.Now);
        }

        private void GridViewBinding()
        {
            GeneralSearch();
            BindBonusData();
        }
        private void BindBonusData()
        {
            dgvBonusView.DataSource = DBNull.Value;
            dgvBonusView.AutoGenerateColumns = false;
            if (cboTotal.Checked) dgvBonusView.DataSource = b_controller.SelectBonusTotal(PostSql);
            else dgvBonusView.DataSource = b_controller.SelectBonusGeneral(PostSql);
        }
        private void GeneralSearch()
        {
            PostSql = "";
            isFirst = true;

            if (!txtCode.Text.Equals(string.Empty))
            {
                if (isFirst)
                {
                    PostSql += " WHERE dbo.Bonus.PersonCode LIKE " + "'%" + txtCode.Text.Trim() + "%'";
                    isFirst = false;
                }
                else
                {
                    PostSql += " AND dbo.Bonus.PersonCode LIKE " + "'%" + txtCode.Text.Trim() + "%'";
                }
            }
            if (!txtName.Text.Equals(string.Empty))
            {
                if (isFirst)
                {
                    PostSql += " WHERE dbo.Bonus.PersonName LIKE " + "'%" + txtName.Text + "%'";
                    isFirst = false;
                }
                else PostSql += " AND dbo.Bonus.PersonName LIKE " + "'%" + txtName.Text + "%'";

            }
            if (cboDay.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where day(dbo.Bonus.Date)='" + dtpkDay.Value.Day + "' and month(dbo.Bonus.Date)='" + dtpkDay.Value.Month + "' and year(dbo.Bonus.Date)='" + dtpkDay.Value.Year + "'";
                    isFirst = false;
                }
                else PostSql += @"AND day(dbo.Bonus.Date)='" + dtpkDay.Value.Day + "' and month(dbo.Bonus.Date)='" + dtpkDay.Value.Month + "' and year(dbo.Bonus.Date)='" + dtpkDay.Value.Year + "'";
            }
            if (cboMonth.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where  month(dbo.Bonus.Date)='" + dtpkMonth.Value.Month + "' and year(dbo.Bonus.Date)='" + dtpkMonth.Value.Year + "'"; isFirst = false;
                }
                else PostSql += @"AND month(dbo.Bonus.Date)='" + dtpkMonth.Value.Month + "' and year(dbo.Bonus.Date)='" + dtpkMonth.Value.Year + "'";
            }
            if (cboFromTo.Checked)
            {
                if (isFirst)
                {
                    PostSql += @" Where dbo.Bonus.Date>='" + dtpkFrom.Value.Date + "' and '" + dtpkTo.Value.Date + "'>=dbo.Bonus.Date"; isFirst = false;
                }

                else PostSql += @"AND dbo.Bonus.Date>='" + dtpkFrom.Value.Date + "' and '" + dtpkTo.Value.Date + "'>=dbo.Bonus.Date";

            }
            
        }

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

        #region Events
        private void dtpkMonth_ValueChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            check((Control)sender);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            BonusReport br = new BonusReport();
            br.ShowDialog();
        }
        private void dtpkFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkTo.Value = dtpkFrom.Value;
        }

        private void dtpkTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkFrom.Value = dtpkTo.Value;
        }

        private void cboTotal_CheckedChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        } 
        #endregion

    

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                btnsearch.PerformClick();
                return;
            }
            string str = txtCode.Text.ToUpper();
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
          GridViewBinding();
        }

          #endregion
        private void dtpkDay_ValueChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void cboTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (cboTarget.Checked)
            {
                dgvBonusView.AutoGenerateColumns = false;
                dgvBonusView.DataSource = b_controller.SelectByOverTarget(dtpkMonth.Value);
            }
            else btnsearch.PerformClick();
        }

        private void txtInvNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInvNo.Text))
            {
                btnsearch.PerformClick();
                return;
            }
            dgvBonusView.AutoGenerateColumns = false;
            dgvBonusView.DataSource = b_controller.SelectByInvNo(txtInvNo.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Commession.Commession_View cm = new Commession.Commession_View();
            cm.Show();
        }


    }
}
