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
using BSSBussinessLogic.FourStepsControls;
using BSSInfo;
using BSSSoftware.SaleReturnReport;

namespace BSSSoftware.Commession
{
    public partial class Commession_View : Form
    {
        public Commession_View()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variable
        BonusControls b_controller = null;


        private SaleReportControl s_controller = null;

        public AutoCompleteStringCollection UpperNameAutoCompleteCollection = null;
        public AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;
        public AutoCompleteStringCollection InvoiceAutoCompleteCollection = null;
        private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
        private CompanyControl Co_control = null;
        private xsdRegister.MerchantDataTable m_dt = null;
        private xsdRegister.SmallMerchantDataTable sm_dt = null;
        private xsdRegister.WholesaleDataTable w_dt = null;
        private xsdRegister.RetailerDataTable r_dt = null;

        private xsdRegister.MerchantRow m_row = null;
        private xsdRegister.SmallMerchantRow sm_row = null;
        private xsdRegister.WholesaleRow w_row = null;
        private xsdRegister.RetailerRow r_row = null;

        xsdCommession.BonusDetailRow BonusRow;
        xsdCommession.BonusDetailDataTable dataTable;

        string PersonId = null;
        string Title = null;
        DateTime Dt;
        string type;
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

        private void AutoCompleteCodeAllBind()
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

            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        private void AutoCompleteNameAllBind()
        {
            xsdRegister.MerchantDataTable m = m_controller.SelectAll();
            UpperNameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in m.Rows)
            {
                UpperNameAutoCompleteCollection.Add(row["MerchantName"].ToString());
            }
            xsdRegister.SmallMerchantDataTable sm = sm_controller.SelectAll();


            foreach (DataRow row in sm.Rows)
            {
                UpperNameAutoCompleteCollection.Add(row["SmerchantName"].ToString());
            }
            xsdRegister.WholesaleDataTable w = w_controller.SelectAll();

            foreach (DataRow row in w.Rows)
            {
                UpperNameAutoCompleteCollection.Add(row["WsaleName"].ToString());
            }
            xsdRegister.RetailerDataTable r = r_controller.SelectAll();

            foreach (DataRow row in r.Rows)
            {
                UpperNameAutoCompleteCollection.Add(row["RetailerName"].ToString());
            }

            txtName.AutoCompleteCustomSource = UpperNameAutoCompleteCollection;
        }

        public void Initializing()
        {
            s_controller = new SaleReportControl();
            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();
            Co_control = new CompanyControl();
            b_controller = new BonusControls ();

            BindBonusData();
            AutoCompleteCodeAllBind();
            AutoCompleteNameAllBind();
            dtpkDay.Enabled = false;
            dtpkMonth.Enabled = false;

            dataTable = new xsdCommession.BonusDetailDataTable();
            BonusRow = dataTable.NewBonusDetailRow();

            Dt = DateTime.Now;
            type = "Day";
            Title = "Commission Daily Report";
        }

        public void GridViewDataBind()
        {
            dgvBonusDetail.AutoGenerateColumns = false;
            dgvBonusDetail.DataSource = b_controller.SelectByMonth(DateTime.Now);
        }

        private void GridViewBinding()
        {
            BindBonusData();
        }
        private void BindBonusData()
        {
            dgvBonusDetail.DataSource = DBNull.Value;
            dgvBonusDetail.AutoGenerateColumns = false;
            if (cboMonth.Checked)
                dgvBonusDetail.DataSource = b_controller.SelectDetailByMonth(dtpkMonth.Value.Date);
            else if (cboDay.Checked)
                dgvBonusDetail.DataSource = b_controller.SelectDetailByDay(dtpkDay.Value.Date);
            else if(cboFromTo.Checked)
                dgvBonusDetail.DataSource = b_controller.SelectDetailByFromToDate(dtpkFrom.Value.Date, dtpkTo.Value.Date);
            else dgvBonusDetail.DataSource = b_controller.SelectDetailByDay(dtpkDay.Value.Date);

        }
        public void AllDisable()
        {
            dtpkDay.Enabled = false;
            dtpkMonth.Enabled = false;
            dtpkFrom.Enabled = false;
            dtpkTo.Enabled = false;
        }
        private void check(Control ctrl)
        {
            if ((ctrl as CheckBox).Checked)
            {

                switch ((ctrl as CheckBox).Name)
                {
                    case "cboMonth":
                        {
                            
                            dtpkMonth.Enabled = true;

                            cboDay.Checked = false;
                            cboFromTo.Checked = false;

                            dtpkDay.Enabled = false;
                            dtpkFrom.Enabled = false;
                            dtpkTo.Enabled = false;

                            Dt = dtpkMonth.Value.Date;
                            type = "Month";
                            Title = "Commission Monthly Report";
                        } break;
                    case "cboDay":
                        {
                          
                            dtpkDay.Enabled = true;
                           
                            cboMonth.Checked = false;
                            cboFromTo.Checked = false;

                            dtpkMonth.Enabled = false;
                            dtpkFrom.Enabled = false;
                            dtpkTo.Enabled = false;

                            Dt = dtpkDay.Value.Date;
                            type = "Day";
                            Title = "Commission Daily Report";
                        } break;
                    case "cboFromTo":
                        {
                            
                            dtpkFrom.Enabled = true;
                            dtpkTo.Enabled = true;

                            cboMonth.Checked = false;
                            cboDay.Checked = false;

                            dtpkDay.Enabled = false;
                            dtpkMonth.Enabled = false;

                            Dt = dtpkDay.Value.Date;
                            type = "FromTo";
                            Title = "Commission Daily Report";
                        } break;
                }
                BindBonusData();
            }
         
        }
        private void dtpkFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkTo.Value = dtpkFrom.Value;
        }

        private void dtpkTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkFrom.Value > dtpkTo.Value) dtpkFrom.Value = dtpkTo.Value;
        }
        #region Events
        private void dtpkMonth_ValueChanged(object sender, EventArgs e)
        {
            Dt = dtpkMonth.Value.Date;
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
            txtCode.Clear();
            txtName.Clear();
            txtRank.Clear();
            GridViewBinding();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommessionDetail_report cr = new CommessionDetail_report(Dt, type,Title);
            cr.Show(this);
        }

        private void cboTotal_CheckedChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }
        #endregion

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(txtCode.Text))
            {
                btnLevel.PerformClick();
                return;
            }
            GridViewBinding();
        }



        private void dtpkDay_ValueChanged(object sender, EventArgs e)
        {
            Dt = dtpkDay.Value.Date;
            GridViewBinding();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            GridViewBinding();
        }

        private void cboTarget_CheckedChanged(object sender, EventArgs e)
        {
            //if (cboTarget.Checked)
            //{
            //    dgvBonusDetail.AutoGenerateColumns = false;
            //    dgvBonusDetail.DataSource = b_controller.SelectByOverTarget(dtpkMonth.Value);
            //}
            //else btnsearch.PerformClick();
        }

        private void Commession_View_Load(object sender, EventArgs e)
        {

        }
        #region Adding Level Tree
        private void CommessionByLevel()
         {
            b_controller.ClearCommessionByLevel();
            if (string.IsNullOrWhiteSpace(txtCode.Text))
                MerchantLevel();
            else
            {
                switch (txtRank.Text)
                {
                    case "Merchant": MerchantCommession(); break;
                    case "SmallMerchant": SmallMerchantCommession(); break;
                    case "Wholesale": WholesaleCommession(); break;
                    case "Retailer": RetailerCommession(); break;
                }
            }
            dgvBonusDetail.DataSource = b_controller.SelectCommessionByLevel();
        }
        private void MerchantCommession()
        {

            m_row = m_controller.SelectByKey(PersonId);
            if (type == "Day")
                BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, m_row["MerchantId"].ToString());
            else if (type == "FromTo")
                BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value,dtpkTo.Value, m_row["MerchantId"].ToString());
            else
                BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, m_row["MerchantId"].ToString());

            if (!BonusRow.IsPersonIdNull())
            {
                b_controller.CommessionByLevel(BonusRow, dtpkDay.Value);
                SmallMerchantLevel(m_row["MerchantId"].ToString());
            }


        }
        private void SmallMerchantCommession()
        {

            sm_row = sm_controller.SelectByKey(PersonId);
            if (sm_row == null) return;
             if (type == "Day")
                BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, sm_row["SmerchantId"].ToString());
             else if (type == "FromTo")
                 BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, sm_row["SmerchantId"].ToString());
            else
                BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, sm_row["SmerchantId"].ToString());

            if (!BonusRow.IsPersonIdNull())
            {
                b_controller.CommessionByLevel(BonusRow, dtpkDay.Value);
                if (BonusRow != null) WholesaleLevel(sm_row["SmerchantId"].ToString());
            }
        }
        private void WholesaleCommession()
        {

            w_row = w_controller.SelectByKey(PersonId);
            if (w_row == null) return;
             if (type == "Day")
                BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, w_row["WsaleId"].ToString());
             else if (type == "FromTo")
                 BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, w_row["WsaleId"].ToString());
            else
                BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, w_row["WsaleId"].ToString());

            if (!BonusRow.IsPersonIdNull())
            {
                b_controller.CommessionByLevel(BonusRow, dtpkDay.Value.Date);

                RetailerLevel(w_row["WsaleId"].ToString());
            }
        }
        private void RetailerCommession()
        {

            r_row = r_controller.SelectByKey(PersonId);
            if (r_row == null) return;
            if (type == "Day")
                BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, r_row["RetailerId"].ToString());
            else if (type == "FromTo")
                BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, r_row["RetailerId"].ToString());
            else
                BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, r_row["RetailerId"].ToString());

            if (!BonusRow.IsPersonIdNull())
            {
                b_controller.CommessionByLevel(BonusRow, dtpkDay.Value.Date);
            }
        }
        private void MerchantLevel()
        {

            m_dt = m_controller.SelectAll();
            if (m_dt.Rows.Count == 0) return;

            foreach (DataRow dr in m_dt)
            {
                xsdCommession.BonusDetailRow BonusRow = (new xsdCommession.BonusDetailDataTable()).NewBonusDetailRow();
                if (type == "Day")
                    BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, dr["MerchantId"].ToString());
                else if (type == "FromTo")
                    BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, dr["MerchantId"].ToString());
                else
                    BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, dr["MerchantId"].ToString());

                if (!BonusRow.IsPersonIdNull())
                {
                    b_controller.CommessionByLevel(BonusRow, dtpkDay.Value);
                    SmallMerchantLevel(dr["MerchantId"].ToString());
                }
            }
        }
        private void SmallMerchantLevel(string MerchantId)
        {

            sm_dt = sm_controller.SelectByUpperId(MerchantId);
            if (sm_dt.Rows.Count == 0) return;
            foreach (DataRow dr in sm_dt)
            {
                xsdCommession.BonusDetailRow BonusRow = (new xsdCommession.BonusDetailDataTable()).NewBonusDetailRow();
                if (type == "Day")
                    BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, dr["SmerchantId"].ToString());
                else if (type == "FromTo")
                    BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, dr["SmerchantId"].ToString());
                else
                    BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, dr["SmerchantId"].ToString());
              //  MessageBox.Show(dr["SmerchantCode"].ToString() + " " + dr["SmerchantName"].ToString());
              
                if (!BonusRow.IsPersonIdNull()) 
                {
                    b_controller.CommessionByLevel(BonusRow, dtpkDay.Value);
                    WholesaleLevel(dr["SmerchantId"].ToString());
                }
            }
        }

        private void WholesaleLevel(string SmerchantId)
        {
            w_dt = w_controller.SelectByUpperId(SmerchantId);
            if (w_dt.Rows.Count == 0) return;
            foreach (DataRow dr in w_dt)
            {
                xsdCommession.BonusDetailRow BonusRow = (new xsdCommession.BonusDetailDataTable()).NewBonusDetailRow();
                if (type == "Day")
                    BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, dr["WsaleId"].ToString());
                else if (type == "FromTo")
                    BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, dr["WsaleId"].ToString());
                else
                    BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, dr["WsaleId"].ToString());
                if (!BonusRow.IsPersonIdNull())
                {
                    b_controller.CommessionByLevel(BonusRow, dtpkDay.Value.Date);
                    RetailerLevel(dr["WsaleId"].ToString());
                }
            }
        }

        private void RetailerLevel(string WsaleId)
        {
            r_dt = r_controller.SelectByUpperId(WsaleId);
            if (r_dt.Rows.Count == 0) return;
            foreach (DataRow dr in r_dt)
            {
                xsdCommession.BonusDetailRow BonusRow = (new xsdCommession.BonusDetailDataTable()).NewBonusDetailRow();
                if (type == "Day")
                    BonusRow = b_controller.BonusDetailSelectByDayId(dtpkDay.Value, dr["RetailerId"].ToString());
                else if (type == "FromTo")
                    BonusRow = b_controller.BonusDetailSelectByFromToID(dtpkFrom.Value, dtpkTo.Value, dr["RetailerId"].ToString());
                else
                    BonusRow = b_controller.BonusDetailSelectByMonthId(dtpkMonth.Value, dr["RetailerId"].ToString());
                if (!BonusRow.IsPersonIdNull())
                {
                    b_controller.CommessionByLevel(BonusRow, dtpkDay.Value.Date);
                }
            }
        }
        #endregion

        private void btnLevel_Click(object sender, EventArgs e)
        {
            //type = "Level";
            CommessionByLevel();
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            int i = txtCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtCode.Text = (txtCode.Text.Remove(i)).Trim();
            AutoBnding();
        }
        private void AutoBnding()
        {
            try
            {
                string str = txtCode.Text.ToUpper();
                if (string.IsNullOrWhiteSpace(txtCode.Text)) return;
                char ch = str[0];
                switch (ch)
                {
                    case 'A':

                        xsdRegister.MerchantRow m_row = m_controller.SelectByCodeRow(txtCode.Text.Trim());

                        PersonId = m_row.MerchantId;
                        txtCode.Text = m_row.MerchantCode;
                        txtName.Text = m_row.MerchantName;
                        txtRank.Text = m_row.Rank;

                        break;

                    case 'B':

                        xsdRegister.SmallMerchantRow sm_row = sm_controller.SelectByCodeRow(txtCode.Text.Trim());
                        PersonId = sm_row.SmerchantId;
                        txtCode.Text = sm_row.SmerchantCode;
                        txtName.Text = sm_row.SmerchantName;
                        txtRank.Text = sm_row.Rank;
                        break;

                    case 'C':

                        xsdRegister.WholesaleRow w_row = w_controller.SelectByCodeRow(txtCode.Text.Trim());
                        PersonId = w_row.WsaleId;
                        txtCode.Text = w_row.WsaleCode;
                        txtName.Text = w_row.WsaleName;
                        txtRank.Text = w_row.Rank;

                        break;
                    case 'D':

                        xsdRegister.RetailerRow r_row = r_controller.SelectByCodeRow(txtCode.Text.Trim());
                        PersonId = r_row.RetailerId;
                        txtCode.Text = r_row.RetailerCode;
                        txtName.Text = r_row.RetailerName;
                        txtRank.Text = r_row.Rank;

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Please Check  Code Number and Try Again!", "Commession View", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommessionDetail_report cr = new CommessionDetail_report(Dt, type,Title);
            cr.Show(this);
        }

        private void reportByLevelWithTotalAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommessionDetailWithAmout_report cr = new CommessionDetailWithAmout_report(Dt, "Level",Title);
            cr.Show(this);
        }

        private void reportByLevelWithoutAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommessionDetail_report cr = new CommessionDetail_report(Dt, "Level",Title);
            cr.Show(this);
        }


    }
}
