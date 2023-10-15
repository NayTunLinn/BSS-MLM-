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
    public partial class Retailer : Form
    {

        #region Variables
        private RetailerControl r_controller = null;
        private WholesaleControl w_controller = null;
        private string RetailerId = string.Empty;
        string gender = null;
        string key = null;
        Image DefaultImage = null;
        byte[] Pic_Array;
        AutoCompleteStringCollection CodeAutoCompleteCollection;
        AutoCompleteStringCollection NameAutoCompleteCollection;
        #endregion

        #region Constructor
        public Retailer()
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
            r_controller = new RetailerControl();
            w_controller = new WholesaleControl();
            GridViewDataBind();
            this.DataBinding();
        }

        #region AutoComplete Data Bind
        private void BindWholesaleCode()
        {
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["WsaleCode"].ToString());
            }
            txtWholesaleCode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
        }
        private void BindWholesaleName()
        {
            xsdRegister.WholesaleDataTable dt = w_controller.SelectAll();
            NameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                NameAutoCompleteCollection.Add(row["WsaleName"].ToString());
            }
            txtWholesaleName.AutoCompleteCustomSource = NameAutoCompleteCollection;
        }
        #endregion

        #region DataBinding
        public void DataBinding()
        {

            DivisionBind();
            BindCity();
            NationalityBind();
            ReligionBind();
            RaceBind();
            BindWholesaleCode();
            BindWholesaleName();

        }
        public void GridViewDataBind()
        {
            dgvRetailer.DataSource = r_controller.SelectAll();
            dgvRetailer.AutoGenerateColumns = false;
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

        public void Save(string key)
        {

            if (string.IsNullOrWhiteSpace(txtWholesaleName.Text)) return;
            if (string.IsNullOrWhiteSpace(txtWholesaleCode.Text)) return;
            xsdRegister.RetailerRow dataRow = (new xsdRegister.RetailerDataTable()).NewRetailerRow();
            try
            {
                byte[] img;
                if (picBox.Image == null)
                {
                    img = new byte[0];
                }
                else
                {
                    img = Utility.ConvertImageToBinary(picBox.Image);
                }
                //dataRow.SMerchantImg = txtName.Text.Trim();
                dataRow.WsaleId = RetailerId;
                dataRow.RetailerImg = img;
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
                dataRow.ChildEducation = txtChildrenEdu.Text.Trim();
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


            //row.TchrImg
        }

        public void Delete(string key)
        {
            if (key.Equals(null)) return;
            this.w_controller.Delete(key);
        }
        #endregion

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            Utility.AllClear(this.panelEntry);
            Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Save(null);
                GridViewDataBind();
                btnNew.Focus();

            }
        }

        private void cboDivision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboCity.DataSource = null;
            CityBind();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Utility.AllClear(this.panelEntry);
            if ((this.dgvRetailer.SelectedRows == null) || (this.dgvRetailer.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvRetailer.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                RetailerId = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleId", string.Empty);
                //  xsdRegister.MerchantRow m_row =(new xsdRegister.MerchantDataTable()).NewMerchantRow();
                xsdRegister.WholesaleRow m_row = w_controller.SelectByKey(RetailerId);
 
                this.txtWholesaleCode.Text = Global.GetDataFromRow<string>(m_row, "WsaleCode", string.Empty);
                this.txtWholesaleName.Text = Global.GetDataFromRow<string>(m_row, "WsaleName", string.Empty);

                string key = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerId", string.Empty);

                this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerCode", string.Empty);
                this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerName", string.Empty);
                this.txtRate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerRate", string.Empty);
                this.txtFatherName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "FatherName", string.Empty);
                this.txtNRCNO.Text = Global.GetDataFromRow<string>(dataRowView.Row, "NRCNo", string.Empty);
                string gender = Global.GetDataFromRow<string>(dataRowView.Row, "Gender", string.Empty);
                if (gender.Equals("Male")) rdoMale.Checked = true;
                else rdoFemale.Checked = true;
                this.dtpkDOB.Value = Global.GetDataFromRow<DateTime>(dataRowView.Row, "DOB", DateTime.Now);
                this.cboNationality.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "NationalityId", string.Empty);
                this.cboReligion.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "ReligionId", string.Empty);
                this.cboRace.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "RaceId", string.Empty);
                this.numericUpDownNoOfChild.Value = Global.GetDataFromRow<int>(dataRowView.Row, "NoOfChildren", 0);
                this.txtChildrenName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ChildDesp", string.Empty);
                this.txtChildrenEdu.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ChildEducation", string.Empty);
                this.txtPhone.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Phone", string.Empty);
                DivisionBind();
                this.cboDivision.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "DivId", string.Empty);
                BindCity();
                this.cboCity.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "CityId", string.Empty);
                this.txtAddress.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Address", string.Empty);
                this.txtEmail.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Email", string.Empty);
                this.txtDesp.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Desp", string.Empty);
                this.dtpkRegDate.Value = Global.GetDataFromRow<DateTime>(dataRowView.Row, "RegDate", DateTime.Now);
                Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Save(key);
                    GridViewDataBind();
                    btnNew.Focus();
                }

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
                if ((this.dgvRetailer.SelectedRows == null) || (this.dgvRetailer.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvRetailer.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    key = Global.GetDataFromRow<string>(dataRowView.Row, "RetailerId", string.Empty);
                }
                this.Delete(key);
                GridViewDataBind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("This Person is being used in Customer Table");
            }
        }
        #endregion
        private void txtMerchantCode_KeyDown(object sender, KeyEventArgs e)
        {
            Utility.Tab(e);
        }

        private void txtWholesaleCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtWholesaleCode.Text)) return;


            xsdRegister.WholesaleRow personRow = w_controller.SelectByCodeRow(txtWholesaleCode.Text);

            if (personRow != null)
            {

                this.txtWholesaleName.Tag = personRow;
                RetailerId = personRow.WsaleId;
                txtWholesaleName.Text = personRow.WsaleName;

            }
        }
    }
}