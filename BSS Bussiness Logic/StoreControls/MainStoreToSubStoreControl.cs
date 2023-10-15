using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.StoreDataControls;
using BSSInfo;

namespace BSSBussinessLogic.StoreControls
{
    public class MainStoreToSubStoreControl
    {
        
        #region Variables
        private MainStoreToSubStoreDataCtrl m_Control = null;
        //private GeneralControl g_control = null;
        public static string InvId { get; private set; }

        #endregion

        #region Constructor
        public MainStoreToSubStoreControl()
        {
            m_Control = new MainStoreToSubStoreDataCtrl();
        }
        #endregion


        #region Select

        public xsdMainstore.MainStoreInvoiceDataTable StoreInvoiceSelectAll()
        {
            return m_Control.MainStoreInvoiceSelectAll();
        }
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByGroup()
        {
            return m_Control.MainStoreInvoiceSelectByGroup();
        }
        public xsdMainstore.MainStoreInvoiceDataTable StoreInvoiceSelectByDate(DateTime invdate)
        {
            return m_Control.MainStoreInvoiceSelectByDate(invdate);
        }
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByMonth(DateTime invdate)
        {
            return m_Control.MainStoreInvoiceSelectByMonth(invdate);
        }
        public xsdMainstore.MainStoreInvoiceDataTable StoreInvoiceSelectByInvNo(string invno)
        {
            return m_Control.MainStoreInvoiceSelectByInvNo(invno);
        }

        public xsdMainstore.MainStoreInvoiceDetailDataTable StoreInvoiceDetailSelectAll()
        {
            return m_Control.MainStoreInvoiceDetailSelectAll();
        }

        public xsdMainstore.MainStoreInvoiceDetailDataTable StoreInvoiceDetailSelectByInvNo(string invno)
        {
            return m_Control.MainStoreInvoiceDetailSelectByInvNo(invno);
        }
        /** for mainstroe detail amount of product price
        public xsdMainstore.MainStoreInvoiceDetailRow StoreInvoiceDetailSelectByInvNoForReport(string invno)
        {
            return m_Control.MainStoreInvoiceDetailSelectByInvNoForReport(invno);
        }
         * */

        public xsdSubStore.BalanceStoreProductDataTable BalanceStoreProductSelect()
        {
            return m_Control.BalanceStoreProductSelect();
        }

        #endregion

        #region Insert Methods

        //By Michael
        //Transaction Succeed 
        //header and detail (master)
        public void StoreInvoiceInsert(xsdMainstore.MainStoreInvoiceRow dataRow, xsdMainstore.StoreProductInsertDataTable InvDetailDt)
        {
            try
            {
                m_Control.StartTransaction();
                InvId = this.m_Control.InsertHeader(dataRow);


                foreach (xsdMainstore.StoreProductInsertRow dr in InvDetailDt)
                {
                    m_Control.InsertDetail(InvId, dr);
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
    }
}
