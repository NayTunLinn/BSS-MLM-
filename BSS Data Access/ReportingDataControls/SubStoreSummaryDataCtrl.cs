using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.ReportingDataControls
{
    public class SubStoreSummaryDataCtrl:GlobalDataAccess
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
        
        #endregion

        #region Constructor
        public SubStoreSummaryDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        } 
        #endregion

        #region Select By Key Methods

        public xsdSummary.SubStoreProductSummaryDataTable AllStoreProductSummerySelectByDay(DateTime SearchDate)
        {
            base.sqlcmd = "AllStoreProductSummerySelectByDay";
            xsdSummary.SubStoreProductSummaryDataTable dataTable = new xsdSummary.SubStoreProductSummaryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@FinalDate", SearchDate);

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
        public xsdSummary.SubStoreProductSummaryDataTable StroeProductSummerySelectAll()
        {
            base.sqlcmd = "AllStoreProductSummerySelect";
            xsdSummary.SubStoreProductSummaryDataTable dataTable = new xsdSummary.SubStoreProductSummaryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
              //  command.Parameters.AddWithValue("@InvId", Key);

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
        public xsdSummary.SubStoreProductSummaryDataTable AllStoreProductSummerySelectByMonth(DateTime FinalDate)
        {
            base.sqlcmd = "AllStoreProductSummerySelectByMonth";
            xsdSummary.SubStoreProductSummaryDataTable dataTable = new xsdSummary.SubStoreProductSummaryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@FinalDate", FinalDate);

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

        public void InsertStoreProductSummary(DateTime InvDate, string ProductId)
        {
            sqlcmd = "StoreProductSummeryByDay";

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
    }
}
