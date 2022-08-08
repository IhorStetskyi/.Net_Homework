using System.Configuration;
using System.Data.SqlClient;
using ADOClassLibrary.Interfaces;
using ADOClassLibrary.StaticClasses;

namespace ADOClassLibrary.ConnectionProviderFolder
{
    public class ConnectionProvider : IConnectionProvider
    {
        public ConnectionProvider()
        {
            Configuration config = StaticSourceMethods.CreateNewConfig();
            config.ClearConfigurationManagerConnectionStrings();
            config.AddConnectionSettingsToConfig(@".\MYMSSQLSERVER", "Homework13", "MyConnection");
            config.ProtectConnectionData(true);
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(StaticSourceMethods.GetConnectionString("MyConnection"));
        }
    }
}
