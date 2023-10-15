using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
  public  class DivisionControl
    {
         #region Variables
        private DivisionDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public DivisionControl()
        {
            m_Control = new DivisionDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.DivisionDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.DivisionRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.DivisionRow dataRow)
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
