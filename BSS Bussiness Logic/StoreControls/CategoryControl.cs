using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.StoreDataControls;
using BSSInfo;

namespace BSSBussinessLogic.StoreControls
{
    public class CategoryControl
    {
        
            #region Variables
        private CategoryDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public CategoryControl()
        {
            m_Control = new CategoryDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdSubStore.StoreCategoryDataTable SelectAll()
        {
            return m_Control.CategorySelectAll();
        }

        #endregion

        #region Insert Methods

        public string Insert(xsdSubStore.StoreCategoryRow TrRow)
        {
            return m_Control.Insert(TrRow);
        }
        #endregion

        #region Update
        public void Update(xsdSubStore.StoreCategoryRow dataRow)
        {
            m_Control.Update(dataRow);
        } 
        #endregion
    }
}
