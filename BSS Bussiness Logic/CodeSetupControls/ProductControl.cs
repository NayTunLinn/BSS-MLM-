using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.CodeSetupDataControls;
using BSSInfo;

namespace BSSBussinessLogic.CodeSetupControls
{
   public class ProductControl
    {
        #region Variables
        private ProductDataCtrl m_Control = null;
        private ProfitrateDataCtrl p_control = null;
        #endregion

        #region Constructor
        public ProductControl()
        {
            m_Control = new ProductDataCtrl();
            p_control = new ProfitrateDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdCodeSetup.ProductDataTable SelectAll()
        {
            return m_Control.SelectAll();
        }

        public xsdCodeSetup.ProductRow SelectByCode(string Code)
        {
            return m_Control.SelectByCode(Code);
        }
        #endregion

        #region Insert Methods
        public string Insert(xsdCodeSetup.ProductRow dataRow)
        {
            return m_Control.Insert(dataRow);
        }
       public string InsertAll(xsdCodeSetup.ProductRow ProductRow, xsdCodeSetup.ProfitRatingsRow Pfrow)
        {
            return m_Control.InsertAll(ProductRow, Pfrow);
        }
        #endregion

        #region Update
        public void Update(xsdCodeSetup.ProductRow dataRow)
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
