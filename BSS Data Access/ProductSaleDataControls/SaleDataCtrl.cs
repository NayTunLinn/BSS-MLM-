using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.ProductSaleDataControls
{
  public class SaleDataCtrl:GlobalDataAccess
    {
         #region transacition
        public void StartTransaction()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //  transaction.Connection.BeginTransaction();
            transaction = connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        #endregion

        #region Variables
       // SqlConnection connection;
       // SqlTransaction transaction;
        #endregion

        #region Constructor
        public SaleDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion

        #region Insert Methods

        #region Header

        public string BonusInsert(DateTime InvDate,string InvDetailId, string productId, string UpperdistId, string Rank, int Qty)
        {
            sqlcmd = "CaculateBonus";

            command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@InvDate", InvDate);
            command.Parameters.AddWithValue("@InvDetailId", InvDetailId);
            command.Parameters.AddWithValue("@UpperDistributorId", UpperdistId);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@Rank", Rank.Trim());
            command.Parameters.AddWithValue("@Qty", Qty);

            string key = null;
            try
            {
                key = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return key;
        }
        
        public string InsertHeader(xsdSale.InvoiceRow dataRow)
        {
            sqlcmd = "SaleInvoiceInfoInsert";

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

           // command.Parameters.AddWithValue("@CustomerId", dataRow.CustomerId);
            command.Parameters.AddWithValue("@UpperDistributerId", dataRow.UpperDistributerId);
            command.Parameters.AddWithValue("@InvNo", dataRow.InvNo);
            command.Parameters.AddWithValue("@InvDate", dataRow.InvDate);
            command.Parameters.AddWithValue("@Title", dataRow.Title);
            command.Parameters.AddWithValue("@TotalAmount", dataRow.TotalAmount);
            command.Parameters.AddWithValue("@Desp", dataRow.Desp);
            command.Parameters.AddWithValue("@UpperDistCode", dataRow.UpperDistCode);
            command.Parameters.AddWithValue("@UpperDistName", dataRow.UpperDistName);
            command.Parameters.AddWithValue("@IntroCode", dataRow.IntroCode);
            command.Parameters.AddWithValue("@IntroName", dataRow.IntroName);

            string key = null;
            try
            {
                key = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return key;
        }


        public void InsertSaleProductSummary(DateTime InvDate, string ProductId)
        {
            sqlcmd = "ProductSummeryByDay";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@Date", InvDate);
                command.Parameters.AddWithValue("@ProductId", ProductId);

                detailKey = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Detail

        public string InsertDetail(string InvId, xsdSale.SaleInsertRow dr)
        {
            sqlcmd = "SaleInvoiceDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@InvId", InvId);
                command.Parameters.AddWithValue("@ProductId", dr.ProductId);
                command.Parameters.AddWithValue("@ProductQty", dr.Qty);

                detailKey = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detailKey;
        }
        public string SaleProductUpdate(string ProductId, int Qty)
        {
            sqlcmd = "CheckProductFromStore";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
            
                command.Parameters.AddWithValue("@ProductId", ProductId);
                command.Parameters.AddWithValue("@ProductQty", Qty);

                detailKey = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detailKey;
        }
        #endregion

        #endregion
    }
}
