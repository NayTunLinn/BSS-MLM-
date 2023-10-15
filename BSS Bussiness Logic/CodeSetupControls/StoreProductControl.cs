using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class StoreProductControl
    {
        
        #region Variables
        private StoreProductDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public StoreProductControl()
        {
            m_Control = new StoreProductDataCtrl();
        }
        #endregion

        #region Select Methods

        public xsdSubStore.StoreProductDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }

        public xsdSubStore.StoreProductRow SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdSubStore.StoreProductRow TrRow)
        {
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdSubStore.StoreProductRow dataRow)
        {
            m_Control.Update(dataRow);
        } 
        #endregion

        #region Delete
        public void Delete(string key)
        {
            m_Control.Delete(key);
        } 
        #endregion


        /// <summary>
        /// Store record
        /// </summary>
        /// <returns></returns>
        #region StoreRecordSelect
        public xsdSubStore.StoreRecordDataTable StoreRecordSelectAll()
        {
            return m_Control.StoreRecordSelectAll();
        }


        public xsdSubStore.StoreRecordDataTable StoreRecordSelectByDate(DateTime fromDate, DateTime toDate)
        {
            return m_Control.StoreRecordSelectByDate(fromDate, toDate);
        }

        #endregion

        #region RecordInsert Methods
        public string RecordInsert(xsdSubStore.StoreRecordRow TrRow)
        {
            return m_Control.RecordInsert(TrRow);
        }
        #endregion

        #region Update
        public void RecordUpdate(xsdSubStore.StoreRecordRow dataRow)
        {
            m_Control.RecordUpdate(dataRow);
        }
        #endregion

        #region Delete
        public void RecordDelete(string key)
        {
            m_Control.RecordDelete(key);
        }
        #endregion

    }
}
