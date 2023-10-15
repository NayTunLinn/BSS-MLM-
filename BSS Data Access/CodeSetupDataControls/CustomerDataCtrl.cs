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
    public class CustomerDataCtrl:GlobalDataAccess
    {
        #region Variables
        
        #endregion

        #region Constructor
        public CustomerDataCtrl()
        {
        } 
        #endregion

        #region Select By Key Methods

        public xsdCodeSetup.CustomerRow SelectByKey(string Key)
        {
            base.sqlcmd = "CustomerSelectByKey";
            xsdCodeSetup.CustomerDataTable dataTable = new xsdCodeSetup.CustomerDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Key", Key);

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

        public xsdCodeSetup.CustomerRow SelectByCode(string Code)
        {
            base.sqlcmd = "CustomerSelectByCode";
            xsdCodeSetup.CustomerDataTable dataTable = new xsdCodeSetup.CustomerDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Code", Code);

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

        #region Select Methods

        public xsdCodeSetup.CustomerDataTable SelectAll()
        {
            base.sqlcmd = "CustomerSelect";
            xsdCodeSetup.CustomerDataTable dataTable = new xsdCodeSetup.CustomerDataTable();

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

        public string Insert(xsdCodeSetup.CustomerRow dataRow)
        {
            sqlcmd = "CustomerInsert";

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
            
                command.Parameters.AddWithValue("@CustomerImg",dataRow.CustomerImg);
                command.Parameters.AddWithValue("@CustomerCode",dataRow.CustomerCode);
                command.Parameters.AddWithValue("@CustomerName",dataRow.CustomerName);
                command.Parameters.AddWithValue("@Phone",dataRow.Phone);
                command.Parameters.AddWithValue("@DivId",dataRow.DivId);
                command.Parameters.AddWithValue("@CityId", dataRow.CityId);
                command.Parameters.AddWithValue("@Address",dataRow.Address);
                command.Parameters.AddWithValue("@Email",dataRow.Email);
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
        #endregion

        #region Update Methods
        public void Update(xsdCodeSetup.CustomerRow dataRow)
        {
            sqlcmd = "CustomerUpdate";
            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            try
            {

                command.Parameters.AddWithValue("@CustomerId", dataRow.CustomerId);
                command.Parameters.AddWithValue("@CustomerImg", dataRow.CustomerImg);
                command.Parameters.AddWithValue("@CustomerCode", dataRow.CustomerCode);
                command.Parameters.AddWithValue("@CustomerName", dataRow.CustomerName);
                command.Parameters.AddWithValue("@Phone", dataRow.Phone);
                command.Parameters.AddWithValue("@DivId", dataRow.DivId);
                command.Parameters.AddWithValue("@CityId", dataRow.CityId);
                command.Parameters.AddWithValue("@Address", dataRow.Address);
                command.Parameters.AddWithValue("@Email", dataRow.Email);
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
            sqlcmd = "CustomerDelete";

            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@CustomerId", key);

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
