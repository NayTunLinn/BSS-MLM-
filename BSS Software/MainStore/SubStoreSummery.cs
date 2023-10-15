using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.ProductSaleControl;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using BSSBussinessLogic.StoreControls;
using BSSCommon;

namespace BSSSoftware.MainStore
{
    public partial class SubStoreSummery : Form
    {
        public SubStoreSummery()
        {
            InitializeComponent();
            Initalizing();
           
        }
        private void Initalizing()
        {
            st = new StoreToSaleControl();
            st.SubStoreSummeryLoopByDay();
        }
         
        private StoreToSaleControl st = null;
        private void SubStoreSummery_Load(object sender, EventArgs e)
        {
            BindByDay();

        }
        private void BindByDay()
        {
            try
            {
                DataTable dt = new DataTable();
                

                dt = st.SubStoreSummeryByDay(dtpkDay.Value.Date);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("Date", dtpkDay.Value.ToString("dd/MMMM/yyyy"));
                //param[1] = new ReportParameter("Title", Title);

                ReportDataSource rds = new ReportDataSource("substoresummery", dt);
                myReportViewer.LocalReport.DataSources.Clear();
                this.myReportViewer.LocalReport.SetParameters(param);
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
        private void BindByMonth()
        {
            try
            {
                DataTable dt = new DataTable();


                dt = st.SubStoreSummeryByMonth(dateTimePicker1.Value.Date);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("MMMM/yyyy"));
                //param[1] = new ReportParameter("Title", Title);

                ReportDataSource rds = new ReportDataSource("substoresummery", dt);
                myReportViewer.LocalReport.DataSources.Clear();
                this.myReportViewer.LocalReport.SetParameters(param);
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
            BindByDay();
        }
        private void SubStoreSummery_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(label1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            st.SubStoreSummeryLoopByDay();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BindByMonth();
        }

  
    }
}
