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
    public partial class MainStoreRecord : Form
    {
        AutoCompleteStringCollection UpperCodeAutoCompleteCollection = null;
        ProductControl p_control = null;

        public MainStoreRecord()
        {
            InitializeComponent();
            Initializing();
        }

        private MainStoreControl m_controller = null;
        private StoreToSaleControl sts_controller = null;
        private MainStoreToSubStore st_controller = null;
        private string productId = null;
        private string recordId = null;

        public void Initializing()
        {
            m_controller = new MainStoreControl();
            p_control = new ProductControl();
            sts_controller = new StoreToSaleControl();
            st_controller = new MainStoreToSubStore();
            BindProductCode();
            GridViewDataBind();
           
        }
        private void BindProductCode()
        {

            xsdCodeSetup.ProductDataTable dt = p_control.SelectAll();
            UpperCodeAutoCompleteCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                UpperCodeAutoCompleteCollection.Add(row["ProductCode"].ToString() + "     " + row["ProductName"].ToString());
            }

            txtCode.AutoCompleteCustomSource = UpperCodeAutoCompleteCollection;
        }
        public void GridViewDataBind()
        {
            dgvMainStoreRecord.AutoGenerateColumns = false;
            dgvMainStoreRecord.DataSource = m_controller.MainStoreRecordSelectAll();

            BalanceProductStoreBind();
        }
        private void BalanceProductStoreBind()
        {
            dgvBalanceMainStore.DataSource = m_controller.MainStoreProductSelect();
            dgvBalanceMainStore.AutoGenerateColumns = false;
        }
        public void Save(string key)
        {
            if (txtCode.Text.Equals(null)) return;
            if (numericUpDownQty.Value <= 0) return;

            xsdMainstore.MainStoreRecordRow dataRow = (new BSSInfo.xsdMainstore.MainStoreRecordDataTable()).NewMainStoreRecordRow();
            try
            {
                dataRow.ProductId = productId;
                dataRow.Total = Convert.ToInt32(numericUpDownQty.Value);
                dataRow.ArrivalDate = DateTime.Now;

                if (string.IsNullOrEmpty(key))
                    this.m_controller.MainStoreRecordInsert(dataRow);
                else
                {
                    dataRow.RecordId = recordId;
                    this.m_controller.MainStoreRecordUpdate(dataRow);
                }
                GridViewDataBind();
                ClearTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearTextbox()
        {
            txtCode.Clear();
            txtName.Clear();
            numericUpDownQty.Value = 0;
            dtpkArrivalDate.Value = DateTime.Now.Date;
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

        private void btnreport_Click(object sender, EventArgs e)
        {
            MainStoreReport ms = new MainStoreReport();
            ms.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridViewDataBind();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            CodeSetup.Product pd = new CodeSetup.Product();
            pd.Show();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainStore.MainStoreToSubStore mst = new MainStore.MainStoreToSubStore();
            mst.Show();
            this.Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            int i = txtCode.Text.Trim().IndexOf("     ");
            if (i > 0) txtCode.Text = (txtCode.Text.Remove(i)).Trim();
        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(lblTitle);
        }

        private void numericUpDownQty_Enter(object sender, EventArgs e)
        {
            numericUpDownQty.Select(0, numericUpDownQty.Text.Length);
        }
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            Utility.Tab(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                MainStoreBalance mb = new MainStoreBalance();
                mb.ShowDialog();

                //printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
