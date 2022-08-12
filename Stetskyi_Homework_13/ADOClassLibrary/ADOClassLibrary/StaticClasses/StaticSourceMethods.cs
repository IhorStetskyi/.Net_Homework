using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ADOClassLibrary.Models;

namespace ADOClassLibrary.StaticClasses
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

        public static void WriteAllProducts(this List<Product> products)
        {
            foreach (Product p in products)
            {
                Console.WriteLine($"  PRODUCT ID: {p.Id} || Description: {p.Description} || Weight: {p.Weight} || Height: {p.Height} || Width: {p.Width} || Length: {p.Length}");
            }
        }
        public static void WriteAllOrders(this List<Order> orders)
        {
            foreach (Order o in orders)
            {
                Console.WriteLine($"  ORDER ID: {o.Id} || Status: {o.Status} || CreatedDate: {o.CreatedDate} || UpdatedDate: {o.UpdatedDate} || ProductId: {o.ProductId}");
            }
        }
    }
}
