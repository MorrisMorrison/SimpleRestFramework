using SimpleRestFramework.Utils;

namespace SimpleRestFramework.Persistence
{
    public class DbConnectionProvider
    {

        public enum DbType
        {
            MONGO
        }

        public DbConfig DbConfig {get;set;}

        public DbConnectionProvider(DbConfig p_dbConfig){
            DbConfig = p_dbConfig;
        }

        public IDbConnection GetDbConnection()
        {
            IDbConnection dbConnection = new DbConnection(DbConfig);

            return dbConnection;
        }
    }
}