using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
    public class ProfitrateControl
    {
        
            #region Variables
        private ProfitrateDataCtrl p_Control = null;
        private ProductDataCtrl d_Control = null;
        #endregion

        #region Constructor
        public ProfitrateControl()
        {
            p_Control = new ProfitrateDataCtrl();
            d_Control = new ProductDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.ProfitRatingsDataTable SelectAll()
        {
            return p_Control.SelectAll();
        }

        public xsdCodeSetup.ProductRow SelectByCode(string Code)
        {
            return d_Control.SelectByCode(Code);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.ProfitRatingsRow TrRow ){
            return p_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.ProfitRatingsRow dataRow)
        {
            p_Control.Update(dataRow);
        } 
        #endregion

        #region Delete
        public void Delete(string key)
        {
            p_Control.Delete(key);
        } 
        #endregion
    }
}
