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
    public partial class ReportInvoice : Form
    {
        string PostSql = null;
        public ReportInvoice(string _postSql)
        {
            InitializeComponent();
            PostSql = _postSql;
        }

        private void ReportInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SaleReportControl s_contol = new SaleReportControl();
                dt = s_contol.InvoiceSelectByGeneral(PostSql);
                ReportDataSource rds = new ReportDataSource("myInvoice", dt);
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
     
    }
}
