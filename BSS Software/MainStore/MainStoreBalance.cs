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
    public partial class MainStoreBalance : Form
    {
        public MainStoreBalance()
        {
            InitializeComponent();
        }

        private MainStoreControl m_controller = null;
        DateTime reportdate = System.DateTime.Now.Date;

        private void MainStoreBalance_Load(object sender, EventArgs e)
        {
            try
            {
                m_controller = new MainStoreControl();
                DataTable dt = new DataTable();
                dt = m_controller.MainStoreProductSelect();

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("todaydate", reportdate.ToString());


                ReportDataSource rds = new ReportDataSource("MainStoreBalance", dt);
                rpvMainStoreBalance.LocalReport.DataSources.Clear();
                this.rpvMainStoreBalance.LocalReport.SetParameters(param);
                rpvMainStoreBalance.LocalReport.DataSources.Add(rds);
                this.rpvMainStoreBalance.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
