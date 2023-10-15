using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.StoreControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.MainStore
{
    public partial class MainStoreToSubStoreReport : Form
    {
        public MainStoreToSubStoreReport()
        {
            InitializeComponent();

        }
        private void Initalizing()
        {
            reportdate = DateTime.Now.Date;
        }
        #region Variables
        DateTime reportdate;
        DataTable dt;
        private MainStoreToSubStoreControl m_controller = null; 
        #endregion

        private void MainStoreToSubStoreReport_Load(object sender, EventArgs e)
        {
            try
            {
                m_controller = new MainStoreToSubStoreControl();
               dt = new DataTable();
                dt = m_controller.StoreInvoiceSelectAll();

                Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StoreInvoiceSelectByMonth()
        {
        
            try
            {
                m_controller = new MainStoreToSubStoreControl();
                dt = new DataTable();
                dt = m_controller.MainStoreInvoiceSelectByMonth(dtpkInvMnth.Value.Date);
                Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StoreInvoiceSelectByGroup()
        {

            try
            {
                m_controller = new MainStoreToSubStoreControl();
                dt = new DataTable();
                dt = m_controller.MainStoreInvoiceSelectByGroup();
                Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StoreInvoiceSelectByInvNo()
        {
            if (string.IsNullOrEmpty(txtInvoiceNo.Text)) return;
            try{
            m_controller = new MainStoreToSubStoreControl();
             dt = new DataTable();
            dt = m_controller.StoreInvoiceSelectByInvNo(txtInvoiceNo.Text);
            Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StoreInvoiceSelectByDate()
        {
            try{
            m_controller = new MainStoreToSubStoreControl();
             dt = new DataTable();
            dt = m_controller.StoreInvoiceSelectByDate(dtpInvDate.Value.Date);
            Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            StoreInvoiceSelectByInvNo();
        }

        private void dtpInvDate_ValueChanged(object sender, EventArgs e)
        {
            StoreInvoiceSelectByDate();
        }

        private void btndetailview_Click(object sender, EventArgs e)
        {
            MainStoreToSubStoreReportDetail de = new MainStoreToSubStoreReportDetail();
            de.Show();
        }
        private void Report()
        {
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());

            ReportDataSource rds = new ReportDataSource("MainstoreToSubStoreInvoiceHeader", dt);
            MainStoreInvoiceHeader.LocalReport.DataSources.Clear();
            this.MainStoreInvoiceHeader.LocalReport.SetParameters(param);
            MainStoreInvoiceHeader.LocalReport.DataSources.Add(rds);
            this.MainStoreInvoiceHeader.RefreshReport();
        }

        private void dtpkInvMnth_ValueChanged(object sender, EventArgs e)
        {
            StoreInvoiceSelectByMonth();
        }

        private void cboGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (cboGroup.Checked)
            {
                StoreInvoiceSelectByGroup();
            }
            else StoreInvoiceSelectByMonth();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StoreInvoiceSelectByMonth();
        }

    }
}
