using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.ReportingControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.SaleReturnReport
{
    public partial class InvoiceMasterDetailReport : Form
    {
        public InvoiceMasterDetailReport()
        {
            InitializeComponent();
        }
        private void InvoiceMasterDetailReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SaleReportControl s_contol = new SaleReportControl();

                dt = s_contol.HeaderDetailSelect();

                ReportDataSource rds = new ReportDataSource("HeaderDetail", dt);
                myReportViewer.LocalReport.DataSources.Clear();
                myReportViewer.LocalReport.DataSources.Add(rds);
                myReportViewer.LocalReport.Refresh();
                this.myReportViewer.RefreshReport();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            // this.myReportViewer.RefreshReport();
        }
    }
}
