﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.CodeSetupDataControls
{
   public class ProductDataCtrl:GlobalDataAccess
    {
       #region Variables
        
        #endregion

        #region Constructor
        public ProductDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        } 
        #endregion

        #region Select Methods

        public xsdCodeSetup.ProductDataTable SelectAll()
        {
          base.sqlcmd = "ProductSelect";
           // base.sqlcmd = "ProfitRatingsSelect";
            xsdCodeSetup.ProductDataTable dataTable = new xsdCodeSetup.ProductDataTable();

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

        public xsdCodeSetup.ProductRow SelectByCode(string Code)
        {
            base.sqlcmd = "ProductSelectByCode";
            xsdCodeSetup.ProductDataTable dataTable = new xsdCodeSetup.ProductDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@ProductCode", Code);
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
        #endregion

        #region transacition
        public void StartTransaction()
        {
            if (base.connection.State == ConnectionState.Closed)
            {
                base.connection.Open();
            }
            //  transaction.Connection.BeginTransaction();
            transaction = base.connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }

            if (base.connection.State == ConnectionState.Open)
            {
                base.connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }

            if (base.connection.State == ConnectionState.Open)
            {
                base.connection.Close();
            }
        }
        #endregion

        #region Insert Methods

        public string Insert(xsdCodeSetup.ProductRow dataRow)
        {
            sqlcmd = "ProductInsert";

            if (connection == null) connection = this.CreateConnection();
            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            string key = null;
            try
            {
                command.Parameters.AddWithValue("@ProductCode", dataRow.ProductCode);
                command.Parameters.AddWithValue("@ProductName", dataRow.ProductName);
                //command.Parameters.AddWithValue("@Qty", dataRow.Qty);
                command.Parameters.AddWithValue("@Price", dataRow.Price);
                //command.Parameters.AddWithValue("@ArrivalDate", dataRow.ArrivalDate);
                command.Parameters.AddWithValue("@Desp", dataRow.Desp);

                if (connection.State != ConnectionState.Open) connection.Open();
                key = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((transaction == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
            }
            return key;
        }
        public string InsertAll(xsdCodeSetup.ProductRow ProductRow, xsdCodeSetup.ProfitRatingsRow Pfrow)
        {
            sqlcmd = "ProductAndRateInsert";

            if (connection == null) connection = this.CreateConnection();
            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            string key = null;
            try
            {
                command.Parameters.AddWithValue("@ProductCode", ProductRow.ProductCode);
                command.Parameters.AddWithValue("@ProductName", ProductRow.ProductName);
                command.Parameters.AddWithValue("@Price", ProductRow.Price);
                command.Parameters.AddWithValue("@MerchantRate", Pfrow.MerchantRate);
                command.Parameters.AddWithValue("@SmerchantRate", Pfrow.SMerchantRate);
                command.Parameters.AddWithValue("@WsaleRate", Pfrow.WsaleRate);
                command.Parameters.AddWithValue("@RetailRate", Pfrow.RetailRate);
                command.Parameters.AddWithValue("@Desp", ProductRow.Desp);

                if (connection.State != ConnectionState.Open) connection.Open();
                key = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((transaction == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
            }
            return key;
        }
        #endregion

        #region Update Methods
        public void Update(xsdCodeSetup.ProductRow dataRow)
        {
            sqlcmd = "ProductUpdate";
            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@Key", dataRow.ProductId);
                command.Parameters.AddWithValue("@ProductCode", dataRow.ProductCode);
                command.Parameters.AddWithValue("@ProductName", dataRow.ProductName);
                //command.Parameters.AddWithValue("@Qty", dataRow.Qty);
                command.Parameters.AddWithValue("@Price", dataRow.Price);
                //command.Parameters.AddWithValue("@ArrivalDate", dataRow.ArrivalDate);
                command.Parameters.AddWithValue("@Desp", dataRow.Desp);
                if (connection.State != ConnectionState.Open) connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((transaction == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
            }

        }
        #endregion

        #region Delete Methods
          public void Delete(string key)
        {
            sqlcmd = "ProductDelete";

            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Key", key);

                if (connection.State != ConnectionState.Open) connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((transaction == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
            }

        }
        #endregion
    }
}
