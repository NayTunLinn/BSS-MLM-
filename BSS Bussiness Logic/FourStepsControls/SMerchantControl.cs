using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.FourStepsDataControls;
using BSSInfo;

namespace BSSBussinessLogic.FourStepsControls
{
    public class SMerchantControl
    {
         #region Variables
        private SMerchantDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public SMerchantControl()
        {
            m_Control = new SMerchantDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdRegister.SmallMerchantDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdRegister.SmallMerchantDataTable SelectByUpperId(string Key)
        {
            return m_Control.SelectByUpperId(Key);
        }

        public xsdRegister.SmallMerchantRow SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }
        public xsdRegister.SmallMerchantRow SelectByCodeRow(string Code)
        {
            return m_Control.SelectByCodeRow(Code);
        }
        public xsdRegister.SmallMerchantDataTable SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }
        public xsdRegister.SmallMerchantDataTable SelectByName(string Name)
        {
            return m_Control.SelectByName(Name);
        }
      
        #endregion

        #region Insert Methods
        public string Insert(xsdRegister.SmallMerchantRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdRegister.SmallMerchantRow dataRow)
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
