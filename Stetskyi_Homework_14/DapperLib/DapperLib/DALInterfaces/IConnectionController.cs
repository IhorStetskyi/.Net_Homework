using System.Collections.Generic;


namespace DapperLib.DALInterfaces
{
    public interface IConnectionController
    {
        public List<T> LoadData<T>(string sql);
        public void CRUDData<T>(string sql, T item);
        public List<T> LoadDataFiltred<T>(string sql, object myParams);
        public void DeleteDataFiltred(string sql, object myParams);
        public void ExecuteQuery(string sql);
        public void ExecuteStoredProcedure(string procedureName);
    }
}
