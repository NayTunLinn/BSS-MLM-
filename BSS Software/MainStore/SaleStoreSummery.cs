using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BSSCommon;
using BSSBussinessLogic.StoreControls;

namespace BSSSoftware.MainStore
{
    public partial class SaleStoreSummery : Form
    {
      
        public SaleStoreSummery()
        {
            InitializeComponent();
            Initalizing();
           
        }
        private void Initalizing()
        {
            st = new StoreToSaleControl();
            st.SaleStoreSummeryLoopByDay();
        }
         
        private StoreToSaleControl st = null;
        private void SaleStoreSummery_Load(object sender, EventArgs e)
        {
            Bind();
        }
        private void Bind()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = st.SaleStoreSummeryByDay(dtpkDay.Value.Date);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("Date", dtpkDay.Value.ToString("dd/MMMM/yyyy"));
                //param[1] = new ReportParameter("Title", Title);

                ReportDataSource rds = new ReportDataSource("salestoresummery", dt);
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
            Bind();
        }
        private void SubStoreSummery_SizeChanged(object sender, EventArgs e)
        {
            Utility.CenterMyControl(label1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            st.SaleStoreSummeryLoopByDay();
        }

  
    }
}
