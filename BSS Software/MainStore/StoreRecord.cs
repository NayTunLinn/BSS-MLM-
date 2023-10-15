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
using BSSBussinessLogic.StoreControls;

namespace BSSSoftware.MainStore
{
    public partial class StoreRecord : Form
    {
        AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;
        ProductControl p_control = null;
        public StoreRecord()
        {
            InitializeComponent();
            Initializing();
        }

        private StoreProductControl m_controller = null;
        private StoreToSaleControl st_controller = null;
        private string productId=null;
        private string recordId = null;

        public void Initializing()
        {
            m_controller = new StoreProductControl();
            p_control = new ProductControl();
            st_controller = new StoreToSaleControl();
            GridViewDataBind();
            BalanceProductStoreBind();
        }

        private void BindProductCode()
        {
       
            xsdCodeSetup.ProductDataTable dt = p_control.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["ProductCode"].ToString());
            }

            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }

        public void GridViewDataBind()
        {
            dgvStoreRecord.AutoGenerateColumns = false;
            dgvProduct.AutoGenerateColumns = false;
            dgvStoreRecord.DataSource = m_controller.StoreRecordSelectAll();
        
            dgvProduct.DataSource = p_control.SelectAll();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
         
        }

        private void BalanceProductStoreBind()
        {
            dgvBalanceStore.DataSource = st_controller.BalanceStoreProductSelect();
            dgvBalanceStore.AutoGenerateColumns = false;
        }
        public void Save(string key)
        {
            if (txtCode.Text.Equals(null)) return;
            if (numericUpDownQty.Value <= 0) return;

            BSSInfo.xsdSubStore.StoreRecordRow dataRow = (new BSSInfo.xsdSubStore.StoreRecordDataTable()).NewStoreRecordRow();
            try
            {
                dataRow.ProductId = productId;
                dataRow.Total = Convert.ToInt32(numericUpDownQty.Value);
                dataRow.ArrivalDate = dtpkArrivalDate.Value.Date;

                if (string.IsNullOrEmpty(key))
                    this.m_controller.RecordInsert(dataRow);
                else
                {
                    dataRow.RecordId = recordId;
                    this.m_controller.RecordUpdate(dataRow);
                }
                GridViewDataBind();
                ClearTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                this.Save(recordId);
                GridViewDataBind();
                BalanceProductStoreBind();
                txtCode.Select();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
             if ((this.dgvStoreRecord.SelectedRows == null) || (this.dgvStoreRecord.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvStoreRecord.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                recordId = Global.GetDataFromRow<string>(dataRowView.Row, "RecordId", string.Empty);
                productId = Global.GetDataFromRow<string>(dataRowView.Row, "ProductId", string.Empty);
                this.txtCode.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductCode", string.Empty);
                this.txtName.Text = Global.GetDataFromRow<string>(dataRowView.Row, "ProductName", string.Empty);
                this.numericUpDownQty.Value = Global.GetDataFromRow<int>(dataRowView.Row, "Total", 0);
            }
         
        }

        private void dgvStoreRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow dataRow = dgvStoreRecord.Rows[e.RowIndex];

            recordId = dataRow.Cells["colRecordId"].Value.ToString();
            productId = dataRow.Cells["colProductId"].Value.ToString();
            this.txtCode.Text = dataRow.Cells["colProductCode"].Value.ToString();
            this.txtName.Text = dataRow.Cells["colProductName"].Value.ToString();
            this.numericUpDownQty.Value = (Int32)dataRow.Cells["colTotal"].Value;
            this.dtpkArrivalDate.Value = (DateTime)dataRow.Cells["colArrivalDate"].Value;
        }

        private void ClearTextbox()
        {
            txtCode.Clear();
            txtName.Clear();
            numericUpDownQty.Value = 0;
            dtpkArrivalDate.Value = DateTime.Now.Date;
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

        private void btnreport_Click(object sender, EventArgs e)
        {
            ReportView rv = new ReportView();
            rv.Show();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            CodeSetup.Product pd = new CodeSetup.Product();
            pd.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           // this.Refresh();
            GridViewDataBind();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.Text)) return;

            xsdSubStore.StoreProductRow productRow = m_controller.SelectByCode(txtCode.Text);

            if (productRow != null)
            {
                this.txtName.Tag = productRow;
                productId = productRow.ProductId;
                txtName.Text = productRow.ProductName;

            }
        }
    }
}
