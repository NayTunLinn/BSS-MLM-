using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.StoreControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.MainStore
{
    public partial class MainStoreSummery : Form
    {
        public MainStoreSummery()
        {
            InitializeComponent();
        }
        private StoreToSaleControl st = null;
        private void MainStoreSummery_Load(object sender, EventArgs e)
        {

            this.myReportViewer.RefreshReport();
        }
        private void Bind()
        {
            try
            {
                DataTable dt = new DataTable();
                st = new StoreToSaleControl();

                dt = st.SubStoreSummeryByDay(dtpkDay.Value.Date);

                //ReportParameter[] param = new ReportParameter[2];
                //param[0] = new ReportParameter("ReportDate", Dt.ToString("dd/MMMM/yyyy"));
                //param[1] = new ReportParameter("Title", Title);

                ReportDataSource rds = new ReportDataSource("mainsummery", dt);
                myReportViewer.LocalReport.DataSources.Clear();
                // this.myReportViewer.LocalReport.SetParameters(param);
                myReportViewer.LocalReport.DataSources.Add(rds);
                myReportViewer.LocalReport.Refresh();
                this.myReportViewer.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void dtpkDay_ValueChanged(object sender, EventArgs e)
        {
            Bind();
        }
    }
}
