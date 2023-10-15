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
   public class CompanyDataCtrl:GlobalDataAccess
    {
        #region Variables
        
        #endregion

        #region Constructor
       public CompanyDataCtrl()
        {
        } 
        #endregion

        #region Select Methods

        public xsdCodeSetup.CompanyDataTable SelectAll()
        {
            base.sqlcmd = "CompanySelect";
            xsdCodeSetup.CompanyDataTable dataTable = new xsdCodeSetup.CompanyDataTable();

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
        public xsdCodeSetup.CompanyRow SelectByKey(string Key)
        {
            base.sqlcmd = "CompanySelectByKey";
            xsdCodeSetup.CompanyDataTable dataTable = new xsdCodeSetup.CompanyDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@CompanyId",Key);
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
        public xsdCodeSetup.CompanyRow SelectAllRow()
        {
            base.sqlcmd = "CompanySelect";
            xsdCodeSetup.CompanyDataTable dataTable = new xsdCodeSetup.CompanyDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                //command.Parameters.AddWithValue("@CompanyId", Key);
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

        //public string Insert(xsdCodeSetup.CompanyRow dataRow)
        //{
        //    sqlcmd = "CompanyInsert";

        //    if (connection == null) connection = this.CreateConnection();
        //    SqlCommand command = null;
        //    if (transaction == null)
        //        command = new SqlCommand(sqlcmd, connection);
        //    else
        //        command = new SqlCommand(sqlcmd, connection, transaction);

        //    command.CommandType = CommandType.StoredProcedure;

        //    string key = null;
        //    try
        //    {
        //        command.Parameters.AddWithValue("@RetailerId", dataRow.RetailerId);
        //        command.Parameters.AddWithValue("@CompanyImg",dataRow.CompanyImg);
        //        command.Parameters.AddWithValue("@CompanyCode",dataRow.CompanyCode);
        //        command.Parameters.AddWithValue("@CompanyName",dataRow.CompanyName);
        //        command.Parameters.AddWithValue("@Phone",dataRow.Phone);
        //        command.Parameters.AddWithValue("@DivId",dataRow.DivId);
        //        command.Parameters.AddWithValue("@CityId", dataRow.CityId);
        //        command.Parameters.AddWithValue("@Address",dataRow.Address);
        //        command.Parameters.AddWithValue("@Email",dataRow.Email);
        //        command.Parameters.AddWithValue("@Desp", dataRow.Desp);
               
        //        if (connection.State != ConnectionState.Open) connection.Open();
        //        key = (string)command.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if ((transaction == null) && (connection.State == ConnectionState.Open))
        //            connection.Close();
        //    }
        //    return key;
        //}
        #endregion

        #region Update Methods
        //public void Update(xsdCodeSetup.CompanyRow dataRow)
        //{
        //    sqlcmd = "CompanyUpdate";
        //    if (connection == null) connection = this.CreateConnection();

        //    SqlCommand command = null;
        //    if (transaction == null)
        //        command = new SqlCommand(sqlcmd, connection);
        //    else
        //        command = new SqlCommand(sqlcmd, connection, transaction);

        //    command.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        command.Parameters.AddWithValue("@RetailerId", dataRow.RetailerId);
        //        command.Parameters.AddWithValue("@CompanyImg", dataRow.CompanyImg);
        //        command.Parameters.AddWithValue("@CompanyCode", dataRow.CompanyCode);
        //        command.Parameters.AddWithValue("@CompanyName", dataRow.CompanyName);
        //        command.Parameters.AddWithValue("@Phone", dataRow.Phone);
        //        command.Parameters.AddWithValue("@DivId", dataRow.DivId);
        //        command.Parameters.AddWithValue("@CityId", dataRow.CityId);
        //        command.Parameters.AddWithValue("@Address", dataRow.Address);
        //        command.Parameters.AddWithValue("@Email", dataRow.Email);
        //        command.Parameters.AddWithValue("@Desp", dataRow.Desp);

        //        if (connection.State != ConnectionState.Open) connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if ((transaction == null) && (connection.State == ConnectionState.Open))
        //            connection.Close();
        //    }

        //}
        #endregion

        #region Delete Methods
        //  public void Delete(string key)
        //{
        //    sqlcmd = "CompanyDelete";

        //    if (connection == null) connection = this.CreateConnection();

        //    SqlCommand command = null;
        //    if (transaction == null)
        //        command = new SqlCommand(sqlcmd, connection);
        //    else
        //        command = new SqlCommand(sqlcmd, connection, transaction);

        //    command.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        command.Parameters.AddWithValue("@Key", key);

        //        if (connection.State != ConnectionState.Open) connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if ((transaction == null) && (connection.State == ConnectionState.Open))
        //            connection.Close();
        //    }

        //}
        #endregion
    }
}
