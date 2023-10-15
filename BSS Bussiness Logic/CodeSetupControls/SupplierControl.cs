using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
   public class SupplierControl
    {
       
        #region Variables
        private SupplierDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public SupplierControl()
        {
            m_Control = new SupplierDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.SupplierDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.SupplierRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.SupplierRow dataRow)
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
    }
}
