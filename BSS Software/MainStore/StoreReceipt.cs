using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSInfo;
using BSSBussinessLogic.ReportingControls;
using BSSBussinessLogic.StoreControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.MainStore
{
    public partial class StoreReceipt : Form
    {
        public StoreReceipt(string _InvId)
        {
            InitializeComponent();
            InvId = _InvId;
        }
        string InvId = null;
        //  string Cash = null;

        private void StoreReceipt_Load(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();

                StoreToSaleControl s_contol = new StoreToSaleControl();

                xsdMainstore.InvoiceDetailStoreRow InvRow = s_contol.InvoiceReceiptRowById(InvId);

                dt = s_contol.InvoiceReceiptById(InvId);

                //   xsdSaleReport.Invoice_ReportRow invrow= s_contol.InvoiceSelectById("");
                ReportParameter[] param = new ReportParameter[3];
                param[0] = new ReportParameter("InvNo", InvRow.InvNo);

                param[1] = new ReportParameter("receiptType", InvRow.InvNo);
                param[2] = new ReportParameter("TotalAmount", InvRow.TotalProduct.ToString());//ToString());

                ReportDataSource rds = new ReportDataSource("StoreReceipt", dt);
                StoreReceiptView.LocalReport.DataSources.Clear();
                StoreReceiptView.LocalReport.DataSources.Add(rds);
                this.StoreReceiptView.LocalReport.SetParameters(param);
                StoreReceiptView.LocalReport.Refresh();
                this.StoreReceiptView.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
