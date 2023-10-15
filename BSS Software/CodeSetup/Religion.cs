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
    public partial class Religion : Form
    {
        public Religion()
        {
            InitializeComponent();
            Initializing();
        }

        #region Variables
        private ReligionControl re_controller = null;

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
            re_controller = new ReligionControl();
            GridViewDataBind();
        }
        public void GridViewDataBind()
        {
            dgvReligion.DataSource = re_controller.SelectAll();
            dgvReligion.AutoGenerateColumns = false;
        }

        public void Save(string key)
        {
            if (txtReligion.Text.Equals(null)) return;
            xsdCodeSetup.ReligionRow dataRow = (new xsdCodeSetup.ReligionDataTable()).NewReligionRow();
            try
            {

                dataRow.Religion = txtReligion.Text.Trim();
                dataRow.Desp = txtDesp.Text.Trim();

                if (string.IsNullOrEmpty(key))
                    this.re_controller.Insert(dataRow);
                else
                {
                    dataRow.ReligionId = key;
                    this.re_controller.Update(dataRow);
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
            this.re_controller.Delete(key);
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
            if ((this.dgvReligion.SelectedRows == null) || (this.dgvReligion.SelectedRows.Count < 1)) return;

            DataRowView dataRowView = this.dgvReligion.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                string key = Global.GetDataFromRow<string>(dataRowView.Row, "ReligionId", string.Empty);
                this.txtReligion.Text = Global.GetDataFromRow<string>(dataRowView.Row, "Religion", string.Empty);
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

            if ((this.dgvReligion.SelectedRows == null) || (this.dgvReligion.SelectedRows.Count < 1)) return;
            DataRowView dataRowView = this.dgvReligion.SelectedRows[0].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                key = Global.GetDataFromRow<string>(dataRowView.Row, "ReligionId", string.Empty);
            }
            this.Delete(key);
            GridViewDataBind();
        }
    }
}
