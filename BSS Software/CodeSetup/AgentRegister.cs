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
using BSSInfo;
using BSSCommon;

namespace BSSSoftware.CodeSetup
{
    public partial class AgentRegister : Form
    {
        #region Variables
        private MerchantControl m_controller = null;
        private SMerchantControl sm_controller = null;
        private WholesaleControl w_controller = null;
        private RetailerControl r_controller = null;
        int Index = 0;
        int IndexOfGrid = 0;

        AutoCompleteStringCollection CodeAutoCompleteCollection = null;
        AutoCompleteStringCollection NameAutoCompleteCollection = null;

        string gender = null;
        string key = null;
        string UpperId = null;

        #endregion

        #region Constructor
        public AgentRegister(int _Index)
        {
            InitializeComponent();
            Index = _Index;
            Initializating();
        }
        #endregion


        #region Methods

        public void Initializating()
        {
            m_controller = new MerchantControl();
            sm_controller = new SMerchantControl();
            w_controller = new WholesaleControl();
            r_controller = new RetailerControl();
            GridColumnAdd();
            DataBinding();

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

        #region AutoComplete Data Binding

        #region Merchant
        private void BindMerchantCode()
        {
            xsdRegister.MerchantDataTable dt = m_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["MerchantCode"].ToString() + "     " + row["MerchantName"].ToString());
            }
            txtCodeSearch.AutoCompleteCustomSource = CodeAutoCompleteCollection;
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
           
        }

        private void BindMerchantName()
        {
            xsdRegister.MerchantDataTable dt = m_controller.SelectAll();
            NameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                NameAutoCompleteCollection.Add(row["MerchantName"].ToString());
            }
            txtNameSearch.AutoCompleteCustomSource = NameAutoCompleteCollection;
            txtName.AutoCompleteCustomSource = NameAutoCompleteCollection;
        }
        #endregion

        #region Small Merchant
        private void BindSmallMerchantCode()
        {
            xsdRegister.SmallMerchantDataTable dt = sm_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["SmerchantCode"].ToString() + "     " + row["SmerchantName"].ToString());
            }
            txtCodeSearch.AutoCompleteCustomSource = CodeAutoCompleteCollection;
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
           
        }
        private void BindSmallMerchantName()
        {
            xsdRegister.SmallMerchantDataTable dt = sm_controller.SelectAll();
            NameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                NameAutoCompleteCollection.Add(row["SmerchantName"].ToString());
            }
            txtNameSearch.AutoCompleteCustomSource = NameAutoCompleteCollection;
            txtName.AutoCompleteCustomSource = NameAutoCompleteCollection;
        }
        #endregion

        #region Wholesale
        private void BindWholesaleCode()
        {
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["WsaleCode"].ToString() + "     " + row["WsaleName"].ToString());
            }
            txtCodeSearch.AutoCompleteCustomSource = CodeAutoCompleteCollection;
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
         
        }

        private void BindWholesaleName()
        {
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            NameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                NameAutoCompleteCollection.Add(row["WsaleName"].ToString());
            }
            txtNameSearch.AutoCompleteCustomSource = NameAutoCompleteCollection;
            txtName.AutoCompleteCustomSource = NameAutoCompleteCollection;
        }
        #endregion

        #region Retailer
        private void BindRetailerCode()
        {
            xsdRegister.RetailerDataTable dt = r_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["RetailerCode"].ToString() + "     " + row["RetailerName"].ToString());
            }
            txtCodeSearch.AutoCompleteCustomSource = CodeAutoCompleteCollection;
            txtCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
           
        }
        private void BindRetailerName()
        {
            xsdRegister.RetailerDataTable dt = r_controller.SelectAll();
            NameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                NameAutoCompleteCollection.Add(row["RetailerName"].ToString());
            }
            txtNameSearch.AutoCompleteCustomSource = NameAutoCompleteCollection;
            txtName.AutoCompleteCustomSource = NameAutoCompleteCollection;
        }
        #endregion

        private void AutoCompleteBind()
        {
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        BindMerchantCode();
                        BindMerchantName();
                    } break;
                case "Small Merchant":
                    {
                        BindSmallMerchantCode();
                        BindSmallMerchantName();
                    } break;
                case "Wholesale":
                    {
                        BindWholesaleCode();
                        BindWholesaleName();
                    }
                    break;
                case "Retailer":
                    {
                        BindRetailerCode();
                        BindRetailerName();
                    } break;
                default:
                    {
                        BindMerchantCode();
                        BindMerchantName();
                    } break;
            }
        }
        #endregion


        #region GridColumn

        public void GridDataPropertyAdd()
        {

            #region DataPropertyAdd

            dgvRegister.Columns["colNationalityId"].DataPropertyName = "NationalityId";
            dgvRegister.Columns["colRaceId"].DataPropertyName = "RaceId";
            dgvRegister.Columns["colReligionId"].DataPropertyName = "ReligionId";
            dgvRegister.Columns["colDivId"].DataPropertyName = "DivId";
            dgvRegister.Columns["colCityId"].DataPropertyName = "CityId";


            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        dgvRegister.Columns["colUpperDistId"].DataPropertyName = "CompanyId";
                        dgvRegister.Columns["colId"].DataPropertyName = "MerchantId";
                        dgvRegister.Columns["colImg"].DataPropertyName = "MerchantImg";
                        dgvRegister.Columns["colCode"].DataPropertyName = "MerchantCode";
                        dgvRegister.Columns["colName"].DataPropertyName = "MerchantName";
                        dgvRegister.Columns["colRate"].DataPropertyName = "MerchantRate";
                        dgvRegister.Columns["colUpperDistCode"].DataPropertyName = "CompanyCode";
                        dgvRegister.Columns["colUpperDistName"].DataPropertyName = "CompanyName";
                    } break;
                case "Small Merchant":
                    {
                        dgvRegister.Columns["colUpperDistId"].DataPropertyName = "MerchantId";
                        dgvRegister.Columns["colImg"].DataPropertyName = "SmerchantImg";
                        dgvRegister.Columns["colCode"].DataPropertyName = "SmerchantCode";
                        dgvRegister.Columns["colName"].DataPropertyName = "SmerchantName";
                        dgvRegister.Columns["colRate"].DataPropertyName = "SmerchantRate";
                        dgvRegister.Columns["colUpperDistCode"].DataPropertyName = "MerchantCode";
                        dgvRegister.Columns["colUpperDistName"].DataPropertyName = "MerchantName";
                    } break;
                case "Wholesale":
                    {
                        dgvRegister.Columns["colUpperDistId"].DataPropertyName = "SmerchantId";
                        dgvRegister.Columns["colImg"].DataPropertyName = "WsaleImg";
                        dgvRegister.Columns["colCode"].DataPropertyName = "WsaleCode";
                        dgvRegister.Columns["colName"].DataPropertyName = "WsaleName";
                        dgvRegister.Columns["colRate"].DataPropertyName = "WsaleRate";
                        dgvRegister.Columns["colUpperDistCode"].DataPropertyName = "SmerchantCode";
                        dgvRegister.Columns["colUpperDistName"].DataPropertyName = "SmerchantName";
                    } break;
                case "Retailer":
                    {
                        dgvRegister.Columns["colUpperDistId"].DataPropertyName = "WsaleId";
                        dgvRegister.Columns["colImg"].DataPropertyName = "RetailerImg";
                        dgvRegister.Columns["colCode"].DataPropertyName = "RetailerCode";
                        dgvRegister.Columns["colName"].DataPropertyName = "RetailerName";
                        dgvRegister.Columns["colRate"].DataPropertyName = "RetailerRate";
                        dgvRegister.Columns["colUpperDistCode"].DataPropertyName = "WsaleCode";
                        dgvRegister.Columns["colUpperDistName"].DataPropertyName = "WsaleName";

                    } break;
                default: cboRankSearch.Select(); break;
            }


            dgvRegister.Columns["colNRCNo"].DataPropertyName = "NRCNo";
            dgvRegister.Columns["colFatherName"].DataPropertyName = "FatherName";
            dgvRegister.Columns["colDOB"].DataPropertyName = "DOB";
            dgvRegister.Columns["colNoOfChildren"].DataPropertyName = "NoOfChildren";
            dgvRegister.Columns["colChildDesp"].DataPropertyName = "ChildDesp";
            dgvRegister.Columns["colChildEducation"].DataPropertyName = "ChildEducation";
            dgvRegister.Columns["colGender"].DataPropertyName = "Gender";
            dgvRegister.Columns["colNationality"].DataPropertyName = "Nationality";
            dgvRegister.Columns["colReligion"].DataPropertyName = "Religion";
            dgvRegister.Columns["colRace"].DataPropertyName = "Race";
            dgvRegister.Columns["colDivision"].DataPropertyName = "Division";
            dgvRegister.Columns["colCity"].DataPropertyName = "City";
            dgvRegister.Columns["colAddress"].DataPropertyName = "Address";
            dgvRegister.Columns["colPhone"].DataPropertyName = "Phone";
            dgvRegister.Columns["colEmail"].DataPropertyName = "Email";
            dgvRegister.Columns["colRegDate"].DataPropertyName = "RegDate";
            dgvRegister.Columns["colRank"].DataPropertyName = "Rank";
            dgvRegister.Columns["colDesp"].DataPropertyName = "Desp";

            #endregion
        }
        private void GridColumnAdd()
        {
            #region Colums Add
            //dgvRegister.Columns.
            dgvRegister.Columns.Add("colId", "Id");
            dgvRegister.Columns.Add("colUpperDistId", "UpperDistId");
            dgvRegister.Columns.Add("colNationalityId", "NationalityId");
            dgvRegister.Columns.Add("colRaceId", "RaceId");
            dgvRegister.Columns.Add("colReligionId", "ReligionId");
            dgvRegister.Columns.Add("colDivId", "DivId");
            dgvRegister.Columns.Add("colCityId", "CityId");
            dgvRegister.Columns.Add("colImg", "Img");
            dgvRegister.Columns.Add("colCode", "Code");
            dgvRegister.Columns.Add("colName", "Name");
            /// to Move
            dgvRegister.Columns.Add("colNRCNo", "N.R.C No");
            /////
          
            ////
            dgvRegister.Columns.Add("colUpperDistCode", "Upper Code");
            dgvRegister.Columns.Add("colUpperDistName", "Upper Name");
            ////
            dgvRegister.Columns.Add("colAddress", "Address");
            dgvRegister.Columns.Add("colPhone", "Phone");
            dgvRegister.Columns.Add("colGender", "Gender");
            dgvRegister.Columns.Add("colFatherName", "Father Name");
            dgvRegister.Columns.Add("colDOB", "D.O.B");
           
            dgvRegister.Columns.Add("colNationality", "Nationality");
            dgvRegister.Columns.Add("colReligion", "Religion");
            dgvRegister.Columns.Add("colRace", "Race");
            dgvRegister.Columns.Add("colEmail", "Email");
            dgvRegister.Columns.Add("colNoOfChildren", "No Of Children");
            dgvRegister.Columns.Add("colChildDesp", "Children Name");
            dgvRegister.Columns.Add("colChildEducation", "Children Edu;");
            dgvRegister.Columns.Add("colDivision", "Division");
            dgvRegister.Columns.Add("colCity", "City");
          
            dgvRegister.Columns.Add("colRegDate", "Reg Date");
            dgvRegister.Columns.Add("colDesp", "Description");
            dgvRegister.Columns.Add("colRate", "Rate");
            dgvRegister.Columns.Add("colRank", "Rank");


            dgvRegister.Columns["colNationalityId"].Visible = false;
            dgvRegister.Columns["colRaceId"].Visible = false;
            dgvRegister.Columns["colReligionId"].Visible = false;
            dgvRegister.Columns["colDivId"].Visible = false;
            dgvRegister.Columns["colCityId"].Visible = false;
            dgvRegister.Columns["colUpperDistId"].Visible = false;
            dgvRegister.Columns["colImg"].Visible = false;
            dgvRegister.Columns["colRank"].Visible = false;
            dgvRegister.Columns["colId"].Visible = false;

            dgvRegister.Columns["colName"].Width = 150;
            dgvRegister.Columns["colUpperDistName"].Width = 150;
            dgvRegister.Columns["colFatherName"].Width = 150;
            dgvRegister.Columns["colDesp"].Width = 300;
            dgvRegister.Columns["colPhone"].Width = 150;
            dgvRegister.Columns["colDOB"].Width = 150;
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Format = "dd - MMMM- yyyy";
            dgvRegister.Columns["colDOB"].DefaultCellStyle = dataGridViewCellStyle3;
            dgvRegister.Columns["colRegDate"].Width = 150;
            dgvRegister.Columns["colAddress"].Width = 300;
            dgvRegister.Columns["colNRCNo"].Width = 150;
            dgvRegister.Columns["colEmail"].Width = 150;

            #endregion
        }

        #endregion

        #region Combo DataBinding
        public void DataBinding()
        {
            DivisionBind();
            BindCity();
            NationalityBind();
            ReligionBind();
            RaceBind();
            RankDataBind();
            AutoCompleteBind();
            GridViewDataBind();

        }
        public void GridViewDataBind()
        {

           
            AutoCompleteBind();
            dgvRegister.AutoGenerateColumns = false;
            GridDataPropertyAdd();
            //DataTable dt = new DataTable();
            //dt =(DataTable) dgvRegister.DataSource;
            //if (dgvRegister.DataSource==null)
            //{
            //    dgvRegister.DataSource = new object();
            // // IndexOfGrid = dgvRegister.SelectedRows[0].Index;
            //  //  MessageBox.Show(dgvRegister.DataSource.ToString());
            //}
            //if (dgvRegister.DataSource != null)
            //{
            //    // IndexOfGrid = dgvRegister.SelectedRows[0].Index;
                
            //}
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        dgvRegister.DataSource = m_controller.SelectAll();
                    } break;
                case "Small Merchant":
                    {
                        dgvRegister.DataSource = sm_controller.SelectAll();
                    } break;
                case "Wholesale":
                    {
                        dgvRegister.DataSource = w_controller.SelectAll();
                    }
                    break;
                case "Retailer":
                    {
                        dgvRegister.DataSource = r_controller.SelectAll();
                    } break;
                default:
                    {
                        dgvRegister.DataSource = m_controller.SelectAll();
                    } break;
            }
           // dgvRegister.Rows[IndexOfGrid].Selected = true;
            //dgvRegister.se
           // dgvRegister.Rows[Index].Selected = true;
          //  dataGridView1.ClearSelection();//If you want

            int nRowIndex = dgvRegister.Rows.Count - 1;
          //  int nColumnIndex = 3;

            //dgvRegister.Rows[nRowIndex].Selected = true;
           // dgvRegister.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            //dgvRegister.Rows[nRowIndex].Selected = true;
            //In case if you want to scroll down as well.
            dgvRegister.FirstDisplayedScrollingRowIndex = nRowIndex;
        }
        public void GridViewDataBindByName()
        {
            if (string.IsNullOrEmpty(txtNameSearch.Text))
            {
                dgvRegister.DataSource = null;
                return;
            }
            dgvRegister.AutoGenerateColumns = false;
            GridDataPropertyAdd();
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        dgvRegister.DataSource = m_controller.SelectByName(txtNameSearch.Text.Trim());
                    } break;
                case "Small Merchant":
                    {
                        dgvRegister.DataSource = sm_controller.SelectByName(txtNameSearch.Text.Trim());
                    } break;
                case "Wholesale":
                    {
                        dgvRegister.DataSource = w_controller.SelectByName(txtNameSearch.Text.Trim());
                    }
                    break;
                case "Retailer":
                    {
                        dgvRegister.DataSource = r_controller.SelectByName(txtNameSearch.Text.Trim());
                    } break;
                default:
                    {
                        dgvRegister.DataSource = m_controller.SelectAll();
                    } break;
            }

        }
        public void GridViewDataBindByCode()
        {
            if (string.IsNullOrEmpty(txtCodeSearch.Text))
            {
                dgvRegister.DataSource = null;
                return;
            }
            dgvRegister.AutoGenerateColumns = false;
            GridDataPropertyAdd();
            dgvRegister.DataSource = null;
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        dgvRegister.DataSource = m_controller.SelectByCode(txtCodeSearch.Text.Trim());
                    } break;
                case "Small Merchant":
                    {
                        dgvRegister.DataSource = sm_controller.SelectByCode(txtCodeSearch.Text.Trim());
                    } break;
                case "Wholesale":
                    {
                        dgvRegister.DataSource = w_controller.SelectByCode(txtCodeSearch.Text.Trim());
                    }
                    break;
                case "Retailer":
                    {
                        dgvRegister.DataSource = r_controller.SelectByCode(txtCodeSearch.Text.Trim());
                    } break;
                default:
                    {
                        dgvRegister.DataSource = m_controller.SelectAll();
                    } break;
            }

        }
        private void RankDataBind()
        {
            string[] Rank = new string[4];
            Rank[0] = "Merchant";
            Rank[1] = "Small Merchant";
            Rank[2] = "Wholesale";
            Rank[3] = "Retailer";
            cboAgentRank.Items.AddRange(Rank);
            cboRankSearch.Items.AddRange(Rank);

            cboRankSearch.SelectedIndex = Index;
            cboAgentRank.SelectedIndex = cboRankSearch.SelectedIndex;
        }
        private void DivisionBind()
        {
            DivisionControl type_Ctrl = new DivisionControl();
            this.cboDivision.DisplayMember = "Division";
            this.cboDivision.ValueMember = "DivId";
            this.cboDivision.DataSource = type_Ctrl.SelectAll();
        }
        private void CityEditBind(string DivId)
        {
            CityControl c = new CityControl();
            cboCity.ValueMember = "CityID";
            cboCity.DisplayMember = "City";
            cboCity.DataSource = c.SelectByKey(DivId);
        }
        private void CityBind()
        {
            CityControl c = new CityControl();
            cboCity.ValueMember = "CityID";
            cboCity.DisplayMember = "City";
            cboCity.DataSource = c.SelectByKey(cboDivision.SelectedValue.ToString());
           
        }
        private void BindCity()
        {
            if (cboDivision.Items.Count == 0)
            {
                cboCity.DataSource = null;
                return;
            }
            CityControl city = new CityControl();
            xsdCodeSetup.CityDataTable dt = city.SelectByKey(cboDivision.SelectedValue.ToString());

            cboCity.DataSource = dt;
            cboCity.DisplayMember = "City";
            cboCity.ValueMember = "CityId";

        }
        private void NationalityBind()
        {
            NationalityControl type_Ctrl = new NationalityControl();
            this.cboNationality.DisplayMember = "Nationality";
            this.cboNationality.ValueMember = "NationalityId";
            this.cboNationality.DataSource = type_Ctrl.SelectAll();
        }
        private void ReligionBind()
        {
            ReligionControl type_Ctrl = new ReligionControl();
            this.cboReligion.DisplayMember = "Religion";
            this.cboReligion.ValueMember = "ReligionId";
            this.cboReligion.DataSource = type_Ctrl.SelectAll();
        }
        private void RaceBind()
        {
            RaceControl type_Ctrl = new RaceControl();
            this.cboRace.DisplayMember = "Race";
            this.cboRace.ValueMember = "RaceId";
            this.cboRace.DataSource = type_Ctrl.SelectAll();
        }
        #endregion

        #region Saving Code
        public void MerchantSave()
        {
            xsdRegister.MerchantRow dataRow = (new xsdRegister.MerchantDataTable()).NewMerchantRow();
            try
            {
                dataRow.CompanyId = UpperId;
                dataRow.MerchantImg = new byte[0];
                dataRow.MerchantCode = txtCode.Text.Trim();
                dataRow.MerchantName = txtName.Text.Trim();
                dataRow.MerchantRate = txtRate.Text.Trim();
                dataRow.NRCNo = txtNRCNO.Text.Trim();
                dataRow.FatherName = txtFatherName.Text.Trim();
                if (rdoMale.Checked) dataRow.Gender = "Male";
                else dataRow.Gender = "Female";
                dataRow.DOB = dtpkDOB.Value;
                dataRow.NationalityId = cboNationality.SelectedValue.ToString();
                dataRow.ReligionId = cboReligion.SelectedValue.ToString();
                dataRow.RaceId = cboRace.SelectedValue.ToString();
                dataRow.NoOfChildren = Convert.ToInt32(numericUpDownNoOfChild.Value);
                dataRow.ChildDesp = txtChildrenName.Text.Trim();
                dataRow.ChildEducation = "";//Trim();
                dataRow.Phone = txtPhone.Text.Trim();
                dataRow.DivId = cboDivision.SelectedValue.ToString();
                dataRow.CityId = cboCity.SelectedValue.ToString();
                dataRow.Address = txtAddress.Text.Trim();
                dataRow.Email = txtEmail.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();
                dataRow.RegDate = dtpkRegDate.Value;

                if (string.IsNullOrEmpty(key))
                    this.m_controller.Insert(dataRow);
                else
                {
                    dataRow.MerchantId = key;
                    this.m_controller.Update(dataRow);
                    //this.btnNew.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public void SmallMerchantSave()
        {
            xsdRegister.SmallMerchantRow dataRow = (new xsdRegister.SmallMerchantDataTable()).NewSmallMerchantRow();
            try
            {

                dataRow.MerchantId = UpperId;
                dataRow.SmerchantImg = new byte[0];
                dataRow.SmerchantCode = txtCode.Text.Trim();
                dataRow.SmerchantName = txtName.Text.Trim();
                dataRow.SmerchantRate = txtRate.Text.Trim();
                dataRow.NRCNo = txtNRCNO.Text.Trim();
                dataRow.FatherName = txtFatherName.Text.Trim();
                if (rdoMale.Checked) dataRow.Gender = "Male";
                else dataRow.Gender = "Female";
                dataRow.DOB = dtpkDOB.Value.Date;
                dataRow.NationalityId = cboNationality.SelectedValue.ToString();
                dataRow.ReligionId = cboReligion.SelectedValue.ToString();
                dataRow.RaceId = cboRace.SelectedValue.ToString();
                dataRow.NoOfChildren = Convert.ToInt32(numericUpDownNoOfChild.Value);
                dataRow.ChildDesp = txtChildrenName.Text.Trim();
                dataRow.ChildEducation = "";//Trim();
                dataRow.Phone = txtPhone.Text.Trim();
                dataRow.DivId = cboDivision.SelectedValue.ToString();
                dataRow.CityId = cboCity.SelectedValue.ToString();
                dataRow.Address = txtAddress.Text.Trim();
                dataRow.Email = txtEmail.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();
                dataRow.RegDate = dtpkRegDate.Value;

                if (string.IsNullOrEmpty(key))
                    this.sm_controller.Insert(dataRow);
                else
                {
                    dataRow.SmerchantId = key;
                    this.sm_controller.Update(dataRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        public void WholesaleSave()
        {
            xsdRegister.WholesaleRow dataRow = (new xsdRegister.WholesaleDataTable()).NewWholesaleRow();
            try
            {

                dataRow.SmerchantId = UpperId;
                dataRow.WsaleImg = new byte[0];
                dataRow.WsaleCode = txtCode.Text.Trim();
                dataRow.WsaleName = txtName.Text.Trim();
                dataRow.WsaleRate = txtRate.Text.Trim();
                dataRow.NRCNo = txtNRCNO.Text.Trim();
                dataRow.FatherName = txtFatherName.Text.Trim();
                if (rdoMale.Checked) dataRow.Gender = "Male";
                else dataRow.Gender = "Female";
                dataRow.DOB = dtpkDOB.Value;
                dataRow.NationalityId = cboNationality.SelectedValue.ToString();
                dataRow.ReligionId = cboReligion.SelectedValue.ToString();
                dataRow.RaceId = cboRace.SelectedValue.ToString();
                dataRow.NoOfChildren = Convert.ToInt32(numericUpDownNoOfChild.Value);
                dataRow.ChildDesp = txtChildrenName.Text.Trim();
                dataRow.ChildEducation = "";//Trim();
                dataRow.Phone = txtPhone.Text.Trim();
                dataRow.DivId = cboDivision.SelectedValue.ToString();
                dataRow.CityId = cboCity.SelectedValue.ToString();
                dataRow.Address = txtAddress.Text.Trim();
                dataRow.Email = txtEmail.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();
                dataRow.RegDate = dtpkRegDate.Value;

                if (string.IsNullOrEmpty(key))
                    this.w_controller.Insert(dataRow);
                else
                {
                    dataRow.WsaleId = key;
                    this.w_controller.Update(dataRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void RetailerSave()
        {
            xsdRegister.RetailerRow dataRow = (new xsdRegister.RetailerDataTable()).NewRetailerRow();
            try
            {
                dataRow.WsaleId = UpperId;
                dataRow.RetailerImg = new byte[0];
                dataRow.RetailerCode = txtCode.Text.Trim();
                dataRow.RetailerName = txtName.Text.Trim();
                dataRow.RetailerRate = txtRate.Text.Trim();
                dataRow.NRCNo = txtNRCNO.Text.Trim();
                dataRow.FatherName = txtFatherName.Text.Trim();
                if (rdoMale.Checked) dataRow.Gender = "Male";
                else dataRow.Gender = "Female";
                dataRow.DOB = dtpkDOB.Value;
                dataRow.NationalityId = cboNationality.SelectedValue.ToString();
                dataRow.ReligionId = cboReligion.SelectedValue.ToString();
                dataRow.RaceId = cboRace.SelectedValue.ToString();
                dataRow.NoOfChildren = Convert.ToInt32(numericUpDownNoOfChild.Value);
                dataRow.ChildDesp = txtChildrenName.Text.Trim();
                dataRow.ChildEducation = "";//Trim();
                dataRow.Phone = txtPhone.Text.Trim();
                dataRow.DivId = cboDivision.SelectedValue.ToString();
                dataRow.CityId = cboCity.SelectedValue.ToString();
                dataRow.Address = txtAddress.Text.Trim();
                dataRow.Email = txtEmail.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();
                dataRow.RegDate = dtpkRegDate.Value;

                if (string.IsNullOrEmpty(key))
                    this.r_controller.Insert(dataRow);
                else
                {
                    dataRow.RetailerId = key;
                    this.r_controller.Update(dataRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        #endregion

        public void Save()
        {

            if (string.IsNullOrWhiteSpace(txtUpperName.Text))
            {
                Utility.ToolTipControl("please fill the Upper Name ", txtUpperName);
                txtUpperName.Focus();
                return;
            } 
           
            if (string.IsNullOrWhiteSpace(txtUpperCode.Text))
            {
                Utility.ToolTipControl("please fill the Upper Code ", txtUpperCode);
                txtUpperCode.Focus();
                return;
            } 
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                Utility.ToolTipControl("please fill the Code ", txtCode);
                txtCode.Focus();
                return;
            } 
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Utility.ToolTipControl("please fill the Name ", txtUpperCode);
                txtUpperCode.Focus();
                return;
            } 
            switch (cboAgentRank.SelectedItem.ToString())
            {
                case "Merchant": MerchantSave(); break;
                case "Small Merchant": SmallMerchantSave(); break;
                case "Wholesale": WholesaleSave(); break;
                case "Retailer": RetailerSave(); break;
                default: cboAgentRank.Select(); break;
            }
        }

        public void Delete(string key)
        {
            if (key.Equals(null)) return;
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant": this.m_controller.Delete(key); break;
                case "Small Merchant": this.sm_controller.Delete(key); break;
                case "Wholesale": this.w_controller.Delete(key); break;
                case "Retailer": this.r_controller.Delete(key); break;
                default: cboRankSearch.Select(); break;
            }
        }
        #endregion

        #region Events
        private void txtUpperCode_Validated(object sender, EventArgs e)
        {
            int i = txtUpperCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtUpperCode.Text = (txtUpperCode.Text.Remove(i)).Trim();
        }
        private void General_Tab(object sender, KeyEventArgs e)
        {
            Utility.Tab(e);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            key = null;
            txtCode.Enabled = true;
            txtUpperCode.Enabled = true;
            Utility.AllClear(this.panelEntry);
            txtUpperCode.Clear();
            txtUpperName.Clear();
            txtUpperRank.Clear();
            AutoCompleteBind();
            showPrefix();
          
                    if(cboRankSearch.SelectedItem.ToString()=="Merchant")
                    {
                        CompanyControl c_control = new CompanyControl();
                        xsdCodeSetup.CompanyRow personRow = c_control.SelectAllRow();
                        if (personRow != null)
                        {
                            this.txtUpperName.Tag = personRow;
                            UpperId = personRow.CompanyId;
                            txtUpperName.Text = personRow.CompanyName;
                            txtUpperRank.Text = personRow.Rank;
                            txtUpperCode.Text = personRow.CompanyCode;
                        }
                    }
            Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Save();
                GridViewDataBind();
                btnNew.Focus();
            }
        }

        private void cboDivision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboCity.DataSource = null;
            CityBind();
        }
        string cityid, divid,nationality,race,religion;
        private void btnEdit_Click(object sender, EventArgs e)
        {
           txtCode.Enabled = false;
           txtUpperCode.Enabled = false;
            Utility.AllClear(this.panelEntry);
            AutoCompleteBind();
          
            if ((this.dgvRegister.SelectedRows == null) || (this.dgvRegister.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvRegister.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {

                switch (cboRankSearch.SelectedItem.ToString())
                {
                    case "Merchant":
                        {
                            UpperId = Global.GetDataFromRow<string>(dataRowView.Row, "CompanyId", string.Empty);
                            CompanyControl c_controller = new CompanyControl();
                            xsdCodeSetup.CompanyRow m_row = c_controller.SelectAllRow();
                            this.txtUpperCode.Text = Global.GetDataFromRow<string>(m_row, "CompanyCode", string.Empty);
                            this.txtUpperName.Text = Global.GetDataFromRow<string>(m_row, "CompanyName", string.Empty);
                            this.txtUpperRank.Text = Global.GetDataFromRow<string>(m_row, "Rank", string.Empty);

                            key = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantId", string.Empty);
                            this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantCode", string.Empty);
                            this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantName", string.Empty);
                            this.txtRate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantRate", string.Empty);
                        } break;
                    case "Small Merchant":
                        {
                            UpperId = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantId", string.Empty);
                            xsdRegister.MerchantRow m_row = m_controller.SelectByKey(UpperId);
                            this.txtUpperCode.Text = Global.GetDataFromRow<string>(m_row, "MerchantCode", string.Empty);
                            this.txtUpperName.Text = Global.GetDataFromRow<string>(m_row, "MerchantName", string.Empty);
                            this.txtUpperRank.Text = Global.GetDataFromRow<string>(m_row, "Rank", string.Empty);

                            key = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantId", string.Empty);
                            this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantCode", string.Empty);
                            this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantName", string.Empty);
                            this.txtRate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantRate", string.Empty);
                        } break;
                    case "Wholesale":
                        {
                            UpperId = Global.GetDataFromRow<string>(dataRowView.Row, "SmerchantId", string.Empty);
                            xsdRegister.SmallMerchantRow m_row = sm_controller.SelectByKey(UpperId);
                            this.txtUpperCode.Text = Global.GetDataFromRow<string>(m_row, "SmerchantCode", string.Empty);
                            this.txtUpperName.Text = Global.GetDataFromRow<string>(m_row, "SmerchantName", string.Empty);
                            this.txtUpperRank.Text = Global.GetDataFromRow<string>(m_row, "Rank", string.Empty);

                            key = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleId", string.Empty);
                            this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleCode", string.Empty);
                            this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleName", string.Empty);
                            this.txtRate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleRate", string.Empty);
                        } break;
                    case "Retailer":
                        {
                            UpperId = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleId", string.Empty);
                            xsdRegister.WholesaleRow m_row = w_controller.SelectByKey(UpperId);
                            this.txtUpperCode.Text = Global.GetDataFromRow<string>(m_row, "WsaleCode", string.Empty);
                            this.txtUpperName.Text = Global.GetDataFromRow<string>(m_row, "WsaleName", string.Empty);
                            this.txtUpperRank.Text = Global.GetDataFromRow<string>(m_row, "Rank", string.Empty);

                            key = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerId", string.Empty);
                            this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerCode", string.Empty);
                            this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerName", string.Empty);
                            this.txtRate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerRate", string.Empty);
                        } break;
                }

                this.txtFatherName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "FatherName", string.Empty);
                this.txtNRCNO.Text = Global.GetDataFromRow<string>(dataRowView.Row, "NRCNo", string.Empty);
                string gender = Global.GetDataFromRow<string>(dataRowView.Row, "Gender", string.Empty);
                if (gender.Equals("Male")) rdoMale.Checked = true;
                else rdoFemale.Checked = true;
                this.dtpkDOB.Value = Global.GetDataFromRow<DateTime>(dataRowView.Row, "DOB", DateTime.Now);
                nationality = Global.GetDataFromRow<string>(dataRowView.Row, "NationalityId", string.Empty);
                religion = Global.GetDataFromRow<string>(dataRowView.Row, "ReligionId", string.Empty);
                race = Global.GetDataFromRow<string>(dataRowView.Row, "RaceId", string.Empty);
                this.numericUpDownNoOfChild.Value = Global.GetDataFromRow<int>(dataRowView.Row, "NoOfChildren", 0);
                this.txtChildrenName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ChildDesp", string.Empty);
               // this.txtChildrenEdu.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ChildEducation", string.Empty);
                this.txtPhone.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Phone", string.Empty);
                //DivisionBind();
                 divid= Global.GetDataFromRow<string>(dataRowView.Row, "DivId", string.Empty);
               // BindCity();
                 cityid = Global.GetDataFromRow<string>(dataRowView.Row, "CityId", string.Empty);
               // UpdateDiv_City(divid, cityid);
                this.txtAddress.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Address", string.Empty);
                this.txtEmail.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Email", string.Empty);
                this.txtDesp.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Desp", string.Empty);
                this.dtpkRegDate.Value = Global.GetDataFromRow<DateTime>(dataRowView.Row, "RegDate", DateTime.Now);
                Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
                panelEntry_Paint();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Save();
                  
                    GridViewDataBind();
                    btnNew.Focus();

                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete This Person?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    if ((this.dgvRegister.SelectedRows == null) || (this.dgvRegister.SelectedRows.Count < 1)) return;
                    DataRowView dataRowView = this.dgvRegister.SelectedRows[0].DataBoundItem as DataRowView;
                    if (dataRowView != null)
                    {
                        string columnId = null;
                        switch (cboRankSearch.SelectedItem.ToString())
                        {
                            case "Merchant": columnId = "MerchantId"; break;
                            case "Small Merchant": columnId = "SmerchantId"; break;
                            case "Wholesale": columnId = "WsaleId"; break;
                            case "Retailer": columnId = "RetailerId"; break;
                            default: cboRankSearch.Select(); break;
                        }
                        key = Global.GetDataFromRow<string>(dataRowView.Row, columnId, string.Empty);
                    }
                    this.Delete(key);
                    GridViewDataBind();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("This person is being used in Other table");
                }
            }
        }
        private void txtMerchantCode_KeyDown(object sender, KeyEventArgs e)
        {
            Utility.Tab(e);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAgentRank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboRankSearch.SelectedIndex = cboAgentRank.SelectedIndex;
            AutoCompleteBind();
            showPrefix();
            GridViewDataBind();

        }

        public void showPrefix()
        {
            string prefix;
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        prefix = "A";
                        if (!txtCode.Text.StartsWith(prefix))
                        {
                            txtCode.Text = prefix;
                            txtCode.SelectionStart = txtCode.Text.Length;
                        }
                    } break;
                case "Small Merchant":
                    {
                        prefix = "B";
                        if (!txtCode.Text.StartsWith(prefix))
                        {
                            txtCode.Text = prefix;
                            txtCode.SelectionStart = txtCode.Text.Length;
                        }
                    } break;
                case "Wholesale":
                    {
                        prefix = "C";
                        if (!txtCode.Text.StartsWith(prefix))
                        {
                            txtCode.Text = prefix;
                            txtCode.SelectionStart = txtCode.Text.Length;
                        }
                    } break;
                case "Retailer":
                    {
                        prefix = "D";
                        if (!txtCode.Text.StartsWith(prefix))
                        {
                            txtCode.Text = prefix;
                            txtCode.SelectionStart = txtCode.Text.Length;
                        }
                    } break;
            }
        }

        private void cboRankSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AutoCompleteBind();
            GridViewDataBind();
            cboAgentRank.SelectedIndex = cboRankSearch.SelectedIndex;
            showPrefix();
        }

        private void txtCodeSearch_TextChanged(object sender, EventArgs e)
        {
            GridViewDataBindByCode();
            int i = txtCodeSearch.Text.Trim().IndexOf("     ");
            if (i > 0) txtCodeSearch.Text = (txtCodeSearch.Text.Remove(i)).Trim();
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            GridViewDataBindByName();
        }
        #endregion

        #region Short Cut Key
       private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Save();
            Utility.AllClear(this.panelEntry);
            txtCode.Focus();
            GridViewDataBind();
            if (txtCode.Enabled == false) return;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            showPrefix();
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.SelectionStart = txtCode.Text.Length;
        }

        private void txtUpperCode_TextChanged(object sender, EventArgs e)
           {
            int i = txtUpperCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtUpperCode.Text = (txtUpperCode.Text.Remove(i)).Trim();

        }

        private void txtUpperCode_Leave(object sender, EventArgs e)
        {
  
            switch (cboAgentRank.SelectedItem.ToString())
            {
                case "Merchant":
                    {
                        CompanyControl c_control = new CompanyControl();
                        xsdCodeSetup.CompanyRow personRow = c_control.SelectAllRow();
                        if (personRow != null)
                        {
                            this.txtUpperName.Tag = personRow;
                            UpperId = personRow.CompanyId;
                            txtUpperName.Text = personRow.CompanyName;
                            txtUpperRank.Text = personRow.Rank;
                        }

                    } break;
                case "Small Merchant":
                    {
                        xsdRegister.MerchantRow personRow = m_controller.SelectByCodeRow(txtUpperCode.Text);

                        if (personRow != null)
                        {
                            this.txtUpperName.Tag = personRow;
                            UpperId = personRow.MerchantId;
                            txtUpperName.Text = personRow.MerchantName;
                            txtUpperRank.Text = personRow.Rank;
                        }
                    } break;
                case "Wholesale":
                    {
                        xsdRegister.SmallMerchantRow personRow = sm_controller.SelectByCodeRow(txtUpperCode.Text);

                        if (personRow != null)
                        {

                            this.txtUpperName.Tag = personRow;
                            UpperId = personRow.SmerchantId;
                            txtUpperName.Text = personRow.SmerchantName;
                            txtUpperRank.Text = personRow.Rank;
                        }
                    } break;
                case "Retailer":
                    {
                        xsdRegister.WholesaleRow personRow = w_controller.SelectByCodeRow(txtUpperCode.Text);

                        if (personRow != null)
                        {
                            this.txtUpperName.Tag = personRow;
                            UpperId = personRow.WsaleId;
                            txtUpperName.Text = personRow.WsaleName;
                            txtUpperRank.Text = personRow.Rank;
                        }
                    } break;
                default: cboAgentRank.Select(); break;
            }
        }

        private void txtUpperCode_Enter(object sender, EventArgs e)
        {
            switch (cboRankSearch.SelectedItem.ToString())
            {
                case "Small Merchant":
                    {
                        xsdRegister.MerchantDataTable dt = m_controller.SelectAll();
                        CodeAutoCompleteCollection = new AutoCompleteStringCollection();

                        foreach (DataRow row in dt.Rows)
                        {
                            CodeAutoCompleteCollection.Add(row["MerchantCode"].ToString() + "     " + row["MerchantName"].ToString());
                        }
                        txtUpperCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
                    } break;
                case "Wholesale":
                    {
                        xsdRegister.SmallMerchantDataTable dt = sm_controller.SelectAll();
                        CodeAutoCompleteCollection = new AutoCompleteStringCollection();

                        foreach (DataRow row in dt.Rows)
                        {
                            CodeAutoCompleteCollection.Add(row["SmerchantCode"].ToString() + "     " + row["SmerchantName"].ToString());
                        }
                       
                        txtUpperCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
                    } break;
                case "Retailer":
                    {
                        xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
                        CodeAutoCompleteCollection = new AutoCompleteStringCollection();

                        foreach (DataRow row in dt.Rows)
                        {
                            CodeAutoCompleteCollection.Add(row["WsaleCode"].ToString() + "     " + row["WsaleName"].ToString());
                        }
                        txtUpperCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
                    }
                    break;
            }
        }

        private void btnTreeView_Click(object sender, EventArgs e)
        {
            if ((this.dgvRegister.SelectedRows == null) || (this.dgvRegister.SelectedRows.Count < 1)) return;
            string key = "";
            DataRowView dataRowView = this.dgvRegister.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                switch (cboRankSearch.SelectedItem.ToString())
                {
                    case "Merchant":
                        {
                            key = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantId", string.Empty);
                        } break;
                    case "Small Merchant":
                        {
                            key = Global.GetDataFromRow<string>(dataRowView.Row, "SmerchantId", string.Empty);
                        } break;
                    case "Wholesale":
                        {
                            key = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleId", string.Empty);
                        } break;
                    case "Retailer":
                        {
                            key = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerId", string.Empty);
                        } break;
                }
            }
            if (key != string.Empty)
            {
                Reporting.MerchantTreeView mt = new Reporting.MerchantTreeView(key, cboRankSearch.SelectedItem.ToString());
                mt.ShowDialog(this);
            }
        }

        private void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           IndexOfGrid = dgvRegister.SelectedRows[0].Index;
          // MessageBox.Show(IndexOfGrid.ToString());
        }

        private void cboCity_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show(cboCity.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        //private void panelEntry_Paint(object sender, PaintEventArgs e)
        private void panelEntry_Paint()
        {
            this.cboNationality.SelectedValue = nationality;
            this.cboReligion.SelectedValue = religion;
            this.cboRace.SelectedValue = race;
            this.cboDivision.SelectedValue = divid;
            cboDivision.Refresh();
            BindCity();
            this.cboCity.SelectedValue = cityid;
            cboCity.Refresh();
        }

        
    }


}

