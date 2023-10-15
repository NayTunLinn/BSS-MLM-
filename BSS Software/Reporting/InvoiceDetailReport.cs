using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BSSBussinessLogic.ReportingControls;

namespace BSSSoftware.Reporting
{
    public partial class InvoiceDetailReport : Form
    {
        string postSql = null;
        public InvoiceDetailReport(string _PostSql)
        {
            InitializeComponent();
            postSql = _PostSql;
        }

        private void InvoiceDetailReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SaleReportControl s_contol = new SaleReportControl();
                dt = s_contol.InvoiceDetailsSelectTotal(postSql);
                ReportDataSource rds = new ReportDataSource("myInvDetail", dt);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.LocalReport.Refresh();
                this.reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

          
        }

        private void xsdSaleReportBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
