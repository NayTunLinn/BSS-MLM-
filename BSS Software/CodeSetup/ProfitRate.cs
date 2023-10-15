using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSInfo;
using BSSCommon;

namespace BSSSoftware.CodeSetup
{
    public partial class ProfitRate : Form
    {
        public ProfitRate()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private ProfitrateControl p_controller = null;
        private ProductControl d_controller = null;
        AutoCompleteStringCollection CodeAutoCompleteCollection;
        string productid = null;
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
            p_controller = new ProfitrateControl();
            d_controller = new ProductControl();
            GridViewDataBind();
            ProductCodeBinding();
        }
        public void GridViewDataBind()
        {
            dgvprofitrate.DataSource = p_controller.SelectAll();
            dgvprofitrate.AutoGenerateColumns = false;
        }
       

        public void Save(string key)
        {
            if (txtwsalerate.Text.Equals(null)) return;
            xsdCodeSetup.ProfitRatingsRow dataRow = (new xsdCodeSetup.ProfitRatingsDataTable()).NewProfitRatingsRow();
            try
            {

                dataRow.ProductId = productid;
                dataRow.MerchantRate=Convert.ToDecimal(txtmerchantrate.Text.Trim());
                dataRow.SMerchantRate=Convert.ToDecimal(txtsmerchantrate.Text.Trim());
                dataRow.WsaleRate=Convert.ToDecimal(txtwsalerate.Text.Trim());
                dataRow.RetailRate=Convert.ToDecimal(txtretailerrate.Text.Trim());
                dataRow.Desp = txtdesp.Text;

                dataRow.Desp = txtdesp.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.p_controller.Insert(dataRow);
                else
                {
                    dataRow.ProductRatingId = key;
                    this.p_controller.Update(dataRow);
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
            this.p_controller.Delete(key);
        }
        #endregion
        private void btnNew_Click(object sender, EventArgs e)
        {

            Form frm = this.panelEntry.ToDialog("entry", this.Text, MessageBoxButtons.OKCancel, FormBorderStyle.FixedDialog);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Save(null);
                GridViewDataBind();
                btnNew.Focus();

            }
            Utility.AllClear(this.panelEntry);

        }
        public void ProductCodeBinding()
        {
            xsdCodeSetup.ProductDataTable dt = d_controller.SelectAll();
            CodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                CodeAutoCompleteCollection.Add(row["ProductCode"].ToString());
            }
            txtpcode.AutoCompleteCustomSource = CodeAutoCompleteCollection;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((this.dgvprofitrate.SelectedRows == null) || (this.dgvprofitrate.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvprofitrate.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "ProductRatingId", string.Empty);
                this.productid = Global.GetDataFromRow<string>(dataRowView.Row, "ProductId", string.Empty);
                this.txtpcode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductCode", string.Empty);
                this.txtpname.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductName", string.Empty);
                this.txtmerchantrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "MerchantRate", string.Empty);
                this.txtsmerchantrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "SMerchantRate", string.Empty);
                this.txtwsalerate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "WsaleRate", string.Empty);
                this.txtretailerrate.Text = Global.GetDataFromRow<string>(dataRowView.Row, "RetailRate", string.Empty);
                this.txtdesp.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Desp", string.Empty);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if ((this.dgvprofitrate.SelectedRows == null) || (this.dgvprofitrate.SelectedRows.Count < 1)) return;
            DataRowView dataRowView = this.dgvprofitrate.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                key = Global.GetDataFromRow<string>(dataRowView.Row, "ProductRatingId", string.Empty);
            }
            this.Delete(key);
            GridViewDataBind();
        }

        private void txtpcode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtpcode.Text)) return;

            xsdCodeSetup.ProductRow personRow = d_controller.SelectByCode(txtpcode.Text);

            if (personRow != null)
            {
                this.txtpname.Tag = personRow;
                productid = personRow.ProductId;
                txtpname.Text = personRow.ProductName;

            }
        }
    }
}
