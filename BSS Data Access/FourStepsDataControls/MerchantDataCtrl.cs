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
    public class MerchantDataCtrl:GlobalDataAccess
    {
          #region Variables
        
        #endregion

        #region Constructor
        public MerchantDataCtrl()
        {
        } 
        #endregion

        #region Select Methods

        public xsdRegister.MerchantDataTable SelectAll()
        {
            base.sqlcmd = "MerchantSelect";
            xsdRegister.MerchantDataTable dataTable = new xsdRegister.MerchantDataTable();

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
        public xsdRegister.MerchantDataTable SelectByName(string Name)
        {
            base.sqlcmd = "MerchantSelectByName";
            xsdRegister.MerchantDataTable dataTable = new xsdRegister.MerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@MerchantName","%"+ Name+"%");
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
        public xsdRegister.MerchantRow SelectByCodeRow(string Code)
        {
            base.sqlcmd = "MerchantSelectByCode";
            xsdRegister.MerchantDataTable dataTable = new xsdRegister.MerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
               command.Parameters.AddWithValue("@MerchantCode",Code);
                //command.Parameters.AddWithValue("@MerchantCode",  Code );
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
        public xsdRegister.MerchantDataTable SelectByCode(string Code)
        {
            base.sqlcmd = "MerchantSelectByCode";
            xsdRegister.MerchantDataTable dataTable = new xsdRegister.MerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@MerchantCode", "%" + Code + "%");
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
        public xsdRegister.MerchantRow SelectByKey(string Key)
        {
            base.sqlcmd = "MerchantSelectByKey";
            xsdRegister.MerchantDataTable dataTable = new xsdRegister.MerchantDataTable();

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
        #endregion

        #region Insert Methods

        public string Insert(xsdRegister.MerchantRow dataRow)
        {
            sqlcmd = "MerchantInsert";

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
         
                command.Parameters.AddWithValue("@CompanyId",dataRow.CompanyId);
             command.Parameters.AddWithValue("@MerchantImg", dataRow.MerchantImg);
             command.Parameters.AddWithValue("@MerchantCode",dataRow.MerchantCode);
             command.Parameters.AddWithValue("@MerchantName",dataRow.MerchantName);
             command.Parameters.AddWithValue("@MerchantRate",dataRow.MerchantRate);
             command.Parameters.AddWithValue("@NRCNo",dataRow.NRCNo);
             command.Parameters.AddWithValue("@FatherName",dataRow.FatherName);
             command.Parameters.AddWithValue("@DOB",dataRow.DOB);
             command.Parameters.AddWithValue("@NationalityId",dataRow.NationalityId);
             command.Parameters.AddWithValue("@ReligionId",dataRow.ReligionId);
             command.Parameters.AddWithValue("@RaceId",dataRow.RaceId);
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
        public void Update(xsdRegister.MerchantRow dataRow)
        {
            sqlcmd = "MerchantUpdate";
            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@MerchantId", dataRow.MerchantId);
                command.Parameters.AddWithValue("@CompanyId", dataRow.CompanyId); 
                command.Parameters.AddWithValue("@MerchantImg", dataRow.MerchantImg);
                command.Parameters.AddWithValue("@MerchantCode", dataRow.MerchantCode);
                command.Parameters.AddWithValue("@MerchantName", dataRow.MerchantName);
                command.Parameters.AddWithValue("@MerchantRate", dataRow.MerchantRate);
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
            sqlcmd = "MerchantDelete";

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
