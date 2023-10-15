using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class CityControl
    {
            #region Variables
        private CityDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public CityControl()
        {
            m_Control = new CityDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.CityDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdCodeSetup.CityDataTable SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.CityRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.CityRow dataRow)
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
