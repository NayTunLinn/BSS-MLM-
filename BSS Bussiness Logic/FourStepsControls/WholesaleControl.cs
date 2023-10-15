using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.FourStepsDataControls;
using BSSInfo;
namespace BSSBussinessLogic.FourStepsControls
{
   public class WholesaleControl
    {
       
         #region Variables
        private WholesaleDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public WholesaleControl()
        {
            m_Control = new WholesaleDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdRegister.WholesaleDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }
        public xsdRegister.WholesaleDataTable SelectByUpperId(string Key)
        {
            return m_Control.SelectByUpperId(Key);
        }

        public xsdRegister.WholesaleRow SelectByKey(string Key)
        {
            return m_Control.SelectByKey(Key);
        }
        public xsdRegister.WholesaleRow SelectByCodeRow(string Code)
        {
            return m_Control.SelectByCodeRow(Code);
        }
        public xsdRegister.WholesaleDataTable SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }
        public xsdRegister.WholesaleDataTable SelectByName(string Name)
        {
            return m_Control.SelectByName(Name);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdRegister.WholesaleRow TrRow ){
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdRegister.WholesaleRow dataRow)
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
