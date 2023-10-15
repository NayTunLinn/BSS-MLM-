using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.ProductSaleDataControls
{
   public class GeneralDataCtrl:GlobalDataAccess
    {
           #region Variables
        
        #endregion

        #region Constructor
       public GeneralDataCtrl()
        {
        } 
        #endregion

       #region Select Methods

       public xsdSale.AllCustomerCodeDataTable SelectAllCustomerCode()
       {
           base.sqlcmd = "SelectAllCustomerCode";
           xsdSale.AllCustomerCodeDataTable dataTable = new xsdSale.AllCustomerCodeDataTable();

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
       public xsdSale.InvoiceDataTable SelectAllInvoice()
       {
           base.sqlcmd = "InvoiceSelect";
           xsdSale.InvoiceDataTable dataTable = new xsdSale.InvoiceDataTable();

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
       public xsdSale.BonusViewDataTable SelectAllBonus()
       {
           base.sqlcmd = "BonusSelect";
           xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

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
       public xsdSale.BonusViewDataTable BonusSelectByName(string Name)
       {
           base.sqlcmd = "BonusSelectByName";
           xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

           base.connection = this.CreateConnection();
           base.command = new SqlCommand(sqlcmd, connection);

           base.command.CommandType = CommandType.StoredProcedure;

           try
           {
               command.Parameters.AddWithValue("@PersonName", Name);
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
       public xsdSale.BonusViewDataTable BonusSelectByCode(string Code)
       {
           base.sqlcmd = "BonusSelectByCode";
           xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

           base.connection = this.CreateConnection();
           base.command = new SqlCommand(sqlcmd, connection);

           base.command.CommandType = CommandType.StoredProcedure;

           try
           {
               command.Parameters.AddWithValue("@PersonCode", Code);
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
       public xsdCodeSetup.CustomerRow CustomerSelectByCode(string Code)
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
       public string GenerateCode(string Type)
       {
           sqlcmd = "AutoCodeGenerator";


           base.connection = this.CreateConnection();
           connection.Open();
           base.command = new SqlCommand(sqlcmd, connection);
           base.command.CommandType = CommandType.StoredProcedure;

           command.Parameters.AddWithValue("@Type", Type);

           string key = null;
           try
           {
               key = (string)command.ExecuteScalar();
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
           return key;
       }
       public string FakeGenerateCode(string Type)
       {
           sqlcmd = "FakeAutoCodeGenerator";


           base.connection = this.CreateConnection();
           connection.Open();
           base.command = new SqlCommand(sqlcmd, connection);
           base.command.CommandType = CommandType.StoredProcedure;

           command.Parameters.AddWithValue("@Type", Type);

           string key = null;
           try
           {
               key = (string)command.ExecuteScalar();
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
           return key;
       }
       public string AutoGenerateCode(string Type)
       {
           sqlcmd = "AutoCodeGenerator";


           base.connection = this.CreateConnection();
           connection.Open();
           base.command = new SqlCommand(sqlcmd, connection);
           base.command.CommandType = CommandType.StoredProcedure;

           command.Parameters.AddWithValue("@Type", Type);

           string key = null;
           try
           {
               key = (string)command.ExecuteScalar();
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
           return key;
       }
       #endregion

        //#region Header
        //public string BonusInsert(string InvId,string productId,string UpperdistId,string Rank,int Qty)
        //{
        //    sqlcmd = "CaculateBonus";

        //    SqlCommand command = null;
        //    if (transaction == null)
        //        command = new SqlCommand(sqlcmd, connection);
        //    else
        //        command = new SqlCommand(sqlcmd, connection, transaction);

        //    command.CommandType = CommandType.StoredProcedure;

        //    command.Parameters.AddWithValue("@InvId", InvId);
        //    command.Parameters.AddWithValue("@UpperDistributorId", UpperdistId);
        //    command.Parameters.AddWithValue("@ProductId", productId);
        //    command.Parameters.AddWithValue("@Rank", Rank);
        //    command.Parameters.AddWithValue("@Qty", Qty);
           
        //    string key = null;
        //    try
        //    {
        //        key = (string)command.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return key;
        //}
        //#endregion
    }
}
