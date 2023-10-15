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
    public partial class Division : Form
    {
        public Division()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private DivisionControl m_controller = null;
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
            m_controller = new DivisionControl();
            GridViewDataBind();
        }
        public void GridViewDataBind()
        {
            dgvDivision.DataSource = m_controller.SelectAll();
            dgvDivision.AutoGenerateColumns = false;
        }

        public void Save(string key)
        {
            if (txtDivision.Text.Equals(null)) return;
            xsdCodeSetup.DivisionRow dataRow = (new xsdCodeSetup.DivisionDataTable()).NewDivisionRow();
            try
            {

                dataRow.Division = txtDivision.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.m_controller.Insert(dataRow);
                else
                {
                    dataRow.DivId = key;
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
            this.m_controller.Delete(key);
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
            if ((this.dgvDivision.SelectedRows == null) || (this.dgvDivision.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvDivision.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "DivId", string.Empty);
                this.txtDivision.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Division", string.Empty);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if ((this.dgvDivision.SelectedRows == null) || (this.dgvDivision.SelectedRows.Count < 1)) return;
            DataRowView dataRowView = this.dgvDivision.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                key = Global.GetDataFromRow<string>(dataRowView.Row, "DivId", string.Empty);
            }
            this.Delete(key);
            GridViewDataBind();
        }
    }
}