using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.FourStepsControls;
using BSSInfo;
using BSSCommon;

namespace BSSSoftware.CodeSetup
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private CustomerControl c_controller = null; 
        private RetailerControl r_controller = null;
        AutoCompleteStringCollection CusCodeAutoCompleteCollection;
        AutoCompleteStringCollection CusNameAutoCompleteCollection;
        private string retailerid=null;
        string key = null;
        #endregion

        #region Constructor
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
            c_controller = new CustomerControl();
            r_controller = new RetailerControl();

            GridViewDataBind();
            DivisionBind();
            BindCity();
            CityBind();

            CustomerCodeBind();
            CustomerNameBind();

        }
        public void GridViewDataBind()
        {
            dgvCustomer.DataSource = c_controller.SelectAll();
            dgvCustomer.AutoGenerateColumns = false;
            CustomerCodeBind();
            CustomerNameBind();
        }
        public void showPrefix()
        {
            string prefix;
           
            prefix = "C";
            if (!txtcuscode.Text.StartsWith(prefix))
            {
                txtcuscode.Text = prefix;
                txtcuscode.SelectionStart = txtcuscode.Text.Length;
            }
                  
        }
        
        #region AutoComplete Data Bind
     

        private void CustomerCodeBind()
        {
            xsdCodeSetup.CustomerDataTable dt = c_controller.SelectAll();
            CusCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CusCodeAutoCompleteCollection.Add(row["CustomerCode"].ToString());
            }

            txtcuscode.AutoCompleteCustomSource = CusCodeAutoCompleteCollection;
        }
        private void CustomerNameBind()
        {
            xsdCodeSetup.CustomerDataTable dt = c_controller.SelectAll();
            CusNameAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CusNameAutoCompleteCollection.Add(row["CustomerName"].ToString());
            }

            txtcusname.AutoCompleteCustomSource = CusNameAutoCompleteCollection;
        }
        #endregion

      

        private void DivisionBind()
        {
            DivisionControl type_Ctrl = new DivisionControl();
            this.cbodivision.DisplayMember = "Division";
            this.cbodivision.ValueMember = "DivId";
            this.cbodivision.DataSource = type_Ctrl.SelectAll();
        }

        private void CityBind()
        {
            CityControl c = new CityControl();
            cbocity.ValueMember = "CityID";
            cbocity.DisplayMember = "City";
            cbocity.DataSource = c.SelectByKey(cbodivision.SelectedValue.ToString());
        }
        private void CityEditBind(string DivId)
        {
            CityControl c = new CityControl();
            cbocity.ValueMember = "CityID";
            cbocity.DisplayMember = "City";
            cbocity.DataSource = c.SelectByKey(DivId);
        }
        private void BindCity()
        {
            if (cbodivision.Items.Count == 0)
            {
                cbocity.DataSource = null;
                return;
            }
            CityControl city = new CityControl();
            xsdCodeSetup.CityDataTable dt = city.SelectByKey(cbodivision.SelectedValue.ToString());

            cbocity.DataSource = dt;

            cbocity.DisplayMember = "City";
            cbocity.ValueMember = "CityId";

        }

        public void Save(string key)
        {
            if (string.IsNullOrEmpty(txtcuscode.Text)) return;
            if (string.IsNullOrEmpty(txtcusname.Text)) return;
            xsdCodeSetup.CustomerRow dataRow = (new xsdCodeSetup.CustomerDataTable()).NewCustomerRow();
            try
            {
               
                dataRow.CustomerImg =new byte[0];
                dataRow.CustomerCode = txtcuscode.Text.Trim();
                dataRow.CustomerName = txtcusname.Text.Trim();
                dataRow.Phone = txtphone.Text.Trim();
                dataRow.DivId = cbodivision.SelectedValue.ToString();
                dataRow.CityId = cbocity.SelectedValue.ToString();
                dataRow.Address = txtaddress.Text.Trim();
                dataRow.Email = txtemail.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.c_controller.Insert(dataRow);
                else
                {
                    dataRow.CustomerId = key;
                    this.c_controller.Update(dataRow);
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
            this.c_controller.Delete(key);
        }
        #endregion


        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            showPrefix();
        

            Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Save(null);
                GridViewDataBind();
                btnNew.Focus();

            }
            Utility.AllClear(this.panelEntry);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
               // showPrefix();
                if ((this.dgvCustomer.SelectedRows == null) || (this.dgvCustomer.SelectedRows.Count < 1)) return;

                DataRowView dataRowView = this.dgvCustomer.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    string key = Global.GetDataFromRow<string>(dataRowView.Row, "CustomerId", string.Empty);
                    this.txtcuscode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "CustomerCode", string.Empty);
                    this.txtcusname.Text = Global.GetDataFromRow<string>(dataRowView.Row, "CustomerName", string.Empty);
                    this.txtphone.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Phone", string.Empty);
                    this.cbodivision.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "DivId", string.Empty);
                    this.cbocity.SelectedValue = Global.GetDataFromRow<string>(dataRowView.Row, "CityId", string.Empty);
                    this.txtaddress.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Address", string.Empty);
                    this.txtemail.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Email", string.Empty);
                    this.txtDesp.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Desp", string.Empty);

                    Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Save(key);
                        GridViewDataBind();
                        btnNew.Focus();

                    }
                    Utility.AllClear(this.panelEntry);
                }
            }
            catch (Exception ex)
            {
                
                	MessageBox.Show(ex.ToString());
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

                if ((this.dgvCustomer.SelectedRows == null) || (this.dgvCustomer.SelectedRows.Count < 1)) return;
                DataRowView dataRowView = this.dgvCustomer.SelectedRows[0].DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                    key = Global.GetDataFromRow<string>(dataRowView.Row, "CustomerId", string.Empty);
                }
                this.Delete(key);
                GridViewDataBind();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cbodivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityBind();
        }

    
        #endregion

        private void txtcuscode_Enter(object sender, EventArgs e)
        {
            txtcuscode.SelectionStart = txtcuscode.Text.Length;
        }

        private void txtcuscode_TextChanged(object sender, EventArgs e)
        {
            showPrefix();
        }
    }
}
