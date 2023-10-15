using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.FourStepsDataControls;
using BSSInfo;

namespace BSSBussinessLogic.FourStepsControls
{
    public class RetailerControl
    {
        
         #region Variables
        private RetailerDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public RetailerControl()
        {
            m_Control = new RetailerDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdRegister.RetailerDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdRegister.RetailerDataTable SelectByUpperId(string Key)
        {
            return m_Control.SelectByUpperId(Key);
        }

        public xsdRegister.RetailerDataTable SelectByName(string Name)
        {
            return m_Control.SelectByName(Name);
        }
        public xsdRegister.RetailerRow SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }

        public xsdRegister.RetailerRow SelectByCodeRow(string Code)
        {
            return m_Control.SelectByCodeRow(Code);
        }
        public xsdRegister.RetailerDataTable SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }

        #endregion

        #region Insert Methods
        public string Insert(xsdRegister.RetailerRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdRegister.RetailerRow dataRow)
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
