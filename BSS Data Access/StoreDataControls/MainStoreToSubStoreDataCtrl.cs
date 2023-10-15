using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.StoreDataControls
{
    public class MainStoreToSubStoreDataCtrl:GlobalDataAccess
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
        public MainStoreToSubStoreDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion

        #region Select Method
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByGroup()
        {

            base.sqlcmd = "MainStoreInvoiceSelectByGroup";
            xsdMainstore.MainStoreInvoiceDataTable dataTable = new xsdMainstore.MainStoreInvoiceDataTable();

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
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectAll()
        {
            base.sqlcmd = "MainStoreInvoiceSelectAll";
            xsdMainstore.MainStoreInvoiceDataTable dataTable = new xsdMainstore.MainStoreInvoiceDataTable();

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
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "MainStoreInvoiceSelectByDate";
            xsdMainstore.MainStoreInvoiceDataTable dataTable = new xsdMainstore.MainStoreInvoiceDataTable();

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
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByMonth(DateTime invdate)
        {

            base.sqlcmd = "MainStoreInvoiceSelectByMonth";
            xsdMainstore.MainStoreInvoiceDataTable dataTable = new xsdMainstore.MainStoreInvoiceDataTable();

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
        public xsdMainstore.MainStoreInvoiceDataTable MainStoreInvoiceSelectByInvNo(string invno)
        {

            base.sqlcmd = "MainStoreInvoiceSelectByInvNo";
            xsdMainstore.MainStoreInvoiceDataTable dataTable = new xsdMainstore.MainStoreInvoiceDataTable();

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

        public xsdMainstore.MainStoreInvoiceDetailDataTable MainStoreInvoiceDetailSelectAll()
        {

            base.sqlcmd = "MainStoreInvoiceDetailsSelectAll";
            xsdMainstore.MainStoreInvoiceDetailDataTable dataTable = new xsdMainstore.MainStoreInvoiceDetailDataTable();

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
        public xsdMainstore.MainStoreInvoiceDetailDataTable MainStoreInvoiceDetailSelectByInvNo(string invno)
        {

            base.sqlcmd = "MainStoreInvoiceDetailsSelectByInvNo";
            xsdMainstore.MainStoreInvoiceDetailDataTable dataTable = new xsdMainstore.MainStoreInvoiceDetailDataTable();

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

        /** for mainstroe detail amount of product price
        public xsdMainstore.MainStoreInvoiceDetailRow MainStoreInvoiceDetailSelectByInvNoForReport(string invno)
         
        {

            base.sqlcmd = "MainStoreInvoiceDetailsSelectByInvNo";
            xsdMainstore.MainStoreInvoiceDetailDataTable dataTable = new xsdMainstore.MainStoreInvoiceDetailDataTable();

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
            if (dataTable.Rows.Count > 0)
                return dataTable[0];

            return null;
        }
         * * */
        #endregion

        #region BalanceStoreProductSelect
        public xsdSubStore.BalanceStoreProductDataTable BalanceStoreProductSelect()
        {
            base.sqlcmd = "BalanceStoreProductSelect";
            xsdSubStore.BalanceStoreProductDataTable dataTable = new xsdSubStore.BalanceStoreProductDataTable();

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
        #endregion

        #region Insert Methods

        #region Header

        public string InsertHeader(xsdMainstore.MainStoreInvoiceRow dataRow)
        {
            sqlcmd = "MainStoreInvoiceInsert";

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@InvNo", dataRow.InvNo);
            command.Parameters.AddWithValue("@InvDate", dataRow.InvDate);
            command.Parameters.AddWithValue("@Total", dataRow.TotalProduct);
            command.Parameters.AddWithValue("@Desp", dataRow.Desp);

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

        public void InsertDetail(string InvId, xsdMainstore.StoreProductInsertRow dr)
        {
            sqlcmd = "MainStoreInvoiceDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@InvId", InvId);
                command.Parameters.AddWithValue("@ProductId", dr.ProductId);
                command.Parameters.AddWithValue("@ProductQty", dr.Total);

                detailKey = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

           // return detailKey;
        }

        #endregion

        #endregion
    }
}
