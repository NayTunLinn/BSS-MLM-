using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class CompanyControl
    {
          #region Variables
        private CompanyDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public CompanyControl()
        {
            m_Control = new CompanyDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.CompanyDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdCodeSetup.CompanyRow SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }
        public xsdCodeSetup.CompanyRow SelectAllRow()
        {
            return m_Control.SelectAllRow();
        }
        #endregion

        #region Insert Methods
        //public string Insert(xsdCodeSetup.DivisionRow TrRow ){
        //    return m_Control.Insert(TrRow);
        //}
        #endregion

        #region Update
        //public void Update(xsdCodeSetup.DivisionRow dataRow)
        //{
        //    m_Control.Update(dataRow);
        //} 
        #endregion

        #region Delete
        //public void Delete(string key)
        //{
        //    m_Control.Delete(key);
        //} 
        #endregion
    }
}
