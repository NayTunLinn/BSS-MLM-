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
    public class MainStoreDataCtrl:GlobalDataAccess
    {

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

        /// <summary>
        /// Product record for store
        /// </summary>
        /// <returns></returns>
        public xsdMainstore.MainStoreProductDataTable MainStoreProductSelect()
        {
            base.sqlcmd = "MainStoreProductSelect";
            xsdMainstore.MainStoreProductDataTable dataTable = new xsdMainstore.MainStoreProductDataTable();

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

        #region MainStoreRecord
        public xsdMainstore.MainStoreRecordDataTable MainStoreRecordSelectAll()
        {
            base.sqlcmd = "MainStoreRecordSelect";
            xsdMainstore.MainStoreRecordDataTable dataTable = new xsdMainstore.MainStoreRecordDataTable();

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


        public xsdMainstore.MainStoreRecordDataTable MainStoreRecordSelectByDate(DateTime fromDate, DateTime toDate)
        {
            base.sqlcmd = "MainStoreRecordSelectByDate";
            xsdMainstore.MainStoreRecordDataTable dataTable = new xsdMainstore.MainStoreRecordDataTable();

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
        public string MainStoreRecordInsert(xsdMainstore.MainStoreRecordRow dataRow)
        {
            sqlcmd = "MainStoreRecordInsert";

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

    }
}
