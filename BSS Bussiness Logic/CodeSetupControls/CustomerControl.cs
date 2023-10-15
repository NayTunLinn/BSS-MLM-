using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class CustomerControl
    {
         #region Variables
        private CustomerDataCtrl c_Control = null;
        #endregion

        #region Constructor
        public CustomerControl()
        {
            c_Control = new CustomerDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.CustomerDataTable SelectAll()
        {
            return c_Control.SelectAll();
        }
        public xsdCodeSetup.CustomerRow SelectByKey(string Key)
        {
            return c_Control.SelectByKey(Key);
        }
        public xsdCodeSetup.CustomerRow SelectByCode(string Code)
        {
            return c_Control.SelectByCode(Code);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.CustomerRow TrRow ){
            return c_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.CustomerRow dataRow)
        {
            c_Control.Update(dataRow);
        } 
        #endregion

        #region Delete
        public void Delete(string key)
        {
            c_Control.Delete(key);
        } 
        #endregion
    }
    }

