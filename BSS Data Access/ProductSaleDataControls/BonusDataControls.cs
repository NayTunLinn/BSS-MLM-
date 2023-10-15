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
    public class BonusDataControls:GlobalDataAccess
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
        public BonusDataControls()
        {
            if (connection == null) connection = this.CreateConnection();
        }
        #endregion


        #region Select Methods

        public xsdSale.BonusViewDataTable SelectAll()
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
        public xsdCodeSetup.BonusNameDataTable SelectName()
        {
            base.sqlcmd = "BonusSelectName";
            xsdCodeSetup.BonusNameDataTable dataTable = new xsdCodeSetup.BonusNameDataTable();

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
        public xsdSale.BonusViewDataTable SelectBonusTotal(string PostSql)
        {
            if (string.IsNullOrEmpty(PostSql))
            {
                PostSql = "  Where  month(dbo.Bonus.Date)='" + System.DateTime.Now.Month + "' and year(dbo.Bonus.Date)='" + System.DateTime.Now.Year+ "'";
            }
            base.sqlcmd = @"SELECT  dbo.Bonus.PersonId, dbo.Bonus.PersonCode, dbo.Bonus.PersonName, dbo.Bonus.Rank,Sum( dbo.Bonus.Bonus) AS Bonus
                       FROM         dbo.Bonus INNER JOIN
                      dbo.InvoiceDetails ON dbo.Bonus.InvDetailId = dbo.InvoiceDetails.InvDetailId INNER JOIN
                      dbo.Product ON dbo.InvoiceDetails.ProductId = dbo.Product.ProductId " + PostSql + @" Group By dbo.Bonus.PersonId, dbo.Bonus.PersonCode, dbo.Bonus.PersonName, dbo.Bonus.Rank
 Order By  dbo.Bonus.PersonCode";
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            //base.command.CommandType = CommandType.StoredProcedure;

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
        public xsdSale.BonusViewDataTable SelectBonusGeneral(string PostSql)
        {
            if (string.IsNullOrEmpty(PostSql))
            {
                PostSql = "  Where  month(dbo.Bonus.Date)='" + System.DateTime.Now.Month + "' and year(dbo.Bonus.Date)='" + System.DateTime.Now.Year + "'";
            }
            base.sqlcmd = @"SELECT  dbo.Bonus.PersonId, dbo.Bonus.PersonCode, dbo.Bonus.PersonName, dbo.Bonus.Rank,Sum( dbo.Bonus.Bonus) AS Bonus, dbo.Product.ProductName, dbo.InvoiceDetails.ProductQty, dbo.InvoiceDetails.InvId
                       FROM         dbo.Bonus INNER JOIN
                      dbo.InvoiceDetails ON dbo.Bonus.InvDetailId = dbo.InvoiceDetails.InvDetailId INNER JOIN
                   dbo.Product ON dbo.InvoiceDetails.ProductId = dbo.Product.ProductId " + PostSql + @"Group By dbo.Bonus.PersonId, dbo.Bonus.PersonCode, dbo.Bonus.PersonName, dbo.Bonus.Rank, dbo.Product.ProductName, dbo.InvoiceDetails.ProductQty, dbo.InvoiceDetails.InvId
 Order By  dbo.Bonus.PersonCode"; //, dbo.InvoiceDetails.ProductQty
            
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            //base.command.CommandType = CommandType.StoredProcedure;

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
        public xsdCommession.BonusDetailDataTable SelectByOverTarget(DateTime Date)
        {
            base.sqlcmd = "BonusDetailSelectByOverTarget";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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
        public xsdSale.BonusViewDataTable  SelectByMonth(DateTime Date)
        {
            base.sqlcmd = "BonusSelectByMonth";
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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

        public xsdCommession.BonusDetailDataTable SelectDetailByMonth(DateTime Date)
        {
            base.sqlcmd = "BonusDetailSelectByMonth";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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
        public xsdCommession.BonusDetailDataTable SelectDetailByDay(DateTime Date)
        {
            base.sqlcmd = "BonusDetailSelectByDay";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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
        public xsdCommession.BonusDetailDataTable SelectDetailByFromToDate(DateTime From,DateTime To)
        {
            base.sqlcmd = "BonusDetailSelectByFromToDate";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@From", From);
                command.Parameters.AddWithValue("@To", To);
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
        public xsdSale.BonusViewDataTable SelectByCode(string Code)
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
        public xsdSale.BonusViewDataTable SelectByName(string Name)
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
        public xsdSale.BonusViewRow BonusSelectByCode(string Code)
        {
            base.sqlcmd = "ReportInvoiceSelectById";
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@InvId", Code);

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
        
        public xsdCommession.BonusDetailRow BonusDetailSelectByDayId(DateTime Date,string Key)
        {
            base.sqlcmd = "BonusDetailSelectByDayID";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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

            if (dataTable.Rows.Count > 0)
                return dataTable[0];
            xsdCommession.BonusDetailRow br = dataTable.NewBonusDetailRow();

            return br;
        }
        public xsdCommession.BonusDetailRow BonusDetailSelectByFromToID(DateTime From,DateTime To, string Key)
        {
            base.sqlcmd = "BonusDetailSelectByFromToID";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@From", From);
                command.Parameters.AddWithValue("@To", To);
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

            if (dataTable.Rows.Count > 0)
                return dataTable[0];
            xsdCommession.BonusDetailRow br = dataTable.NewBonusDetailRow();

            return br;
        }
        public xsdCommession.BonusDetailDataTable SelectCommessionByLevel()
        {
            base.sqlcmd = "SelectCommessionByLevel";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                //command.Parameters.AddWithValue("@Date", Date);
                //command.Parameters.AddWithValue("@PersonId", Key);

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

           // if (dataTable.Rows.Count > 0)
            return dataTable;

        
        }
        public void ClearCommessionByLevel()
        {
            sqlcmd = "ClearCommessionByLevel";

            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                //command.Parameters.AddWithValue("@Key", key);

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
        public string CommessionByLevel(xsdCommession.BonusDetailRow dataRow,DateTime dt)
        {
           
            base.sqlcmd = "CommessionByLevel";
            

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
         
             //  command.Parameters.AddWithValue("@BonusDetailId",dataRow.BonusDetailId );
                 command.Parameters.AddWithValue("@PersonId",dataRow.PersonId );
                 command.Parameters.AddWithValue("@PersonCode",dataRow.PersonCode );
                 command.Parameters.AddWithValue("@PersonName",dataRow.PersonName );
                 command.Parameters.AddWithValue("@p001",dataRow.p001 );
                 command.Parameters.AddWithValue("@p002",dataRow.p002 );
                 command.Parameters.AddWithValue("@p003",dataRow.p003 );
                 command.Parameters.AddWithValue("@p004a",dataRow.p004a );
                 command.Parameters.AddWithValue("@p004b",dataRow.p004b );
                 command.Parameters.AddWithValue("@p004c", dataRow.p004c);
                 command.Parameters.AddWithValue("@p005",dataRow.p005 );
                 command.Parameters.AddWithValue("@p006",dataRow.p006 );
                 command.Parameters.AddWithValue("@p007", dataRow.p007);
                 command.Parameters.AddWithValue("@p008", dataRow.p008);
                 command.Parameters.AddWithValue("@p009", dataRow.p009);
                 command.Parameters.AddWithValue("@p100", dataRow.p100);
                 command.Parameters.AddWithValue("@p010", dataRow.p010);//p10 change
                 command.Parameters.AddWithValue("@p011", dataRow.p011);
                 command.Parameters.AddWithValue("@p012", dataRow.p012);
                 command.Parameters.AddWithValue("@p013", dataRow.p013);
                 command.Parameters.AddWithValue("@p014", dataRow.p014);
                 command.Parameters.AddWithValue("@p101", dataRow.p101);

                 command.Parameters.AddWithValue("@Commession",dataRow.Commession );
                 command.Parameters.AddWithValue("@TotalAmount",dataRow.TotalAmount );
                 command.Parameters.AddWithValue("@TotalCommession",dataRow.TotalCommession );
                 command.Parameters.AddWithValue("@Rank",dataRow.Rank );
                 command.Parameters.AddWithValue("@InsertDate",dt );


                if (connection.State != ConnectionState.Open) connection.Open();
                int count = (int)command.ExecuteScalar();
                key = count.ToString();
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

        public xsdCommession.BonusDetailRow BonusDetailSelectByMonthId(DateTime Date, string Key)
        {
            base.sqlcmd = "BonusDetailSelectByMonthID";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@Date", Date);
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

            if (dataTable.Rows.Count > 0)
                return dataTable[0];

            xsdCommession.BonusDetailRow br = dataTable.NewBonusDetailRow();

            return br;
        }
        public xsdSale.BonusViewDataTable SelectByInvNo(string InvNo)
        {
            base.sqlcmd = "BonusSelectByInvNo";
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

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

        //For Total bonus show by one merchant
        #region TotalBonusSelect
        public xsdSale.BonusViewDataTable BonusTotalSelectByDate(DateTime startdate, DateTime enddate)
        {
            base.sqlcmd = "BonusSelectByDate";
            xsdSale.BonusViewDataTable dataTable = new xsdSale.BonusViewDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@startdate", startdate);
                command.Parameters.AddWithValue("@enddate", enddate);

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

        public xsdSale.BonusViewDataTable BonusTotalSelectByName(string Name)
        {
            base.sqlcmd = "BonusTotalSelectByName";
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

        public xsdSale.BonusViewDataTable BonusTotalSelectByCode(string Code)
        {
            base.sqlcmd = "BonusTotalSelectByCode";
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
        #endregion

        public xsdCommession.BonusDetailDataTable SelectBonusDetail()
        {
            base.sqlcmd = "BonusDetailSelect";
            xsdCommession.BonusDetailDataTable dataTable = new xsdCommession.BonusDetailDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

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
        #endregion
    }
}
