using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSInfo;

namespace BSSDataAccess.FourStepsDataControls
{
  public  class WholesaleDataCtrl:GlobalDataAccess
    {
        #region Variables
        
        #endregion

        #region Constructor
      public WholesaleDataCtrl()
        {
        } 
        #endregion

        #region Select Methods

        public xsdRegister.WholesaleDataTable SelectAll()
        {
            base.sqlcmd = "WholesaleSelect";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

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
        public xsdRegister.WholesaleDataTable SelectByUpperId(string Key)
        {
            base.sqlcmd = "WholesaleSelectByUpperId";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@UpperId", Key);
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

        public xsdRegister.WholesaleRow SelectByCodeRow(string Code)
        {
            base.sqlcmd = "WholesaleSelectByCode";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@WsaleCode",Code);
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
        public xsdRegister.WholesaleDataTable SelectByCode(string Code)
        {
            base.sqlcmd = "WholesaleSelectByCoding";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@WsaleCode", "%"+Code+"%");
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

        public xsdRegister.WholesaleRow SelectByKey(string Key)
        {
            base.sqlcmd = "WholesaleSelectByKey";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

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

        public xsdRegister.WholesaleDataTable SelectByName(string Name)
        {
            base.sqlcmd = "WholesaleSelectByName";
            xsdRegister.WholesaleDataTable dataTable = new xsdRegister.WholesaleDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@WsaleName", "%"+Name+"%");
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

        public string Insert(xsdRegister.WholesaleRow dataRow)
        {
            sqlcmd = "WholesaleInsert";

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
               command.Parameters.AddWithValue("@SmerchantId",dataRow.SmerchantId);
               // command.Parameters.AddWithValue("@WsaleId",dataRow.);
               command.Parameters.AddWithValue("@WsaleImg ", dataRow.WsaleImg);
                command.Parameters.AddWithValue("@WsaleCode",dataRow.WsaleCode);
                command.Parameters.AddWithValue("@WsaleName",dataRow.WsaleName);
                command.Parameters.AddWithValue("@WsaleRate",dataRow.WsaleRate);
                command.Parameters.AddWithValue("@NRCNo",dataRow.NRCNo);
                command.Parameters.AddWithValue("@FatherName",dataRow.FatherName);
                command.Parameters.AddWithValue("@DOB",dataRow.DOB);
                command.Parameters.AddWithValue("@NationalityId", dataRow.NationalityId);
                command.Parameters.AddWithValue("@ReligionId", dataRow.ReligionId);
                command.Parameters.AddWithValue("@RaceId", dataRow.RaceId);
                command.Parameters.AddWithValue("@NoOfChildren",dataRow.NoOfChildren);
                command.Parameters.AddWithValue("@ChildDesp", dataRow.ChildDesp);
                command.Parameters.AddWithValue("@ChildEducation",dataRow.ChildEducation);
                command.Parameters.AddWithValue("@Gender",dataRow.Gender);
                command.Parameters.AddWithValue("@Phone",dataRow.Phone);
                command.Parameters.AddWithValue("@DivId", dataRow.DivId);
                command.Parameters.AddWithValue("@CityId", dataRow.CityId);
                command.Parameters.AddWithValue("@Address",dataRow.Address);
                command.Parameters.AddWithValue("@Email",dataRow.Email);
                command.Parameters.AddWithValue("@RegDate",dataRow.RegDate);
                command.Parameters.AddWithValue("@Desp",dataRow.Desp);

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
        public void Update(xsdRegister.WholesaleRow dataRow)
        {
            sqlcmd = "WholesaleUpdate";
            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@SmerchantId", dataRow.SmerchantId);
                command.Parameters.AddWithValue("@WsaleId",dataRow.WsaleId);
                command.Parameters.AddWithValue("@WsaleImg ", dataRow.WsaleImg);
                command.Parameters.AddWithValue("@WsaleCode", dataRow.WsaleCode);
                command.Parameters.AddWithValue("@WsaleName", dataRow.WsaleName);
                command.Parameters.AddWithValue("@WsaleRate", dataRow.WsaleRate);
                command.Parameters.AddWithValue("@NRCNo", dataRow.NRCNo);
                command.Parameters.AddWithValue("@FatherName", dataRow.FatherName);
                command.Parameters.AddWithValue("@DOB", dataRow.DOB);
                command.Parameters.AddWithValue("@NationalityId", dataRow.NationalityId);
                command.Parameters.AddWithValue("@ReligionId", dataRow.ReligionId);
                command.Parameters.AddWithValue("@RaceId", dataRow.RaceId);
                command.Parameters.AddWithValue("@NoOfChildren", dataRow.NoOfChildren);
                command.Parameters.AddWithValue("@ChildDesp", dataRow.ChildDesp);
                command.Parameters.AddWithValue("@ChildEducation", dataRow.ChildEducation);
                command.Parameters.AddWithValue("@Gender", dataRow.Gender);
                command.Parameters.AddWithValue("@Phone", dataRow.Phone);
                command.Parameters.AddWithValue("@DivId", dataRow.DivId);
                command.Parameters.AddWithValue("@CityId", dataRow.CityId);
                command.Parameters.AddWithValue("@Address", dataRow.Address);
                command.Parameters.AddWithValue("@Email", dataRow.Email);
                command.Parameters.AddWithValue("@RegDate", dataRow.RegDate);
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
            sqlcmd = "WholesaleDelete";

            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@WsaleId", key);

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
