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
using BSSInfo;
namespace BSSSoftware.MainStore
{
    public partial class MainStoreToSubStoreReportDetail : Form
    {
        public MainStoreToSubStoreReportDetail()
        {
            InitializeComponent();
        }

        private MainStoreToSubStoreControl m_controller = null;
        DateTime reportdate = System.DateTime.Now.Date;
        
        private void MainStoreToSubStoreReportDetail_Load(object sender, EventArgs e)
        {
            StoreInvoiceDetailBind();
        }
        private void StoreInvoiceDetailBind()
        {
            if(string.IsNullOrEmpty(txtInvoiceNo.Text))return;

            m_controller = new MainStoreToSubStoreControl();
            DataTable dt = new DataTable();
            dt = m_controller.StoreInvoiceDetailSelectAll();

            try
            {
               // xsdMainstore.MainStoreInvoiceDetailRow row = m_controller.StoreInvoiceDetailSelectByInvNoForReport(txtInvoiceNo.Text);

                ReportParameter[] param = new ReportParameter[1];

                param[0] = new ReportParameter("todaydate", reportdate.ToString());
                //param[1] = new ReportParameter("TotalAmount",row.Price.ToString());

                ReportDataSource rds = new ReportDataSource("MstroeToSubStoreReportDetail", dt);
                MainStoreInvoiceDetail.LocalReport.DataSources.Clear();
                this.MainStoreInvoiceDetail.LocalReport.SetParameters(param);
                MainStoreInvoiceDetail.LocalReport.DataSources.Add(rds);
                this.MainStoreInvoiceDetail.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                return;
            }
            else
            {
                m_controller = new MainStoreToSubStoreControl();
                DataTable dt = new DataTable();

                dt = m_controller.StoreInvoiceDetailSelectByInvNo(txtInvoiceNo.Text);

                try
                {
                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("todaydate", reportdate.ToString());

                    ReportDataSource rds = new ReportDataSource("MstroeToSubStoreReportDetail", dt);
                    MainStoreInvoiceDetail.LocalReport.DataSources.Clear();
                    this.MainStoreInvoiceDetail.LocalReport.SetParameters(param);
                    MainStoreInvoiceDetail.LocalReport.DataSources.Add(rds);
                    this.MainStoreInvoiceDetail.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
