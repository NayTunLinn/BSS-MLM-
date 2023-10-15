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
    public class AllProductSummeryDataCtrl:GlobalDataAccess
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
        public AllProductSummeryDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        } 
        #endregion

        #region Select By Key Methods

        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectByDate(DateTime FinalDate)
        {
            base.sqlcmd = "AllProductSummerySelectByDay";
            xsdSummary.SaleProductSummaryDataTable dataTable = new xsdSummary.SaleProductSummaryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", FinalDate);

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
        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectAll()
        {
            base.sqlcmd = "AllProductSummerySelect";
            xsdSummary.SaleProductSummaryDataTable dataTable = new xsdSummary.SaleProductSummaryDataTable();

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
        public xsdSummary.SaleProductSummaryDataTable AllProductSummerySelectByMonth(DateTime FinalDate)
        {
            base.sqlcmd = "AllProductSummerySelectByMonth";
            xsdSummary.SaleProductSummaryDataTable dataTable = new xsdSummary.SaleProductSummaryDataTable();

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

        public void InsertSaleProductSummary(DateTime InvDate, string ProductId)
        {
            sqlcmd = "ProductSummeryByDay";

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
