using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ProductSaleDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ProductSaleControl
{
    public class BonusControls
    {
        
        #region Variables
        private BonusDataControls b_Control = null;
        #endregion

        #region Constructor
        public BonusControls()
        {
            b_Control = new BonusDataControls();
        }
        #endregion

        #region Select Methods
        public xsdSale.BonusViewDataTable SelectAll()
        {
            return b_Control.SelectAll();
        }
        public xsdCodeSetup.BonusNameDataTable SelectName()
        {
            return b_Control.SelectName();
        }
        public xsdSale.BonusViewDataTable SelectBonusTotal(string PostSql)
        {
            return b_Control.SelectBonusTotal(PostSql);
         
        }
        public xsdSale.BonusViewDataTable SelectBonusGeneral(string PostSql)
        {
            return b_Control.SelectBonusGeneral(PostSql);
        }
        public xsdCommession.BonusDetailDataTable SelectByOverTarget(DateTime Date)
        {
            return b_Control.SelectByOverTarget(Date);
        }
        public xsdSale.BonusViewDataTable SelectByMonth(DateTime Date)
        {
            return b_Control.SelectByMonth(Date);
        }
        public xsdSale.BonusViewDataTable SelectByCode(string Code)
        {
            return b_Control.SelectByCode(Code);
        }
        public xsdSale.BonusViewDataTable SelectByName(string Name)
        {
            return b_Control.SelectByName(Name);
        }
        public xsdSale.BonusViewRow BonusSelectByCode(string Code)
        {
            return b_Control.BonusSelectByCode(Code);
        }
        public xsdSale.BonusViewDataTable SelectByInvNo(string InvNo)
        {
            return b_Control.SelectByInvNo(InvNo);
        }

        #region Bonus total select
        public xsdSale.BonusViewDataTable BonusTotalSelectByDate(DateTime startdate, DateTime enddate)
        {
            return b_Control.BonusTotalSelectByDate(startdate, enddate);
        }
        public xsdSale.BonusViewDataTable BonusTotalSelectByName(string Name)
        {
            return b_Control.BonusTotalSelectByName(Name);
        }
        public xsdSale.BonusViewDataTable BonusTotalSelectByCode(string Code)
        {
            return b_Control.BonusTotalSelectByCode(Code);
        }
        #endregion

        public xsdCommession.BonusDetailDataTable SelectDetailByDay(DateTime Date)
        {
            return b_Control.SelectDetailByDay(Date);
        }

        public xsdCommession.BonusDetailDataTable SelectDetailByFromToDate(DateTime From, DateTime To)
        {
            return b_Control.SelectDetailByFromToDate(From, To);
        }
        public xsdCommession.BonusDetailDataTable SelectDetailByMonth(DateTime Date)
        {
            return b_Control.SelectDetailByMonth(Date);
         }
        #endregion 

        public xsdCommession.BonusDetailDataTable SelectBonusDetail()
        {
            return b_Control.SelectBonusDetail();
        }
        public xsdCommession.BonusDetailRow BonusDetailSelectByDayId(DateTime Date, string Key)
        {
            return b_Control.BonusDetailSelectByDayId(Date, Key);
        }
        public xsdCommession.BonusDetailRow BonusDetailSelectByFromToID(DateTime From, DateTime To, string Key)
        {
            return b_Control.BonusDetailSelectByFromToID(From, To, Key);
        }
        public string CommessionByLevel(xsdCommession.BonusDetailRow dataRow, DateTime dt)
        {
          //  if ((object)dataRow == null) return "1";
             return b_Control.CommessionByLevel(dataRow, dt);
        }
        public xsdCommession.BonusDetailRow BonusDetailSelectByMonthId(DateTime Date, string Key)
        {
            return b_Control.BonusDetailSelectByMonthId(Date, Key);
        }
        public void ClearCommessionByLevel()
        {
            b_Control.ClearCommessionByLevel();
        }
        public xsdCommession.BonusDetailDataTable SelectCommessionByLevel()
        {
            return b_Control.SelectCommessionByLevel();
        }
    }
}
