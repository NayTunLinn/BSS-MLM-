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
   public class SMerchantDataCtrl:GlobalDataAccess
    {
         #region Variables
        
        #endregion

        #region Constructor
       public SMerchantDataCtrl()
        {
        } 
        #endregion

        #region Select Methods

        public xsdRegister.SmallMerchantDataTable SelectAll()
        {
            base.sqlcmd = "SmallMerchantSelect";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

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
        public xsdRegister.SmallMerchantRow SelectByCodeRow(string Code)
        {
            base.sqlcmd = "SmallMerchantSelectByCode";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@SmerchantCode",  Code );
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

        public xsdRegister.SmallMerchantDataTable SelectByCode(string Code)
        {
            base.sqlcmd = "SmallMerchantSelectByCoding";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@SmerchantCode","%"+Code+"%");
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
        public xsdRegister.SmallMerchantDataTable SelectByUpperId(string Key)
        {
            base.sqlcmd = "SmallMerchantSelectByUpperId";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

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
        public xsdRegister.SmallMerchantDataTable SelectByName(string Name)
        {
            base.sqlcmd = "SmallMerchantSelectByName";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

            base.connection = this.CreateConnection();
            base.command = new SqlCommand(sqlcmd, connection);

            base.command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@SmerchantName", "%"+Name+"%");
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
        public xsdRegister.SmallMerchantRow SelectByKey(string Key)
        {
            base.sqlcmd = "SmallMerchantSelectByKey";
            xsdRegister.SmallMerchantDataTable dataTable = new xsdRegister.SmallMerchantDataTable();

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

        public string Insert(xsdRegister.SmallMerchantRow dataRow)
        {
            sqlcmd = "SmallMerchantInsert";

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
                command.Parameters.AddWithValue("@MerchantId",dataRow.MerchantId);
                //command.Parameters.AddWithValue("@SmerchantId",dataRow.smer);
                command.Parameters.AddWithValue("@SmerchantImg", dataRow.SmerchantImg);
                command.Parameters.AddWithValue("@SmerchantCode",dataRow.SmerchantCode);
                command.Parameters.AddWithValue("@SmerchantName",dataRow.SmerchantName);
                command.Parameters.AddWithValue("@SmerchantRate",dataRow.SmerchantRate);
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
        public void Update(xsdRegister.SmallMerchantRow dataRow)
        {
            sqlcmd = "SmallMerchantUpdate";
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
                command.Parameters.AddWithValue("@SmerchantId",dataRow.SmerchantId);
                command.Parameters.AddWithValue("@SmerchantImg", dataRow.SmerchantImg);
                command.Parameters.AddWithValue("@SmerchantCode", dataRow.SmerchantCode);
                command.Parameters.AddWithValue("@SmerchantName", dataRow.SmerchantName);
                command.Parameters.AddWithValue("@SmerchantRate", dataRow.SmerchantRate);
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
            sqlcmd = "SmallMerchantDelete";

            if (connection == null) connection = this.CreateConnection();

            SqlCommand command = null;
            if (transaction == null)
                command = new SqlCommand(sqlcmd, connection);
            else
                command = new SqlCommand(sqlcmd, connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.AddWithValue("@SmerchantId", key);

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
