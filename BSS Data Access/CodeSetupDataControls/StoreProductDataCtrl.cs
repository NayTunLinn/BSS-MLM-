using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.CodeSetupDataControls
{
    public class StoreProductDataCtrl:GlobalDataAccess
    {
        
       #region Variables
        
        #endregion

        #region Constructor
        public StoreProductDataCtrl()
        {
        } 
        #endregion

        #region Select Methods

        public xsdSubStore.StoreProductDataTable SelectAll()
        {
            base.sqlcmd = "StoreProductSelect";
            xsdSubStore.StoreProductDataTable dataTable = new xsdSubStore.StoreProductDataTable();

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

        public xsdSubStore.StoreProductRow SelectByCode(string Code)
        {
            base.sqlcmd = "ProductSelectByCode";
            xsdSubStore.StoreProductDataTable dataTable = new xsdSubStore.StoreProductDataTable();

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

        #region Insert Methods

        public string Insert(xsdSubStore.StoreProductRow dataRow)
        {
            sqlcmd = "StoreProductInsert";

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
                command.Parameters.AddWithValue("@Price", dataRow.Price);
                //command.Parameters.AddWithValue("@ArrivalDate", dataRow);

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
        public void Update(xsdSubStore.StoreProductRow dataRow)
        {
            sqlcmd = "StoreProductUpdate";
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
                command.Parameters.AddWithValue("@Price", dataRow.Price);

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



        /// <summary>
        /// Product record for store
        /// </summary>
        /// <returns></returns>
        #region StoreRecord

          public xsdSubStore.StoreRecordDataTable StoreRecordSelectAll()
          {
              base.sqlcmd = "StoreRecordSelect";
              xsdSubStore.StoreRecordDataTable dataTable = new xsdSubStore.StoreRecordDataTable();

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


          public xsdSubStore.StoreRecordDataTable StoreRecordSelectByDate(DateTime fromDate, DateTime toDate)
          {
              base.sqlcmd = "StoreRecordSelectByDate";
              xsdSubStore.StoreRecordDataTable dataTable = new xsdSubStore.StoreRecordDataTable();

              base.connection = this.CreateConnection();
              base.command = new SqlCommand(sqlcmd, connection);

              base.command.CommandType = CommandType.StoredProcedure;
              base.command.Parameters.AddWithValue("@fromDate", fromDate);
              base.command.Parameters.AddWithValue("@toDate", toDate);

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

          #region RecordInsert
          public string RecordInsert(xsdSubStore.StoreRecordRow dataRow)
          {
              sqlcmd = "StoreRecordInsert";

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
                  command.Parameters.AddWithValue("@ProductId", dataRow.ProductId);
                  command.Parameters.AddWithValue("@Total", dataRow.Total);
                  command.Parameters.AddWithValue("@ArrivalDate", dataRow.ArrivalDate);

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
          public void RecordUpdate(xsdSubStore.StoreRecordRow dataRow)
          {
              sqlcmd = "StoreRecordUpdate";
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
                  command.Parameters.AddWithValue("@ProductId", dataRow.ProductId);
                  command.Parameters.AddWithValue("@Total", dataRow.Total);
                  command.Parameters.AddWithValue("@ArrivalDate", dataRow.ArrivalDate);
      
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
          public void RecordDelete(string key)
          {
              sqlcmd = "";

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
