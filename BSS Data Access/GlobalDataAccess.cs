using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BSSCommon;

namespace BSSDataAccess
{
    public class GlobalDataAccess
    {
        #region Variables
        protected internal string m_connectionString = null;
        protected internal string m_connectionStringName = null;
        protected Exception m_exception = null;
        protected SqlConnection connection = null;
        protected SqlCommand command = null;
        protected SqlTransaction transaction = null;
        protected string sqlcmd;
        #endregion

        #region Constructor
        public GlobalDataAccess()
            : this("MainDBString")
        {
        }

        protected GlobalDataAccess(string connectionStringName)
        {
            this.m_connectionStringName = connectionStringName;

            try
            {
                if (ConfigurationManager.ConnectionStrings != null)
                {
                    ConfigurationManager.RefreshSection("connectionStrings");
                    ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[this.m_connectionStringName];
                    if (setting != null) this.m_connectionString = setting.ConnectionString;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Properties
        public virtual string ConnectionString
        {
            get { return this.m_connectionString; }
            protected set { this.m_connectionString = value; }
        }

        public virtual Exception Error
        {
            get { return this.m_exception; }
        }
        #endregion

        #region Methods
        private string GetConnectionString(string name)
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(Environment.CurrentDirectory);

            System.IO.FileInfo[] files = dirInfo.GetFiles("*.config");
            if ((files == null) || (files.Length < 1)) goto Label_0;

            System.IO.FileInfo fileInfo = files[0];
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(fileInfo.FullName);

            System.Xml.XmlNode connectionStrings = null;
            for (int i = 0; i < xDoc.ChildNodes.Count; i++)
            {
                if (xDoc.ChildNodes[i].Name == "connectionStrings")
                {
                    connectionStrings = xDoc.ChildNodes[i];
                    break;
                }
            }

            if (connectionStrings != null)
            {
                string connectionString = string.Empty;
                for (int j = 0; j < connectionStrings.ChildNodes.Count; j++)
                {
                    if (connectionStrings.ChildNodes[j].NodeType == System.Xml.XmlNodeType.Element)
                    {
                        System.Xml.XmlElement xElement = (System.Xml.XmlElement)connectionStrings.ChildNodes[j];
                        if (xElement.GetAttribute("name") == name)
                        {
                            connectionString = xElement.GetAttribute("connectionString");
                            break;
                        }
                    }
                }

                return connectionString;
            }

        Label_0:
            throw new Exception("Does not load configuration.");
        }

        public static string GetConnectionString()
        {
            GlobalDataAccess ctrl = new GlobalDataAccess();
            return ctrl.ConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        protected SqlConnection CreateConnection(int timeOut)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(this.ConnectionString);
            connectionStringBuilder.ConnectTimeout = timeOut;

            return new SqlConnection(connectionStringBuilder.ConnectionString);
        }

        protected SqlCommand CreateCommand(string sql, CommandType commandType)
        {
            SqlCommand command = new SqlCommand(sql, this.CreateConnection());
            command.CommandTimeout = Global.SQL_TIMEOUT;
            command.CommandType = commandType;
            return command;
        }

        protected object CheckNull(object obj)
        {
            if (obj == null) return DBNull.Value;

            if (obj is string && obj.ToString() == string.Empty)
            {
                obj = DBNull.Value;
                return obj;
            }
            if (obj is DateTime && DateTime.Parse(obj.ToString()) == DateTime.MinValue)
            {
                obj = DBNull.Value;
                return obj;
            }
            if (obj is int && int.Parse(obj.ToString()) == int.MinValue)
            {
                obj = DBNull.Value;
                return obj;
            }
            if (obj is Single && Single.Parse(obj.ToString()) == Single.MinValue)
            {
                obj = DBNull.Value;
                return obj;
            }
            if (obj is Decimal && Decimal.Parse(obj.ToString()) == Decimal.MinValue)
            {
                obj = DBNull.Value;
                return obj;
            }
            if (obj is Double && Double.Parse(obj.ToString()) == Double.MinValue)
            {
                obj = DBNull.Value;
                return obj;
            }
            return obj;
        }

        protected object CheckNull<T>(T value)
        {
            object objValue = (object)value;
            if (objValue == null) return DBNull.Value;

            Type objType = typeof(T);
            Type underlyingType = System.Nullable.GetUnderlyingType(typeof(T));
            if (underlyingType != null)
            {
                objType = underlyingType;
            }

            if (objType == typeof(string))
            {
                string val = (string)Convert.ChangeType(objValue, objType);
                if (string.IsNullOrEmpty(val)) return DBNull.Value;
            }
            else if (objType == typeof(int))
            {
                int val = (int)Convert.ChangeType(objValue, objType);
                if (val == int.MinValue) return DBNull.Value;
            }
            else if (objType == typeof(long))
            {
                long val = (long)Convert.ChangeType(objValue, objType);
                if (val == long.MinValue) return DBNull.Value;
            }
            else if (objType == typeof(float))
            {
                float val = (float)Convert.ChangeType(objValue, objType);
                if (val == float.MinValue) return DBNull.Value;
            }
            else if (objType == typeof(double))
            {
                double val = (double)Convert.ChangeType(objValue, objType);
                if (val == double.MinValue) return DBNull.Value;
            }
            else if (objType == typeof(decimal))
            {
                decimal val = (decimal)Convert.ChangeType(objValue, objType);
                if (val == decimal.MinValue) return DBNull.Value;
            }
            else if (objType == typeof(DateTime))
            {
                DateTime val = (DateTime)Convert.ChangeType(objValue, objType);
                if (val == DateTime.MinValue) return DBNull.Value;
            }

            return objValue;
        }

        protected object GetSqlDateValue(DateTime? value)
        {
            if (value == null) return DBNull.Value;
            if (value == DateTime.MinValue) return DBNull.Value;
            if (!value.HasValue) return DBNull.Value;
            if (value.Value.Year < 1753) return DBNull.Value;

            return new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, value.Value.Hour, value.Value.Minute, value.Value.Second, value.Value.Kind);
        }

        protected virtual void ClearError()
        {
            this.m_exception = null;
        }

        #endregion
    }

    #region SqlBulkCopyExtension
    static class SqlBulkCopyExtension
    {
        private const string rowsCopiedFieldName = "_rowsCopied";
        private static System.Reflection.FieldInfo rowsCopiedField = null;

        public static int RowsCopiedCount(this SqlBulkCopy bulkCopy)
        {
            if (rowsCopiedField == null)
                rowsCopiedField = typeof(SqlBulkCopy).GetField(rowsCopiedFieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance);

            return (int)rowsCopiedField.GetValue(bulkCopy);
        }
    }
    #endregion
}
