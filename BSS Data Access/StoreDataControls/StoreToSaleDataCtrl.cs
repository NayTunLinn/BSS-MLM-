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
    public class StoreToSaleDataCtrl : GlobalDataAccess
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
        public StoreToSaleDataCtrl()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion

        #region Summery
        public XsdProductSummery.SubStoreSummeryDataTable SaleStoreSummeryByDay(DateTime Date)
        {
            base.sqlcmd = "SaleStoreSummerySelectByDay";
            XsdProductSummery.SubStoreSummeryDataTable dataTable = new XsdProductSummery.SubStoreSummeryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            base.command.Parameters.AddWithValue("@Date", Date);
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
        #region Sub Store Summery

        public XsdProductSummery.SubStoreSummeryDataTable SubStoreSummeryByDay(DateTime Date)
        {

            base.sqlcmd = "SubStoreSummerySelectByDay";
            XsdProductSummery.SubStoreSummeryDataTable dataTable = new XsdProductSummery.SubStoreSummeryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            base.command.Parameters.AddWithValue("@Date", Date);
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
        public XsdProductSummery.SubStoreSummeryDataTable SubStoreSummeryByMonth(DateTime Date)
        {
            base.sqlcmd = "SubStoreSummerySelectByMonth";
            XsdProductSummery.SubStoreSummeryDataTable dataTable = new XsdProductSummery.SubStoreSummeryDataTable();
              
            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure; 

            base.command.Parameters.AddWithValue("@Date", Date);
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
        public void SubStoreSummeryLoopByDay()
        {
            base.sqlcmd = "SubStoreSummeryLoopByDay";
            XsdProductSummery.SubStoreSummeryDataTable dataTable = new XsdProductSummery.SubStoreSummeryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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


        } 
        #endregion
        public void SaleStoreSummeryLoopByDay()
        {
            base.sqlcmd = "SaleStoreSummeryLoopByDay";
            XsdProductSummery.SubStoreSummeryDataTable dataTable = new XsdProductSummery.SubStoreSummeryDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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


        }
        #endregion

        #region Select Method
    
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectAll()
        {
            base.sqlcmd = "InvoiceStoreSelectAll";
            xsdSubStore.StoreInvoiceReportDataTable dataTable = new xsdSubStore.StoreInvoiceReportDataTable();

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
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "InvoiceStoreSelectByDate";
            xsdSubStore.StoreInvoiceReportDataTable dataTable = new xsdSubStore.StoreInvoiceReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@Invdate", invdate);

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
        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByInvNo(string invno)
        {

            base.sqlcmd = "InvoiceStoreSelectByInvNo";
            xsdSubStore.StoreInvoiceReportDataTable dataTable = new xsdSubStore.StoreInvoiceReportDataTable();

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

        public xsdSubStore.StoreInvoiceReportDataTable  StoreInvoiceSelectByInvType(string InvType)
        {

            base.sqlcmd = "InvoiceStoreSelectByInvType";
            xsdSubStore.StoreInvoiceReportDataTable dataTable = new xsdSubStore.StoreInvoiceReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@InvType", InvType);

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

        public xsdSubStore.StoreInvoiceReportDataTable StoreInvoiceSelectByInvTypeAndDate(string InvType,DateTime date)
        {

            base.sqlcmd = "InvoiceStoreSelectByInvTypeAndDate";
            xsdSubStore.StoreInvoiceReportDataTable dataTable = new xsdSubStore.StoreInvoiceReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@InvType", InvType);
            base.command.Parameters.AddWithValue("@Invdate", date);

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
        /** No Need for this Detail
        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectAll()
        {

            base.sqlcmd = "InvoiceDetailStoreSelectAll";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

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
        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectByDate(DateTime invdate)
        {

            base.sqlcmd = "InvoiceDetailStoreSelectByDate";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

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
        public xsdSubStore.InvoiceDetailStoreDataTable StoreInvoiceDetailSelectByInvNo(string invno)
        {

            base.sqlcmd = "InvoiceDetailStoreSelectByInvNo";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

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
        public xsdSubStore.InvoiceDetailStoreDataTable InvoiceReceiptById(string Key)
        {
            base.sqlcmd = "ReportInvoiceDetailsSelectById";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@InvId", Key);

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
        **/

        public xsdSubStore.InvoiceDetailStoreRow InvoiceReceiptRowById(string Key)
        {

            base.sqlcmd = "StoreInvoiceReceiptById";
            xsdSubStore.InvoiceDetailStoreDataTable dataTable = new xsdSubStore.InvoiceDetailStoreDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.Parameters.AddWithValue("@Key", Key);

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

        #region BalanceSaleProductSelect
        public xsdSubStore.BalanceSaleProductDataTable BalanceSaleProductSelect()
        {
            base.sqlcmd = "BalanceSaleProductSelect";
            xsdSubStore.BalanceSaleProductDataTable dataTable = new xsdSubStore.BalanceSaleProductDataTable();

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

        public string InsertHeader(xsdSubStore.InvoiceStoreRow dataRow)
        {
            sqlcmd = "StoreInvoiceInsert";

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@InvNo", dataRow.InvNo);
            command.Parameters.AddWithValue("@InvType", dataRow.InvType);
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

        public void InsertDetail(string InvId, xsdSubStore.StoreProductInsertRow dr)
        {
            sqlcmd = "StoreInvoiceDetailInsert";

            SqlCommand command = new SqlCommand(sqlcmd, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;

            string detailKey = null;
            try
            {
                command.Parameters.AddWithValue("@StoInvId", InvId);
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

        #region StoreProductSummaryInsert
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
        #endregion

        #endregion
    }
}
