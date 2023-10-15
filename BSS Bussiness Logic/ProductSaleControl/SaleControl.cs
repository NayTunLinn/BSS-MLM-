using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSSDataAccess.ProductSaleDataControls;
using BSSInfo;

namespace BSSBussinessLogic.ProductSaleControl
{
   public class SaleControl
    {

        #region Variables
        private SaleDataCtrl m_Control = null;
        private GeneralControl g_control = null;
        public static string InvId { get; private set; }
        public static string InvDetailId { get; private set; }
        #endregion

        #region Constructor
        public SaleControl()
        {
            m_Control = new SaleDataCtrl();
            g_control = new GeneralControl();
        }
        #endregion

        #region Insert Methods

        public string Insert(xsdSale.InvoiceRow dataRow, xsdSale.SaleInsertDataTable InvDetailDt)
         {
            try
            {
                m_Control.StartTransaction();

                 InvId = this.m_Control.InsertHeader(dataRow);
                

                foreach ( xsdSale.SaleInsertRow dr  in InvDetailDt)
                {
                   // m_Control.SaleProductUpdate(dr.ProductId,Convert.ToInt32(dr.Qty));
                    InvDetailId=m_Control.InsertDetail(InvId, dr);

                    m_Control.InsertSaleProductSummary(dataRow.InvDate, dr.ProductId);

                    m_Control.BonusInsert(dataRow.InvDate,InvDetailId, dr.ProductId, dataRow.UpperDistributerId, dataRow.Rank, Convert.ToInt32(dr.Qty));
                }

                m_Control.CommitTransaction();
                return InvId;
            }
            catch (Exception)
            {
                m_Control.RollbackTransaction();
                throw;
            }
        }

        public void InsertSaleProductSummary(xsdSale.InvoiceRow dataRow, xsdSale.SaleInsertDataTable InvDetailDt)
        {

            try
            {
                m_Control.StartTransaction();

                foreach (xsdSale.SaleInsertRow dr in InvDetailDt)
                {
                    m_Control.InsertSaleProductSummary(dataRow.InvDate, dr.ProductId);
                }
                m_Control.CommitTransaction();
            }
            catch (Exception)
            {
                m_Control.RollbackTransaction();
                throw;
            }

        }

        #endregion
    }
}
