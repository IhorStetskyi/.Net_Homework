using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ADOClassLibrary.Interfaces;
using ADOClassLibrary.StaticClasses;

namespace ADOClassLibrary.ConnectionProviderFolder
{
    public class ConnectionController : IConnectionController
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand CMD { get; set; }
        public SqlDataAdapter SQLDataAdapter { get; set; }
        public DataSet DataSetValue { get; set; }
        public SqlDataReader Reader { get; set; }

        public ConnectionController()
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

        public void OpenConnection()
        {
            Connection.Open();
        }
        public void BeginTransaction()
        {
            CMD.Transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }
        public void CommitTransaction()
        {
            CMD.Transaction.Commit();
        }
        public void RollBackTransaction()
        {
            CMD.Transaction.Rollback();
        }
        public void InitiateReader()
        {
            Reader = CMD.ExecuteReader();
        }
        public void CloseReader()
        {
            Reader.Close();
        }
        public void InitializeDataAdapter()
        {
            SQLDataAdapter = new SqlDataAdapter(CMD);
        }
        public void InitializeDataSet()
        {
            DataSetValue = new DataSet();
        }
        public int CMDExecuteNonQuery()
        {
            return CMD.ExecuteNonQuery();
        }
        public void AddParameters(string name, object value)
        {
            CMD.Parameters.AddWithValue(name, value);
        }
        public void FillDataSet()
        {
            SQLDataAdapter.Fill(DataSetValue);
        }
    }
}
