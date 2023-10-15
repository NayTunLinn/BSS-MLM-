using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;  

namespace BSSCommon
{
    public static class Global
    {
        #region Variables
        public static string USER_KEY = "FAKE";
        public static string USER_ROLE = "FAKE";

        public const int CONNECT_TIMEOUT = 120;
        public const int SQL_TIMEOUT = 300;


        #endregion

        #region Methods
        public static string GetNewKey()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        public static string GetExceptionMessage(System.Exception ex)
        {
            if (ex == null) return string.Empty;

            string format = "\r\n  Message={0}";
            format += "\r\n  Source={1}";
            format += "\r\n  StackTrace:\r\n{2}";

            string output = "";
            if (ex.InnerException != null)
            {
                format += "\r\n  InnerException: \r\n";
                format += "\r\n    Message={3}";
                format += "\r\n    Source={4}";
                format += "\r\n    StackTrace:\r\n{5}";

                output = string.Format(format, ex.Message, ex.Source, ex.StackTrace, ex.InnerException.Message, ex.InnerException.Source, ex.InnerException.StackTrace);
            }
            else
            {
                format += "\r\n  InnerException: \r\n";
                output = string.Format(format, ex.Message, ex.Source, ex.StackTrace);
            }

            return output;
        }

        public static T ParseEnum<T>(string value, T def)
        {
            if (string.IsNullOrEmpty(value)) return def;

            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return def;
        }

        public static T GetDataIntEnum<T>(System.Data.DataRow dataRow, string colunmName, T def)
        {
            if (dataRow == null) return def;
            if (string.IsNullOrEmpty(colunmName)) return def;
            if (!dataRow.Table.Columns.Contains(colunmName)) return def;
            if (dataRow.RowState == System.Data.DataRowState.Deleted) return def;
            if (dataRow.IsNull(colunmName)) return def;

            try
            {
                int value = (int)Convert.ChangeType(dataRow[colunmName], typeof(int));
                return (T)(object)value;
            }
            catch { }

            return def;
        }



        public static T GetDataFromRow<T>(System.Data.DataRow dataRow, string colunmName, T def)
        {
            if (dataRow == null) return def;
            if (string.IsNullOrEmpty(colunmName)) return def;
            if (!dataRow.Table.Columns.Contains(colunmName)) return def;
            if (dataRow.RowState == System.Data.DataRowState.Deleted) return def;
            if (dataRow.IsNull(colunmName)) return def;

            Type underlyingType = System.Nullable.GetUnderlyingType(typeof(T));
            if (underlyingType != null)
            {
                try
                {
                    return (T)Convert.ChangeType(dataRow[colunmName], underlyingType);
                }
                catch
                { }

                return def;
            }

            try
            {
                return (T)dataRow[colunmName];
            }
            catch { }

            return (T)Convert.ChangeType(dataRow[colunmName], typeof(T));
        }

        public static bool HasDatabaseConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) return false;

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            bool result = false;
            try
            {
                connection.Open();
                result = (connection.State == System.Data.ConnectionState.Open);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return result;
        }

        public static string TrimNoneASCII(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];

                if ((ch >= '0') && (ch <= '9'))
                    builder.Append(ch);
                else if ((ch >= 'a') && (ch <= 'z'))
                    builder.Append(ch);
                else if ((ch >= 'A') && (ch <= 'Z'))
                    builder.Append(ch);
            }

            return builder.ToString();
        }

        public static void UpdateConnectionString(string connectionName, string server, string database, string userID, string password, int connectionTimeout)
        {

            // Get the application configuration file.

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Create the connection string name. 
            //string csName = "MainDBString";

            // Create a connection string element and
            // save it to the configuration file.

            // Get the connection strings section.
            ConnectionStringsSection csSection = config.ConnectionStrings;
            ConnectionStringSettings csSettings = csSection.ConnectionStrings[connectionName] as ConnectionStringSettings;
            if (csSettings != null)
            {
                csSection.ConnectionStrings.Remove(csSettings);
            }

            // Create a connection string element.
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = server;
            connectionStringBuilder.InitialCatalog = database;
            connectionStringBuilder.UserID = userID;
            connectionStringBuilder.Password = password;
            if (connectionTimeout != 0)
                connectionStringBuilder.ConnectTimeout = connectionTimeout;

            ConnectionStringSettings connectionStringSettings = new ConnectionStringSettings(connectionName, connectionStringBuilder.ConnectionString);

            // Add the new element.
            csSection.ConnectionStrings.Add(connectionStringSettings);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified, true);

            // Force Reload
            ConfigurationManager.RefreshSection("connectionString");
        }
        #endregion

        #region Properties
        public static string ApplicationPath
        {
            get
            {
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(appPath);
                return fileInfo.DirectoryName;
            }
        }
        #endregion
    }

    public static class Extension
    {
        #region Creating_Form

        #region ToDialog
        public static Form ToDialog(this System.Windows.Forms.Control ctrl, string name, string text, System.Windows.Forms.MessageBoxButtons buttons)
        {
            return ToDialog(ctrl, name, text, buttons, FormBorderStyle.FixedDialog);
        }

        public static Form ToDialog(this System.Windows.Forms.Control ctrl, string name, string text
            , System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.FormBorderStyle formBorderStyle)
        {
            return ToDialog(ctrl, name, text, buttons, FormBorderStyle.FixedDialog, null, null);
        }

        public static Form ToDialog(this System.Windows.Forms.Control ctrl, string name, string text
            , System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.FormBorderStyle formBorderStyle,
            EventHandler positiveButtonClick, EventHandler middleButtonClick)
        {
        #endregion

            System.Drawing.Size ctrlSize = new System.Drawing.Size(ctrl.Width, ctrl.Height);
            AnchorStyles anchor = ctrl.Anchor;
            ctrl.Size = new System.Drawing.Size(ctrl.Width, ctrl.Height + 80);
            Form frm = new Form()
            {
                Name = name,
                Text = text,
              //  Size = new System.Drawing.Size(ctrl.Width, ctrl.Height +80),
              Size=ctrl.Size,
                BackColor = ctrl.BackColor,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ShowIcon = false,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
                
            };
            frm.SuspendLayout();   
            ctrl.Location = new Point(0, 0);
            ctrl.Visible = true;
           

            Button cmd1 = new Button()
            {
                Name = "cmd1",
                Size = new System.Drawing.Size(75, 25),
                BackColor = Color.White,
                Location = new System.Drawing.Point(ctrlSize.Width - 280, ctrlSize.Height),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                
            };

            Button cmd2 = new Button()
            {
                Name = "cmd2",
                Size = new System.Drawing.Size(75, 25),
                BackColor = Color.Wheat,
                Location = new System.Drawing.Point(ctrlSize.Width - 190, ctrlSize.Height),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                
                
            };

            Button cmd3 = new Button()
            {
                Name = "cmd3",
                Size = new System.Drawing.Size(75, 25),
                BackColor = Color.LightPink,
                Location = new System.Drawing.Point(ctrlSize.Width - 100, ctrlSize.Height),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                
               
            };
          
          EventHandler clickEvent = new EventHandler((object sender, EventArgs e)=> { frm.Close(); });

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        cmd1.Text = "&Abort";
                        cmd1.DialogResult = DialogResult.Abort;

                        cmd2.Text = "&Retry";
                        cmd2.DialogResult = DialogResult.Retry;
                        cmd2.Click += clickEvent;

                        cmd3.Text = "&Ignore";
                        cmd3.DialogResult = DialogResult.Ignore;

                        ctrl.Controls.Add(cmd1);
                        ctrl.Controls.Add(cmd2);
                        ctrl.Controls.Add(cmd3);

                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                        else
                           frm.CancelButton = cmd3;
                    }
                    break;

                case MessageBoxButtons.OKCancel:
                    {
                        cmd2.Text = "&Ok";
                        cmd2.DialogResult = DialogResult.OK;

                        cmd3.Text = "&Cancel";
                        cmd3.DialogResult = DialogResult.Cancel;

                       ctrl.Controls.Add(cmd2);
                       ctrl.Controls.Add(cmd3);

                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                        else
                        frm.CancelButton = cmd3;
                    }
                    break;

                case MessageBoxButtons.RetryCancel:
                    {
                        cmd2.Text = "&Retry";
                        cmd2.DialogResult = DialogResult.Retry;

                        cmd3.Text = "&Cancel";
                        cmd3.DialogResult = DialogResult.Cancel;

                        ctrl.Controls.Add(cmd2);
                        ctrl.Controls.Add(cmd3);

                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                        else
                        frm.CancelButton = cmd3;
                    }
                    break;

                case MessageBoxButtons.YesNo:
                    {
                        cmd2.Text = "&Yes";
                        cmd2.DialogResult = DialogResult.Yes;

                        cmd3.Text = "&No";
                        cmd3.DialogResult = DialogResult.No;

                        ctrl.Controls.Add(cmd2);
                        ctrl.Controls.Add(cmd3);

                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                        else
                        frm.CancelButton = cmd3;
                    }
                    break;

                case MessageBoxButtons.YesNoCancel:
                    {
                        cmd1.Text = "&Yes";
                        cmd1.DialogResult = DialogResult.Yes;

                        cmd2.Text = "&No";
                        cmd2.DialogResult = DialogResult.No;

                        if (middleButtonClick != null)
                            cmd2.Click += middleButtonClick;
                        else
                            cmd2.Click += clickEvent;

                        cmd3.Text = "&Cancel";
                        cmd3.DialogResult = DialogResult.Cancel;

                        ctrl.Controls.Add(cmd1);
                        ctrl.Controls.Add(cmd2);
                        ctrl.Controls.Add(cmd3);

                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                        else                    
                        frm.CancelButton = cmd3;
                    }
                    break;

                default:
                    {
                        cmd3.Text = "&Ok";
                        cmd3.DialogResult = DialogResult.OK;

                        ctrl.Controls.Add(cmd3);
                        if (positiveButtonClick != null)
                            cmd1.Click += positiveButtonClick;
                    }
                    break;
            }
 
            frm.ResumeLayout();
            frm.Controls.Add(ctrl);
            frm.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
              //  e.Cancel = true;
                ctrl.Anchor = anchor;
                ctrl.Size = ctrlSize;
            });

            return frm;
        }
        #endregion

        #region DataGridView
        public static T GetCellValue<T>(this DataGridView gridView, int rowIndex, int colunmIndex)
        {
            if ((rowIndex < 0) || (rowIndex >= gridView.RowCount)) return default(T);
            if ((colunmIndex < 0) || (colunmIndex >= gridView.ColumnCount)) return default(T);

            try
            {
                return (T)Convert.ChangeType(gridView.Rows[rowIndex].Cells[colunmIndex].Value, typeof(T));
            }
            catch
            {
            }

            return default(T);
        }

        public static T GetCellValue<T>(this DataGridView gridView, int rowIndex, string colunmName)
        {
            if ((rowIndex < 0) || (rowIndex >= gridView.RowCount)) return default(T);
            if (string.IsNullOrEmpty(colunmName)) return default(T);

            try
            {
                return (T)Convert.ChangeType(gridView.Rows[rowIndex].Cells[colunmName].Value, typeof(T));
            }
            catch
            { }

            return default(T);
        }

        public static DataGridViewRow GetCurrentRow(this DataGridView gridView)
        {
            if (gridView.CurrentCell == null) return null;
            return gridView.Rows[gridView.CurrentCell.RowIndex];
        }

        public static T GetCurrentRowCellValue<T>(this DataGridView gridView, int colunmIndex)
        {
            if ((colunmIndex < 0) || (colunmIndex >= gridView.ColumnCount)) return default(T);
            if (gridView.CurrentCell == null) return default(T);

            int rowIndex = gridView.CurrentCell.RowIndex;
            try
            {
                return (T)Convert.ChangeType(gridView.Rows[rowIndex].Cells[colunmIndex].Value, typeof(T));
            }
            catch
            { }

            return default(T);
        }

        public static T GetCurrentRowCellValue<T>(this DataGridView gridView, string colunmName)
        {
            if (string.IsNullOrEmpty(colunmName)) return default(T);
            if (!gridView.Columns.Contains(colunmName)) return default(T);
            if (gridView.CurrentCell == null) return default(T);

            int rowIndex = gridView.CurrentCell.RowIndex;
            try
            {
                return (T)Convert.ChangeType(gridView.Rows[rowIndex].Cells[colunmName].Value, typeof(T));
            }
            catch
            { }

            return default(T);
        }

        public static bool CurrentColunmIsEqual(this DataGridView gridView, string colunmName)
        {
            if (string.IsNullOrEmpty(colunmName)) return false;
            if (gridView.CurrentCell == null) return false;
            if (!gridView.Columns.Contains(colunmName)) return false;

            return (gridView.CurrentCell.ColumnIndex == gridView.Columns[colunmName].Index);
        }
        #endregion

        #region DataRow
        public static T GetDataIntEnum<T>(this System.Data.DataRow dataRow, string colunmName, T def)
        {
            if (string.IsNullOrEmpty(colunmName)) return def;
            if (!dataRow.Table.Columns.Contains(colunmName)) return def;
            if (dataRow.IsNull(colunmName)) return def;

            try
            {
                int value = (int)Convert.ChangeType(dataRow[colunmName], typeof(int));
                return (T)(object)value;
            }
            catch { }

            return def;
        }

        public static T GetData<T>(this System.Data.DataRow dataRow, string colunmName, T def)
        {
            if (string.IsNullOrEmpty(colunmName)) return def;
            if (!dataRow.Table.Columns.Contains(colunmName)) return def;
            if (dataRow.IsNull(colunmName)) return def;

            Type underlyingType = System.Nullable.GetUnderlyingType(typeof(T));
            if (underlyingType != null)
            {
                try
                {
                    return (T)Convert.ChangeType(dataRow[colunmName], underlyingType);
                }
                catch
                { }

                return def;
            }

            try
            {
                return (T)dataRow[colunmName];
            }
            catch { }

            return (T)Convert.ChangeType(dataRow[colunmName], typeof(T));
        }

        public static void SetNewKey(this System.Data.DataRow dataRow, string colunmName)
        {
            if (string.IsNullOrEmpty(colunmName)) return;
            if (!dataRow.Table.Columns.Contains(colunmName)) return;

            dataRow[colunmName] = Guid.NewGuid().ToString().ToUpper();
        }

        public static void CopyTo(this System.Data.DataRow dataRow, ref System.Data.DataRow otherRow)
        {
            if (otherRow == null) return;

            foreach (System.Data.DataColumn column in dataRow.Table.Columns)
            {
                if (otherRow.Table.Columns.Contains(column.ColumnName))
                {
                    try
                    {
                        otherRow[column.ColumnName] = dataRow[column.ColumnName];
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion

        #region Exception
        public static string GetExceptionMessage(this System.Exception ex)
        {
            if (ex == null) return string.Empty;

            string format = "\r\n  Message={0}";
            format += "\r\n  Source={1}";
            format += "\r\n  StackTrace:\r\n{2}";

            string output = "";
            if (ex.InnerException != null)
            {
                format += "\r\n  InnerException: \r\n";
                format += "\r\n    Message={3}";
                format += "\r\n    Source={4}";
                format += "\r\n    StackTrace:\r\n{5}";

                output = string.Format(format, ex.Message, ex.Source, ex.StackTrace, ex.InnerException.Message, ex.InnerException.Source, ex.InnerException.StackTrace);
            }
            else
            {
                format += "\r\n  InnerException: \r\n";
                output = string.Format(format, ex.Message, ex.Source, ex.StackTrace);
            }

            return output;
        }
        #endregion

        #region string
        public static bool IsDigit(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return System.Text.RegularExpressions.Regex.Match(value, @"^\d+$").Success;
        }
        #endregion
    }
}
