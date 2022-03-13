using System.Collections.Generic;

namespace SoftwarePlannerLibrary.Data
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement,
                               U parameters,
                               string connectionStringName,
                               bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement,
                         T parameters,
                         string ConnectionStringName,
                         bool isStoredProcedure = false);
    }
}