using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ProductSaleDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ProductSaleControl
{
   public class GeneralControl
    {
          #region Variables
        private GeneralDataCtrl m_Control = null;
        #endregion

        #region Constructor
        public GeneralControl()
        {
            m_Control = new GeneralDataCtrl();
        }
        #endregion

        #region Select Methods
        public xsdSale.AllCustomerCodeDataTable SelectAllCustomerCode()
        {
            return m_Control.SelectAllCustomerCode();
        }

        public xsdCodeSetup.CustomerRow CustomerSelectByCode(string Code)
        {
            return m_Control.CustomerSelectByCode(Code);
        }
        public xsdSale.InvoiceDataTable SelectAllInvoice()
        {
            return m_Control.SelectAllInvoice();
        }
        public string GenerateCode(string Type)
        {
            return m_Control.GenerateCode(Type);
        }
        public string FakeGenerateCode(string Type)
        {
            return m_Control.FakeGenerateCode(Type);
        }
        public string AutoGenerateCode(string Type)
        {
            return m_Control.AutoGenerateCode(Type);
        }

        public xsdSale.BonusViewDataTable SelectAllBonus()
        {
            return m_Control.SelectAllBonus();
        }
        public xsdSale.BonusViewDataTable BonusSelectByCode(string Code)
        {
            return m_Control.BonusSelectByCode(Code);
        }
        public xsdSale.BonusViewDataTable BonusSelectByName(string Name)
        {
            return m_Control.BonusSelectByName(Name);
        }
        #endregion

        //public string BonusInsert(string InvId, string productId, string UpperdistId, string Rank, int Qty)
        //{
        //    return m_Control.BonusInsert(InvId, productId, UpperdistId, Rank, Qty);
        //}
    }
}
