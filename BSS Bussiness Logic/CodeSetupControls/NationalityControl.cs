using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;
namespace BSSBussinessLogic.CodeSetupControls
{
   public class NationalityControl
    {
       #region Variables
        private NationalityDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public NationalityControl()
        {
            m_Control = new NationalityDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.NationalityDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.NationalityRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.NationalityRow dataRow)
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
