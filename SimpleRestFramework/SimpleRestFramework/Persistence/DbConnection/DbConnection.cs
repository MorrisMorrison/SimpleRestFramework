using SimpleRestFramework.Persistence.Database;

namespace SimpleRestFramework.Persistence
{
    public class DbConnection : IDbConnection
    {
        public DbConfig DbConfig { get; set; }
        public IDatabase Database { get; set; }

        public DbConnection(DbConfig p_dbConfig)
        {
            DbConfig = p_dbConfig;

            if (DbConfig.IsSqlDb){
                Database = new MySqlDatabase(DbConfig);
//                Database = new PostgresDatabase(DbConfig);
            }else{
                Database = new MongoDatabase(DbConfig);
            }
        }
        
    }
}