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
        string Title;

        public CommessionDetailWithAmout_report(DateTime _Dt,string _type,string _Title)
        {
            InitializeComponent();
            Dt = _Dt;
            type = _type;
            Title = _Title;
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

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("ReportDate", Dt.ToString("dd/MMMM/yyyy"));
                param[1] = new ReportParameter("Title",Title);

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
  
        }

        private void myReportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //myReportViewer.PrintDialog();
        }

    }
}
