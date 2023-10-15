using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.ReturnDataControls
{
    public class SaleReturnDataControls:GlobalDataAccess
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
        public SaleReturnDataControls()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion

        #region Select Method

        public xsdSubStore.InvoiceStoreDataTable StoreInvoiceSelectAll()
        {
            base.sqlcmd = "InvoiceStoreSelectAll";
            xsdSubStore.InvoiceStoreDataTable dataTable = new xsdSubStore.InvoiceStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }

        public xsdSubStore.InvoiceStoreDataTable StoreInvoiceSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "InvoiceStoreSelectByDate";
            xsdSubStore.InvoiceStoreDataTable dataTable = new xsdSubStore.InvoiceStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@Invdate", invdate);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }
        public xsdSubStore.InvoiceStoreDataTable StoreInvoiceSelectByInvNo(string invno)
        {

            base.sqlcmd = "InvoiceStoreSelectByInvNo";
            xsdSubStore.InvoiceStoreDataTable dataTable = new xsdSubStore.InvoiceStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@InvNo", invno);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }

        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectAll()
        {

            base.sqlcmd = "InvoiceDetailStoreSelectAll";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }


        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "InvoiceDetailStoreSelectByDate";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@InvDate", invdate);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }


        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectByInvNo(string invno)
        {

            base.sqlcmd = "InvoiceDetailStoreSelectByInvNo";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@InvNo", invno);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }
        #endregion

        #region Insert Methods
        #region Commession
        public string BonusInsert(DateTime InvDate, string InvDetailId, string productId, string UpperdistId, string Rank, int Qty)
        
        {
            sqlcmd = "BonusEliminate";

            command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ReturnDate", InvDate);
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
        #endregion
        #region Header
        public string InsertHeader(xsdReturn.SaleReturnInvoiceRow dataRow)
        {
            sqlcmd = "SaleReturnInvoiceInfoInsert";
 
            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

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
        #endregion

        #region Detail

        public string InsertDetail(string retId, xsdReturn.SaleReturnInsertRow dr)
        {
            sqlcmd = "SaleReturnInvoiceDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@InvId", retId);
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

        #endregion

        #endregion
    }
}
