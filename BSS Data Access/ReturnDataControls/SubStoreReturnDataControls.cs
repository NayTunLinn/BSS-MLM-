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
    public class SubStoreReturnDataControls:GlobalDataAccess
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
        public SubStoreReturnDataControls()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion

        #region Select Method

        public xsdReturn.StoreReturnDataTable StoreReturnSelectAll()
        {
            base.sqlcmd = "StoreReturnSelect";
            xsdReturn.StoreReturnDataTable dataTable = new xsdReturn.StoreReturnDataTable();

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

        public xsdReturn.StoreReturnDataTable StoreReturnSelectByDate(DateTime Retdate)
        {

            base.sqlcmd = "StoreReturnSelectByDate";
            xsdReturn.StoreReturnDataTable dataTable = new xsdReturn.StoreReturnDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@RetDate", Retdate);

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
        public xsdReturn.StoreReturnDataTable StoreReturnSelectSelectByRetNo(string RetNo)
        {

            base.sqlcmd = "StoreReturnSelectByRetNo";
            xsdReturn.StoreReturnDataTable dataTable = new xsdReturn.StoreReturnDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@RetNo", RetNo);

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

        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectAll()
        {

            base.sqlcmd = "StoreReturnDetailSelect";
            xsdReturn.StoreReturnDetailDataTable dataTable = new xsdReturn.StoreReturnDetailDataTable();

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

        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "StoreReturnDetailSelectByDate";
            xsdReturn.StoreReturnDetailDataTable dataTable = new xsdReturn.StoreReturnDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@RetDate", invdate);
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


        public xsdReturn.StoreReturnDetailDataTable StoreReturnDetailSelectByRetNo(string RetNo)
        {

            base.sqlcmd = "StoreReturnDetailSelectByRetNo";
            xsdReturn.StoreReturnDetailDataTable dataTable = new xsdReturn.StoreReturnDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@RetNo", RetNo);

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
        public string InsertHeader(xsdReturn.StoreReturnRow dataRow,string Type)
        {
            sqlcmd = "StoreReturnInsert";

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@RetNo", dataRow.RetNo);
            command.Parameters.AddWithValue("@RetDate", dataRow.RetDate);
            command.Parameters.AddWithValue("@Total", dataRow.Total);
            command.Parameters.AddWithValue("@Desp",Type);

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

        public void InsertDetail_SaleToSub(string retId, xsdReturn.InsertProductRow dr)
        {
            sqlcmd = "StoreReturnDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@RetId", retId);
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
        public void InsertDetail_OtherToSub(string retId, xsdReturn.InsertProductRow dr)
        {
            sqlcmd = "OtherToSubStoreInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@RetId", retId);
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
        public void InsertDetail_SubToMain(string retId, xsdReturn.InsertProductRow dr)
        {
            sqlcmd = "SubToMainReturnDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@RetId", retId);
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
