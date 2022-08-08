using System.Data.SqlClient;


namespace ADOClassLibrary.Interfaces
{
    public interface IConnectionProvider
    {
        public SqlConnection GetConnection();
    }
}
