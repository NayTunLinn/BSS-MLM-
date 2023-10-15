using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class RaceControl
    {
        #region Variables
        private RaceDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public RaceControl()
        {
            m_Control = new RaceDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.RaceDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.RaceRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.RaceRow dataRow)
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
