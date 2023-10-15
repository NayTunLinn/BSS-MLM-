using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSSBussinessLogic.CodeSetupControls;
using BSSBussinessLogic.StoreControls;
using Microsoft.Reporting.WinForms;

namespace BSSSoftware.MainStore
{
    public partial class StoreToSaleReport : Form
    {
        public StoreToSaleReport()
        {
            InitializeComponent();
            cboCategoryBind();
        }
        DateTime reportdate = System.DateTime.Now.Date;
        string InvoiceType;
        private void cboCategoryBind()
        {
            CategoryControl d_control = new CategoryControl();
            cboCategory.DataSource = d_control.SelectAll();
            cboCategory.DisplayMember = "CategoryType";
            cboCategory.ValueMember = "CategoryType";

            InvoiceType = cboCategory.SelectedValue.ToString() ;
        }
        private StoreToSaleControl m_controller = null;
        private void StoreToSaleReport_Load(object sender, EventArgs e)
        {
            try
            {
                m_controller = new StoreToSaleControl();
                DataTable dt = new DataTable();
                dt = m_controller.StoreInvoiceSelectAll();

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("todaydate", reportdate.ToString());
                param[1] = new ReportParameter("InvoiceType", InvoiceType);

                ReportDataSource rds = new ReportDataSource("SubstoreHeaderReport", dt);
                StoreInvoiceHeader.LocalReport.DataSources.Clear();
                this.StoreInvoiceHeader.LocalReport.SetParameters(param);
                StoreInvoiceHeader.LocalReport.DataSources.Add(rds);
                this.StoreInvoiceHeader.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboDate_CheckedChanged(object sender, EventArgs e)
        {
            StoreInvoiceSelectByDate();
        }

        private void StoreInvoiceSelectByDate()
        {
            m_controller = new StoreToSaleControl();
            DataTable dt = new DataTable();
            dt = m_controller.StoreInvoiceSelectByDate(dtpInvDate.Value.Date);

            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());
            param[1] = new ReportParameter("InvoiceType", InvoiceType);

            ReportDataSource rds = new ReportDataSource("SubstoreHeaderReport", dt);
            StoreInvoiceHeader.LocalReport.DataSources.Clear();
            this.StoreInvoiceHeader.LocalReport.SetParameters(param);
            StoreInvoiceHeader.LocalReport.DataSources.Add(rds);
            this.StoreInvoiceHeader.RefreshReport();
        }

        //Search with category
        private void StoreInvoiceSelectByInvType()
        {
            m_controller = new StoreToSaleControl();
            DataTable dt = new DataTable();
            dt = m_controller.StoreInvoiceSelectByInvType(cboCategory.SelectedValue.ToString());

            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());
            param[1] = new ReportParameter("InvoiceType", InvoiceType);

            ReportDataSource rds = new ReportDataSource("SubstoreHeaderReport", dt);
            StoreInvoiceHeader.LocalReport.DataSources.Clear();
            this.StoreInvoiceHeader.LocalReport.SetParameters(param);
            StoreInvoiceHeader.LocalReport.DataSources.Add(rds);
            this.StoreInvoiceHeader.RefreshReport();
        }
        private void StoreInvoiceSelectByInvTypeAndDate()
        {
            m_controller = new StoreToSaleControl();
            DataTable dt = new DataTable();
            dt = m_controller.StoreInvoiceSelectByInvTypeAndDate(cboCategory.SelectedValue.ToString(), dtpInvDate.Value.Date);

            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter("todaydate", reportdate.ToString());
            param[1] = new ReportParameter("InvoiceType", InvoiceType);
           
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ReportDataSource rds = new ReportDataSource("SubstoreHeaderReport", dt);
            StoreInvoiceHeader.LocalReport.DataSources.Clear();
            this.StoreInvoiceHeader.LocalReport.SetParameters(param);
            StoreInvoiceHeader.LocalReport.DataSources.Add(rds);
            this.StoreInvoiceHeader.RefreshReport();
        }
        //search with date

        private void dtpInvDate_ValueChanged(object sender, EventArgs e)
        {
           //for show only date
          //  string date = dtpInvDate.Value.Day.ToString() +" / "+ dtpInvDate.Value.Month.ToString() +" / "+ dtpInvDate.Value.Year.ToString();
            InvoiceType = dtpInvDate.Value.ToString("dd/MMMM/yyyy");
            StoreInvoiceSelectByDate();
        }

        private void cboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InvoiceType = cboCategory.SelectedValue.ToString();
            StoreInvoiceSelectByInvType();
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                return;
            }
            else
            {
                InvoiceType = txtInvoiceNo.Text;

                m_controller = new StoreToSaleControl();
                DataTable dt = new DataTable();
                dt = m_controller.StoreInvoiceSelectByInvNo(txtInvoiceNo.Text);

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("todaydate", reportdate.ToString());
                param[1] = new ReportParameter("InvoiceType", InvoiceType);

                ReportDataSource rds = new ReportDataSource("SubstoreHeaderReport", dt);
                StoreInvoiceHeader.LocalReport.DataSources.Clear();
                this.StoreInvoiceHeader.LocalReport.SetParameters(param);
                StoreInvoiceHeader.LocalReport.DataSources.Add(rds);
                this.StoreInvoiceHeader.RefreshReport();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StoreInvoiceSelectByInvTypeAndDate();
        }
    }
}
