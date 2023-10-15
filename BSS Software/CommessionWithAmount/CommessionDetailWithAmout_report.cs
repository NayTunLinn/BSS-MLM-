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

namespace BSSSoftware.Commession
{
    public partial class CommessionDetailWithAmout_report : Form
    {
        DateTime Dt;
        string type ;

        public CommessionDetailWithAmout_report(DateTime _Dt,string _type)
        {
            InitializeComponent();
            Dt = _Dt;
            type = _type;
        }


        private void CommessionDetail_report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                BonusControls bc = new BonusControls();
                switch (type)
                {
                    case "Month": dt = bc.SelectDetailByMonth(Dt); break;
                    case "Day": dt = bc.SelectDetailByDay(Dt); break;
                    case "Level": dt = bc.SelectCommessionByLevel(); break;
                    default: dt = bc.SelectDetailByDay(Dt); break;
                }

                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("ReportDate", Dt.ToString("dd/MMMM/yyyy"));
                //param[1] = new ReportParameter("personCode", b_row.PersonCode);
                //param[2] = new ReportParameter("personName", b_row.PersonName);

                ReportDataSource rds = new ReportDataSource("BonusDetail", dt);
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
            // this.myReportViewer.RefreshReport();
            this.myReportViewer.RefreshReport();
            this.myReportViewer.RefreshReport();
        }

    }
}
