using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.FourStepsDataControls;
using BSSInfo;

namespace BSSBussinessLogic.FourStepsControls
{
  public  class MerchantControl
    {
         #region Variables
        private MerchantDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public MerchantControl()
        {
            m_Control = new MerchantDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdRegister.MerchantDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdRegister.MerchantRow SelectByCodeRow(string Code)
        {
            return m_Control.SelectByCodeRow(Code);
        }
        public xsdRegister.MerchantDataTable SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }
        public xsdRegister.MerchantDataTable SelectByName(string Name)
        {
            return m_Control.SelectByName(Name);
        }
        public xsdRegister.MerchantRow SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdRegister.MerchantRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdRegister.MerchantRow dataRow)
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
