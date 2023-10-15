using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ReportingDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ReportingControls
{
    public class SubStoreSummaryControls
    {
        
        #region Variables
        private SubStoreSummaryDataCtrl m_Control;
        #endregion

        #region Constructor
        public SubStoreSummaryControls()
        {
            m_Control = new SubStoreSummaryDataCtrl();
        }
        #endregion

        #region Select Method
        public xsdSummary.SubStoreProductSummaryDataTable AllSubStoreProductSummerySelectByMonth(DateTime FinalDate)
        {
            return m_Control.AllStoreProductSummerySelectByMonth(FinalDate);
        }

        public xsdSummary.SubStoreProductSummaryDataTable SubStoreProductSummerySelectAll()
        {
            return m_Control.StroeProductSummerySelectAll();
        }
        public xsdSummary.SubStoreProductSummaryDataTable AllProductSummerySelectByDate(DateTime SearchDate)
        {
            return m_Control.AllStoreProductSummerySelectByDay(SearchDate);
        }
        #endregion

        /*** No Need
        public void InsertSubStoreProductSummary(xsdSubStore.InvoiceStoreRow dataRow, xsdSubStore.StoreProductInsertDataTable InvDetailDt)
        {

            try
            {
                m_Control.StartTransaction();

                foreach (xsdSubStore.StoreProductInsertRow dr in InvDetailDt)
                {
                    m_Control.InsertStoreProductSummary(dataRow.InvDate, dr.ProductId);
                }
                m_Control.CommitTransaction();
            }
            catch (Exception)
            {
                m_Control.RollbackTransaction();
                throw;
            }
        }
        ***/
    }
}
