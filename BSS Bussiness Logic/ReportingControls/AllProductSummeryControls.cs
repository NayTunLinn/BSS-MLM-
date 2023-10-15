using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ReportingDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ReportingControls
{
    public class AllProductSummeryControls
    {
        
        #region Variables
        private AllProductSummeryDataCtrl m_Control;
        #endregion

        #region Constructor
        public AllProductSummeryControls()
        {
            m_Control = new AllProductSummeryDataCtrl();
        }
        #endregion

        #region Select Method
        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectByMonth(DateTime fromDate)
        {
            return m_Control.AllProductSummerySelectByDate(fromDate);
        }

        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectAll()
        {
            return m_Control.AllProductSummerySelectAll();
        }
        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectByDate(DateTime FinalDate)
        {
            return m_Control.AllProductSummerySelectByMonth(FinalDate);
        }
        #endregion

        public void InsertSaleProductSummary(xsdSale.InvoiceRow dataRow, xsdSale.SaleInsertDataTable InvDetailDt)
        {

            try
            {
                m_Control.StartTransaction();

                foreach (xsdSale.SaleInsertRow dr in InvDetailDt)
                {
                    m_Control.InsertSaleProductSummary(dataRow.InvDate, dr.ProductId);
                }
                m_Control.CommitTransaction();
            }
            catch (Exception)
            {
                m_Control.RollbackTransaction();
                throw;
            }
        }
    }
}
