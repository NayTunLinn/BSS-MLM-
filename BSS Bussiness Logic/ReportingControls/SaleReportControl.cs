using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ReportingDataControls;
using BSSInfo;


namespace BSSBussinessLogic.ReportingControls
{
    public class SaleReportControl
    {
        #region Variables
        private SaleReportDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public SaleReportControl()
        {
            m_Control = new SaleReportDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectAll()
        {
            return m_Control.InvoiceDetailsSelectAll();
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByMonth(DateTime Month)
        {
            return m_Control.InvoiceDetailsSelectByMonth(Month);
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByDay(DateTime Day)
        {
            return m_Control.InvoiceDetailsSelectByDay(Day);
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByDate(DateTime FromDate, DateTime ToDate)
        {
            return m_Control.InvoiceDetailsSelectByDate(FromDate, ToDate);
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByGeneral(string PostSql)
        {
            return m_Control.InvoiceSelectByGeneral(PostSql);
        }
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByGeneral(string PostSql)
        {
            return m_Control.ReturnInvoiceSelectByGeneral(PostSql);
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByGeneral(string PostSql)
        {
            return m_Control.InvoiceDetailsSelectByGeneral(PostSql);
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectTotal(string PostSql)
        {
            return m_Control.InvoiceDetailsSelectTotal(PostSql);
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelect()
        {
            return m_Control.InvoiceSelect();
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByThisMonth()
        {
            return m_Control.InvoiceSelectByThisMonth();
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByInvNo(string InvNo)
        {
            return m_Control.InvoiceSelectByInvNo(InvNo);
        }
        public xsdSaleReport.Invoice_ReportRow InvoiceSelectById(string Key)
        {
            return m_Control.InvoiceSelectById(Key);
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByPersonId(string Key)
        {
            return m_Control.InvoiceSelectByPersonId(Key); 
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectById(string Key)
        {
            return m_Control.InvoiceDetailsSelectById(Key);
        }
        public xsdSaleReport.Invoice_ReportRow ReturnInvoiceSelectById(string Key)
        {
            return m_Control.ReturnInvoiceSelectById(Key);
        }
        public xsdSaleReport.InvoiceDetails_ReportDataTable ReturnInvoiceDetailsSelectById(string Key)
        {
            return m_Control.ReturnInvoiceDetailsSelectById(Key);
        }
        #endregion
        public HeaderDetailReport.InvoiceHeaderDetailDataTable HeaderDetailSelect()
        {
            return m_Control.HeaderDetailSelect();
        }
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByDay()
        {
            return m_Control.ReturnInvoiceSelectByDay();
        }
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByMonth()
        {
            return m_Control.ReturnInvoiceSelectByThisMonth();
        }
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelect()
        {
            return m_Control.ReturnInvoiceSelect();
        }
    }
}
