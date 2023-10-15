using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSBussinessLogic.ProductSaleControl;
using BSSDataAccess.ReturnDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ReturnControls
{
    public class SubStoreReturnControl
    {
        
        #region Variables

        private SubStoreReturnDataControls r_Control = null;
        private GeneralControl g_control = null;
        public static string RetId { get; private set; }
        #endregion

        #region Constructor
        public SubStoreReturnControl()
        {
            r_Control = new SubStoreReturnDataControls();
            g_control = new GeneralControl();
        }
        #endregion

        #region Select

        public xsdReturn.StoreReturnDataTable StoreReturnSelectAll()
        {
            return StoreReturnSelectAll();
        }

        public xsdReturn.StoreReturnDataTable StoreReturnSelectByDate(DateTime Retdate)
        {
            return StoreReturnSelectByDate(Retdate);
        }

        public xsdReturn.StoreReturnDataTable StoreReturnSelectSelectByRetNo(string RetNo)
        {
            return r_Control.StoreReturnSelectSelectByRetNo(RetNo);
        }


        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectAll()
        {
            return StoreReturnDetailSelectAll();
        }

        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectByDate(DateTime RetDate)
        {
            return StoreReturnDetailSelectByDate(RetDate);
        }


        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectByRetNo(string RetNo)
        {
            return StoreReturnDetailSelectByRetNo(RetNo);
        }
        
        #endregion

        #region Insert Methods

        //By Michael
        //Transaction Succeed 
        //header and detail (master)
        public string Insert_OtherToSub(xsdReturn.StoreReturnRow dataRow, xsdReturn.InsertProductDataTable InvDetailDt)
        {
            try
            {
                r_Control.StartTransaction();
                RetId = this.r_Control.InsertHeader(dataRow, "OtherToSub");

                foreach (xsdReturn.InsertProductRow dr in InvDetailDt)
                {
                    r_Control.InsertDetail_OtherToSub(RetId, dr);
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
        public string Insert_SaleToSub(xsdReturn.StoreReturnRow dataRow, xsdReturn.InsertProductDataTable InvDetailDt)
        {
            try
            {
                r_Control.StartTransaction();
                RetId = this.r_Control.InsertHeader(dataRow,"SaleToSub");

                foreach (xsdReturn.InsertProductRow dr in InvDetailDt)
                 {
                     r_Control.InsertDetail_SaleToSub(RetId, dr);
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
        public string Insert_SubToMain(xsdReturn.StoreReturnRow dataRow, xsdReturn.InsertProductDataTable InvDetailDt)
        {
            try
            {
                r_Control.StartTransaction();
                RetId = this.r_Control.InsertHeader(dataRow,"SubToMain");

                foreach (xsdReturn.InsertProductRow dr in InvDetailDt)
                {
                    r_Control.InsertDetail_SubToMain(RetId, dr);
                }

                ////transaction testing
                //int[] i = new int[2];
                //i[23] = 232;

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
