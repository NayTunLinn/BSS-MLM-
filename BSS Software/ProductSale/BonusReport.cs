using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.ProductSaleControl;
using BSSInfo;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.SaleReturnReport
{
    public partial class BonusReport : Form
    {
        public BonusReport()
        {
            InitializeComponent();
        }
     //   DateTime reportdate = System.DateTime.Now.Date;
        private BonusControls b_controller = null;
        
        DataTable dt = null;
        private void BonusReport_Load(object sender, EventArgs e)
        {
            //BonusViewSelectByCode();
        }

        private void BonusViewSelectByCode()
        {
            if (string.IsNullOrEmpty("to fix"))
            {
                return;
            }
            else
            {
                dt = new DataTable();
                b_controller = new BonusControls();
                xsdSale.BonusViewRow b_row = b_controller.BonusSelectByCode("to fix");
                //txtName.Text = b_row.PersonName;

                dt = b_controller.SelectByCode("to fix");

                ReportParameter[] param = new ReportParameter[3];
                param[0] = new ReportParameter("todaydate", DateTime.Now.ToString("dd/MMMM/yyyy"));
                param[1] = new ReportParameter("personCode", b_row.PersonCode);
                param[2] = new ReportParameter("personName", b_row.PersonName);

                ReportDataSource rds = new ReportDataSource("BonusViewReport", dt);
                BonusReportView.LocalReport.DataSources.Clear();
                this.BonusReportView.LocalReport.SetParameters(param);
                BonusReportView.LocalReport.DataSources.Add(rds);
                this.BonusReportView.RefreshReport();
            }
        }
        private void BonusViewDataBind()
        {
            try
            {
                b_controller = new BonusControls();
                DataTable dt = new DataTable();
                dt = b_controller.SelectAll();

                ReportParameter[] param = new ReportParameter[3];
                param[0] = new ReportParameter("todaydate", DateTime.Now.ToString("dd/MMMM/yyyy"));
                param[1] = new ReportParameter("personCode", "to fix");
                param[2] = new ReportParameter("personName", "to fix");

                ReportDataSource rds = new ReportDataSource("BonusViewReport", dt);
                BonusReportView.LocalReport.DataSources.Clear();
                this.BonusReportView.LocalReport.SetParameters(param);
                BonusReportView.LocalReport.DataSources.Add(rds);
                this.BonusReportView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty("to fix")) return;

            b_controller = new BonusControls();
            xsdSale.BonusViewRow b_row = b_controller.BonusSelectByCode("to fix");
            //txtName.Text = b_row.PersonName;
            if (b_row == null) return;
            BonusViewSelectByCode();
        }
    }
}
