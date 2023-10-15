using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.MainStore
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
        }
        private StoreProductControl m_controller = null;
        DateTime reportdate = System.DateTime.Now.Date;

        private void ReportView_Load(object sender, EventArgs e)
        {
            try
            {
                m_controller = new StoreProductControl();
                DataTable dt = new DataTable();
                dt = m_controller.StoreRecordSelectAll();

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("todaydate", reportdate.ToString());


                ReportDataSource rds = new ReportDataSource("StoreReport", dt);
                StoreRecordReprot.LocalReport.DataSources.Clear();
                this.StoreRecordReprot.LocalReport.SetParameters(param);
                StoreRecordReprot.LocalReport.DataSources.Add(rds);
                this.StoreRecordReprot.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StoreRecordSelectByDate()
        {
            try
            {
                m_controller = new StoreProductControl();
                DataTable dt = new DataTable();
                dt = m_controller.StoreRecordSelectByDate(dtpFrom.Value.Date, dtpTo.Value.Date);

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("todaydate", reportdate.ToString());


                ReportDataSource rds = new ReportDataSource("StoreReport", dt);
                StoreRecordReprot.LocalReport.DataSources.Clear();
                this.StoreRecordReprot.LocalReport.SetParameters(param);
                StoreRecordReprot.LocalReport.DataSources.Add(rds);
                this.StoreRecordReprot.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            StoreRecordSelectByDate();
        }
    }
}
