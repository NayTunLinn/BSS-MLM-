using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BSSInfo;
using BSSBussinessLogic.ReportingControls;
using BSSBussinessLogic.ProductSaleControl;

namespace BSSSoftware.Reporting
{
    public partial class SaleReport : Form
    {
        string InvId = null;
        string type = null;


        public SaleReport(string _InvId, string _type)
        {
            InitializeComponent();
            InvId = _InvId;
            type = _type;
        }

        private void SaleReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SaleReportControl s_contol = new SaleReportControl();
                GeneralControl G_controller = new GeneralControl();

                if (type == "Sale")
                {

                    string receiptno = G_controller.AutoGenerateCode("Receipt");
                    xsdSaleReport.Invoice_ReportRow InvRow = s_contol.InvoiceSelectById(InvId);
                    dt = s_contol.InvoiceDetailsSelectById(InvId);

                    //   xsdSaleReport.Invoice_ReportRow invrow= s_contol.InvoiceSelectById("");
                    ReportParameter[] param = new ReportParameter[7];
                    param[0] = new ReportParameter("pReceiptNo", receiptno);

                    param[1] = new ReportParameter("pInvNo", InvRow.InvNo);
                    param[2] = new ReportParameter("pCusCode", InvRow.UpperDistCode);
                    param[3] = new ReportParameter("pCusName", InvRow.UpperDistName);
                    //param[2] = new ReportParameter("pCusCode", " ");
                    //param[3] = new ReportParameter("pCusName", " ");
                    param[4] = new ReportParameter("pTotalAmount", InvRow.TotalAmount.ToString("#,##0"));
                    param[5] = new ReportParameter("pUpperDistName", InvRow.IntroName);
                    param[6] = new ReportParameter("pDate", InvRow.InvDate.ToString("dd/MMM/yyyy"));
                    //ToString());

                    ReportDataSource rds = new ReportDataSource("myReceipt", dt);
                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.LocalReport.DataSources.Add(rds);
                    this.reportViewer.LocalReport.SetParameters(param);
                    reportViewer.LocalReport.Refresh();
                    this.reportViewer.RefreshReport();
                }
                else
                {
                    string receiptno = G_controller.AutoGenerateCode("Receipt");
                    xsdSaleReport.Invoice_ReportRow InvRow = s_contol.ReturnInvoiceSelectById(InvId);
                    dt = s_contol.ReturnInvoiceDetailsSelectById(InvId);

                    //   xsdSaleReport.Invoice_ReportRow invrow= s_contol.InvoiceSelectById("");

                    ReportParameter[] param = new ReportParameter[7];
                    param[0] = new ReportParameter("pReceiptNo", receiptno);

                    param[1] = new ReportParameter("pInvNo", InvRow.InvNo);
                    param[2] = new ReportParameter("pCusCode", InvRow.UpperDistCode);
                    param[3] = new ReportParameter("pCusName", InvRow.UpperDistName);
                    //param[2] = new ReportParameter("pCusCode", " ");
                    //param[3] = new ReportParameter("pCusName", " ");
                    param[4] = new ReportParameter("pTotalAmount", InvRow.TotalAmount.ToString("#,##0"));
                    param[5] = new ReportParameter("pUpperDistName", InvRow.IntroName);
                    param[6] = new ReportParameter("pDate", InvRow.InvDate.ToString("dd/MMM/yyyy"));
                    //ToString());

                    ReportDataSource rds = new ReportDataSource("myReceipt", dt);
                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.LocalReport.DataSources.Add(rds);
                    this.reportViewer.LocalReport.SetParameters(param);
                    reportViewer.LocalReport.Refresh();
                    this.reportViewer.RefreshReport();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            reportViewer.PrintDialog();
        }

    }
}
