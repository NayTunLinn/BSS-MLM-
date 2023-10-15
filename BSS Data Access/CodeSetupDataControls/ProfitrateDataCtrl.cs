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
    public class ProfitrateDataCtrl:GlobalDataAccess
    {
        
        #region Variables
        
        #endregion

        #region Constructor
        public ProfitrateDataCtrl()
        {
        } 
        #endregion
        #region Select Methods
        public xsdCodeSetup.ProfitRatingsDataTable SelectAll()
        {
            base.sqlcmd = "ProfitRatingsSelect";
            xsdCodeSetup.ProfitRatingsDataTable dataTable = new xsdCodeSetup.ProfitRatingsDataTable();

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

        public string Insert(xsdCodeSetup.ProfitRatingsRow dataRow)
        {
            sqlcmd = "ProfitRatingsInsert";

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
                command.Parameters.AddWithValue("@MerchantRate", dataRow.MerchantRate);
                command.Parameters.AddWithValue("@SmerchantRate", dataRow.SMerchantRate);
                command.Parameters.AddWithValue("@WsaleRate", dataRow.WsaleRate);
                command.Parameters.AddWithValue("@RetailRate", dataRow.RetailRate);
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
        public void Update(xsdCodeSetup.ProfitRatingsRow dataRow)
        {
            sqlcmd = "ProfitRatingsUpdate";
            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@Key", dataRow.ProductRatingId);
                command.Parameters.AddWithValue("@ProductId", dataRow.ProductId);
                command.Parameters.AddWithValue("@MerchantRate", dataRow.MerchantRate);
                command.Parameters.AddWithValue("@SmerchantRate", dataRow.SMerchantRate);
                command.Parameters.AddWithValue("@WsaleRate", dataRow.WsaleRate);
                command.Parameters.AddWithValue("@RetailRate", dataRow.RetailRate);
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
            sqlcmd = "ProfitRatingsDelete";

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
