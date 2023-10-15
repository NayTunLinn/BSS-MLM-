using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BSSSoftware.Connection
{
   public class AppSetting
    {
       Configuration config;
       public AppSetting()
       {
           config=ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
       }
       public string GetConnectionString(string key)
       {
           return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
       }
       public void SaveConnectionString(string key, string value)
       {
          this.config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
          this.config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
          this.config.Save(ConfigurationSaveMode.Modified);
       }
    }
}

