using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.StoreControls;
using BSSInfo;
using BSSCommon;

namespace BSSSoftware.MainStore
{
    public partial class StoerCategory : Form
    {
        public StoerCategory()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private CategoryControl m_controller = null;
        string gender = null;
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
            m_controller = new CategoryControl();
            GridViewDataBind();
        }
        public void GridViewDataBind()
        {
            dgvCategory.DataSource = m_controller.SelectAll();
            dgvCategory.AutoGenerateColumns = false;
        }

        public void Save(string key)
        {
            if (txtCategory.Text.Equals(null)) return;
            xsdSubStore.StoreCategoryRow dataRow = (new xsdSubStore.StoreCategoryDataTable()).NewStoreCategoryRow();
            try
            {

                dataRow.CategoryType = txtCategory.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.m_controller.Insert(dataRow);
                else
                {
                    dataRow.CategoryId = key;
                    this.m_controller.Update(dataRow);
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
            //this.m_controller.Delete(key);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((this.dgvCategory.SelectedRows == null) || (this.dgvCategory.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvCategory.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "CategoryId", string.Empty);
                this.txtCategory.Text = Global.GetDataFromRow<string>(dataRowView.Row, "CategoryType", string.Empty);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if ((this.dgvCategory.SelectedRows == null) || (this.dgvCategory.SelectedRows.Count < 1)) return;
            DataRowView dataRowView = this.dgvCategory.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                key = Global.GetDataFromRow<string>(dataRowView.Row, "CategoryId", string.Empty);
            }
            this.Delete(key);
            GridViewDataBind();
        }
    }
}
