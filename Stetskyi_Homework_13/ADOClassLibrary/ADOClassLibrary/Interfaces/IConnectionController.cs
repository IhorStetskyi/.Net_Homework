using System.Data;
using System.Data.SqlClient;


namespace ADOClassLibrary.Interfaces
{
    public interface IConnectionController
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand CMD { get; set; }
        public SqlDataAdapter SQLDataAdapter { get; set; }
        public DataSet DataSetValue { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlConnection GetConnection();
        public void OpenConnection();
        public void BeginTransaction();
        public void CommitTransaction();
        public void RollBackTransaction();
        public void InitiateReader();
        public void CloseReader();
        public int CMDExecuteNonQuery();
        public void AddParameters(string name, object value);
        public void InitializeDataAdapter();
        public void InitializeDataSet();
        public void FillDataSet();
    }
}
