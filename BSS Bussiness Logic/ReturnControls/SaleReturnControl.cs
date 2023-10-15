using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSBussinessLogic.ProductSaleControl;
using BSSDataAccess.ReturnDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ReturnControls
{
    public class SaleReturnControl
    {
        
        #region Variables
        private SaleReturnDataControls r_Control = null;
        private GeneralControl g_control = null;
        public static string RetId { get; private set; }
        #endregion

        #region Constructor
        public SaleReturnControl()
        {
            r_Control = new SaleReturnDataControls();
            g_control = new GeneralControl();
        }
        #endregion

        #region Insert Methods

        //By Michael
        //Transaction Succeed 
        //header and detail (master)
        public string Insert(xsdReturn.SaleReturnInvoiceRow dataRow, xsdReturn.SaleReturnInsertDataTable InvDetailDt)
        {
            try
            {
                r_Control.StartTransaction();
                RetId = this.r_Control.InsertHeader(dataRow);

                foreach (xsdReturn.SaleReturnInsertRow dr in InvDetailDt)
                 {
                     string InvDetailId = r_Control.InsertDetail(RetId, dr);
                     r_Control.BonusInsert(dataRow.InvDate,InvDetailId, dr.ProductId, dataRow.UpperDistributerId, dataRow.Rank, Convert.ToInt32(dr.Qty));
                 }

                r_Control.CommitTransaction();
                return RetId;
            }
            catch (Exception)
            {
                r_Control.RollbackTransaction();
                throw;
            }
        }

        #endregion
    }
}
