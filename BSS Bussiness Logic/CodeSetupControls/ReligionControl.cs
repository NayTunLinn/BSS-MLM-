using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class ReligionControl
    {
        #region Variables
        private ReligionDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public ReligionControl()
        {
            m_Control = new ReligionDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.ReligionDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.ReligionRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.ReligionRow dataRow)
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
