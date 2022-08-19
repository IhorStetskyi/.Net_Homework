using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.StaticFolder
{
    public static class StaticSourceMethods
    {
        public static Configuration CreateNewConfig()
        {
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config;
        }
        public static void ClearConfigurationManagerConnectionStrings(this Configuration config)
        {
            foreach (ConnectionStringSettings section in config.ConnectionStrings.ConnectionStrings)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(section.Name);
            }
            config.Save();
        }
        public static void ProtectConnectionData(this Configuration config, bool protect)
        {
            ConnectionStringsSection css = config.GetSection("connectionStrings") as ConnectionStringsSection;
            switch (protect)
            {
                case true:
                    css.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    config.Save();
                    break;
                case false:
                    css.SectionInformation.UnprotectSection();
                    config.Save();
                    break;
            }
        }
        public static void AddConnectionSettingsToConfig(this Configuration config, string dataSource, string initialCatalog, string connectionSettingsName)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            ConnectionStringSettings connectionSettings = new ConnectionStringSettings();

            stringBuilder.DataSource = dataSource;
            stringBuilder.InitialCatalog = initialCatalog;
            stringBuilder.IntegratedSecurity = true;
            stringBuilder.Pooling = true;

            connectionSettings.Name = connectionSettingsName;
            connectionSettings.ConnectionString = stringBuilder.ConnectionString;

            config.ConnectionStrings.ConnectionStrings.Add(connectionSettings);
            config.Save();
        }
        public static string GetConnectionString(string connectionSettingName)
        {
            return ConfigurationManager.ConnectionStrings[connectionSettingName].ConnectionString;
        }
    }
}
