using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSInfo;
using BSSBussinessLogic.ReportingControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.Reporting
{
    public partial class SaleProductSummaryReport : Form
    {
        public SaleProductSummaryReport()
        {
            InitializeComponent();
        }


        private AllProductSummeryControls ap_controller = null;
        DateTime reportdate = System.DateTime.Now.Date;


        private void SaleProductSummerySelectAll()
        {
            ap_controller = new AllProductSummeryControls();

            DataTable dt = new DataTable();
            dt = ap_controller.AllProductSummerySelectAll();

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());

            ReportDataSource rds = new ReportDataSource("SaleProductSummary", dt);
            RepSaleProductSummary.LocalReport.DataSources.Clear();
            this.RepSaleProductSummary.LocalReport.SetParameters(param);
            RepSaleProductSummary.LocalReport.DataSources.Add(rds);
            this.RepSaleProductSummary.RefreshReport();
        }


        private void SaleProductSummerySelectAllByMonth()
        {
            ap_controller = new AllProductSummeryControls();

            DataTable dt = new DataTable();
            dt = ap_controller.AllProductSummerySelectByDate(dtpkMonth.Value.Date);

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());

            ReportDataSource rds = new ReportDataSource("SaleProductSummary", dt);
            RepSaleProductSummary.LocalReport.DataSources.Clear();
            this.RepSaleProductSummary.LocalReport.SetParameters(param);
            RepSaleProductSummary.LocalReport.DataSources.Add(rds);
            this.RepSaleProductSummary.RefreshReport();
        }

        private void SaleProductSummerySelectAllByDate()
        {
            ap_controller = new AllProductSummeryControls();

            DataTable dt = new DataTable();
            dt = ap_controller.AllProductSummerySelectByMonth(dtpkFrom.Value.Date);

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());

            ReportDataSource rds = new ReportDataSource("SaleProductSummary", dt);
            RepSaleProductSummary.LocalReport.DataSources.Clear();
            this.RepSaleProductSummary.LocalReport.SetParameters(param);
            RepSaleProductSummary.LocalReport.DataSources.Add(rds);
            this.RepSaleProductSummary.RefreshReport();
        }

        private void cboMonth_CheckedChanged(object sender, EventArgs e)
        {
            SaleProductSummerySelectAllByMonth();
        }

        private void cboFromTo_CheckedChanged(object sender, EventArgs e)
        {
            SaleProductSummerySelectAllByDate();
        }
    }
}
