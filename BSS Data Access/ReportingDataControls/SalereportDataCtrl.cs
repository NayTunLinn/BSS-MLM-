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
   public class SaleReportDataCtrl:GlobalDataAccess
    {
        #region Variables
        
        #endregion

        #region Constructor
       public SaleReportDataCtrl()
        {
        } 
        #endregion

        #region HeaderDetail
       public HeaderDetailReport.InvoiceHeaderDetailDataTable HeaderDetailSelect()
       {
           base.sqlcmd = "ReportHeaderDetailSelect";
           HeaderDetailReport.InvoiceHeaderDetailDataTable dataTable = new HeaderDetailReport.InvoiceHeaderDetailDataTable();

           base.connection = this.CreateConnection();
           base.command = new SqlCommand(sqlcmd, connection);

           base.command.CommandType = CommandType.StoredProcedure;

           try
           {
               //command.Parameters.AddWithValue("@InvId", Key);

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

        #region Select By Key Methods

        public xsdSaleReport.Invoice_ReportRow InvoiceSelectById(string Key)
        {
            base.sqlcmd = "ReportInvoiceSelectById";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

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

            if (dataTable.Rows.Count > 0)
                return dataTable[0];

            return null;
        }
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByPersonId(string Key)
        {
            base.sqlcmd = "ReportInvoiceSelectByPersonId";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@PersonId", Key);

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

        public xsdSaleReport.Invoice_ReportRow ReturnInvoiceSelectById(string Key)
        {
            base.sqlcmd = "SaleReturnReportInvoiceSelectById";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

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

            if (dataTable.Rows.Count > 0)
                return dataTable[0];

            return null;
        }

        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelect()
        {
            base.sqlcmd = "ReportInvoiceSelect";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

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

        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByInvNo(string InvNo)
        {
            base.sqlcmd = "ReportInvoiceSelectByInvNo";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                 command.Parameters.AddWithValue("@InvNo", "%"+InvNo+"%");

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
        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByGeneral(string PostSql)
        {
            base.sqlcmd =@"SELECT     dbo.Invoice.*
FROM         dbo.Invoice "+PostSql+" Order By dbo.Invoice.InvDate ASC ,InvNo ASC ";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

           // base.command.CommandType = CommandType.StoredProcedure;

            try
            {
               // command.Parameters.AddWithValue("@InvNo", "%" + InvNo + "%");

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
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByGeneral(string PostSql)
        {
            base.sqlcmd = @"SELECT     dbo.SaleReturnInvoice.*
FROM         dbo.SaleReturnInvoice " + PostSql + " Order By dbo.SaleReturnInvoice.InvDate DESC ";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

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
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByGeneral(string PostSql)
        {
            base.sqlcmd = @"SELECT     dbo.InvoiceDetails.*, dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.Price
FROM         dbo.Invoice INNER JOIN
                      dbo.InvoiceDetails ON dbo.Invoice.InvId = dbo.InvoiceDetails.InvId INNER JOIN
                      dbo.Product ON dbo.InvoiceDetails.ProductId = dbo.Product.ProductId " + PostSql + " ORDER BY dbo.Product.ProductCode ";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            // base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                // command.Parameters.AddWithValue("@InvNo", "%" + InvNo + "%");

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

        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectTotal(string PostSql)
        {
            base.sqlcmd = @"SELECT dbo.InvoiceDetails.ProductId,sum(dbo.InvoiceDetails.ProductQty) AS ProductQty ,
        dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.Price  From     dbo.Invoice INNER JOIN
                      dbo.InvoiceDetails ON dbo.Invoice.InvId = dbo.InvoiceDetails.InvId INNER JOIN
                      dbo.Product ON dbo.InvoiceDetails.ProductId = dbo.Product.ProductId " + PostSql 
                      + " Group By dbo.InvoiceDetails.ProductId, dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.Price ORDER BY dbo.Product.ProductCode ";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            // base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                // command.Parameters.AddWithValue("@InvNo", "%" + InvNo + "%");

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

        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectById(string Key)
        {
           
            base.sqlcmd = "ReportInvoiceDetailsSelectById";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

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
        public xsdSaleReport.InvoiceDetails_ReportDataTable ReturnInvoiceDetailsSelectById(string Key)
        {

            base.sqlcmd = "SaleReturnReportInvoiceDetailsSelectById";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

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

        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectAll()
        {
            base.sqlcmd = "ReportInvoiceDetailsSelectAll";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

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
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByDate(DateTime FromDate, DateTime ToDate)
        {
            base.sqlcmd = "InvoiceDetailsSelectByDate";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@FromDate", FromDate);
                base.command.Parameters.AddWithValue("@ToDate", ToDate);
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
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByDay(DateTime Day)
        {
            base.sqlcmd = "InvoiceDetailsSelectByDay";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@Date", Day);
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
        public xsdSaleReport.InvoiceDetails_ReportDataTable InvoiceDetailsSelectByMonth(DateTime Month)
        {
            base.sqlcmd = "InvoiceDetailsSelectByMonth";
            xsdSaleReport.InvoiceDetails_ReportDataTable dataTable = new xsdSaleReport.InvoiceDetails_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@Date", Month);
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

        public xsdSaleReport.Invoice_ReportDataTable InvoiceSelectByThisMonth()
        {
            base.sqlcmd = "InvoiceSelectByMonth";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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
        public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByThisMonth()
        {
            base.sqlcmd = "ReturnInvoiceSelectByMonth";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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
             public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelectByDay()
        {
            base.sqlcmd = "ReturnInvoiceSelectByDay";
            xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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
             public xsdSaleReport.Invoice_ReportDataTable ReturnInvoiceSelect()
             {
                 base.sqlcmd = "ReturnInvoiceSelect";
                 xsdSaleReport.Invoice_ReportDataTable dataTable = new xsdSaleReport.Invoice_ReportDataTable();

                 base.connection = this.CreateConnection();
                 base.command = new SqlCommand(sqlcmd, connection);

                 base.command.CommandType = CommandType.StoredProcedure;

                 try
                 {
                     //base.command.Parameters.AddWithValue("@Date", DateTime.Now);
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

      
    }
}
