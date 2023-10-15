using BSSBussinessLogic.ReportingControls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSSSoftware.Reporting
{
    public partial class testReport : Form
    {
        public testReport()
        {
            InitializeComponent();
        }

        private void testReport_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SaleReportControl s_contol = new SaleReportControl();
            dt = s_contol.InvoiceDetailsSelectAll();

            //   xsdSaleReport.Invoice_ReportRow invrow= s_contol.InvoiceSelectById("");
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("pReceiptNo", "000001");
            param[1] = new ReportParameter("pInvNo", "0011001");
            param[2] = new ReportParameter("pCusCode", "SM001");
            param[3] = new ReportParameter("pCusName", "Daw Hla Aye");

            ReportDataSource rds = new ReportDataSource("myReceipt", dt);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            this.reportViewer.LocalReport.SetParameters(param);
            reportViewer.LocalReport.Refresh();
            this.reportViewer.RefreshReport();
            this.reportViewer.RefreshReport();
        }
    }
}
