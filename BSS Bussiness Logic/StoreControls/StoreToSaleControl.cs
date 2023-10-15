using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.StoreDataControls;
using BSSInfo;

namespace BSSBussinessLogic.StoreControls
{
    public class StoreToSaleControl
    {

        #region Variables
        private StoreToSaleDataCtrl m_Control = null;
        //private GeneralControl g_control = null;
        public static string InvId { get; private set; }

        #endregion

        #region Constructor
        public StoreToSaleControl()
        {
            m_Control = new StoreToSaleDataCtrl();
        }
        #endregion


        #region Select

        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectAll()
        {
            return m_Control.StoreInvoiceSelectAll();
        }

        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByInvType(string InvType)
        {
            return m_Control.StoreInvoiceSelectByInvType(InvType);
        }
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByDate(DateTime invdate)
        {
            return m_Control.StoreInvoiceSelectByDate(invdate);
        }
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByInvNo(string invno)
        {
            return m_Control.StoreInvoiceSelectByInvNo(invno);
        }
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByInvTypeAndDate(string InvType, DateTime date)
        {
            return m_Control.StoreInvoiceSelectByInvTypeAndDate(InvType, date);
        }

        public xsdSubStore.InvoiceDetailStoreRow InvoiceReceiptRowById(string invId)
        {
            return m_Control.InvoiceReceiptRowById(invId);
        }

        /**
        public xsdSubStore.InvoiceDetailStoreDataTable InvoiceReceiptById(string invId)
        {
            return m_Control.InvoiceReceiptById(invId);
        }
        **/

        public xsdSubStore.BalanceStoreProductDataTable BalanceStoreProductSelect()
        {
            return m_Control.BalanceStoreProductSelect();
        }
        public xsdSubStore.BalanceSaleProductDataTable BalanceSaleProductSelect()
        {
            return m_Control.BalanceSaleProductSelect();
        }
        #endregion

        #region Insert Methods

        //By Michael
        //Transaction Succeed 
        //header and detail (master)
        public void StoreInvoiceInsert(xsdSubStore.InvoiceStoreRow dataRow, xsdSubStore.StoreProductInsertDataTable InvDetailDt)
        {
            try
            {
                m_Control.StartTransaction();
                InvId = this.m_Control.InsertHeader(dataRow);

                foreach (xsdSubStore.StoreProductInsertRow dr in InvDetailDt)
                {
                    m_Control.InsertDetail(InvId, dr);
                    m_Control.InsertStoreProductSummary(dataRow.InvDate, dr.ProductId);
                }

                ////transaction testing
                //int[] i = new int[2];
                //i[23] = 232;

                m_Control.CommitTransaction();
            }
            catch (Exception)
            {
                m_Control.RollbackTransaction();
                throw;
            }
        }

        #endregion

        #region Summery
        public XsdProductSummery.SubStoreSummeryDataTable SubStoreSummeryByDay(DateTime Date)
        {
            return m_Control.SubStoreSummeryByDay(Date);
        }
        public void SubStoreSummeryLoopByDay()
        {
            m_Control.SubStoreSummeryLoopByDay();
        }
        public XsdProductSummery.SubStoreSummeryDataTable SaleStoreSummeryByDay(DateTime Date)
        {
            return m_Control.SaleStoreSummeryByDay(Date);
        }
        public void SaleStoreSummeryLoopByDay()
        {
            m_Control.SaleStoreSummeryLoopByDay();
        }
        public XsdProductSummery.SubStoreSummeryDataTable SubStoreSummeryByMonth(DateTime Date)
        { 
            return m_Control.SubStoreSummeryByMonth(Date);
        }
        #endregion
    }
}
