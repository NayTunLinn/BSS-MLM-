using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.StoreDataControls;
using BSSInfo;

namespace BSSBussinessLogic.StoreControls
{
    public class MainStoreControl
    {
        #region Variables
        private MainStoreDataCtrl m_Control = null;
        #endregion
       
        #region Constructor
        public MainStoreControl()
        {
            m_Control = new MainStoreDataCtrl();
            
        }
        #endregion


        public xsdSubStore.StoreProductRow SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }

        public xsdMainstore.MainStoreProductDataTable MainStoreProductSelect()
        {
            return m_Control.MainStoreProductSelect();
        }
        /// <summary>
        /// Store record
        /// </summary>
        /// <returns></returns>
        #region StoreRecordSelect
        public xsdMainstore.MainStoreRecordDataTable MainStoreRecordSelectAll()
        {
            return m_Control.MainStoreRecordSelectAll();
        }


        public xsdMainstore.MainStoreRecordDataTable StoreRecordSelectByDate(DateTime fromDate, DateTime toDate)
        {
            return m_Control.MainStoreRecordSelectByDate(fromDate, toDate);
        }

        #endregion

        #region StoreRecordInsert Methods
        public string MainStoreRecordInsert(xsdMainstore.MainStoreRecordRow TrRow)
        {
            return m_Control.MainStoreRecordInsert(TrRow);
        }
        public void MainStoreRecordUpdate(xsdMainstore.MainStoreRecordRow TrRow)
        {

        }
        #endregion

    }
}
