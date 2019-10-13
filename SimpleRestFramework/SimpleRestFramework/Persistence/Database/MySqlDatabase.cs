using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace SimpleRestFramework.Persistence.Database
{
    public class MySqlDatabase : IDatabase
    {
        public DbConfig DbConfig { get; set; }


        public MySqlDatabase(DbConfig p_dbConfig)
        {
            DbConfig = p_dbConfig;
        }

        private void InitDatabase()
        {
            
        }

        public void Create<T>(T p_entity) where T : IEntity
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.GetMySqlConnectionString()))
            {
                connection.Insert(p_entity);
            }
        }

        public void Update<T>(T p_entity) where T : IEntity
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.GetMySqlConnectionString()))
            {
                connection.Update(p_entity);
            }
        }

        public void Delete<T>(T p_entity) where T : IEntity
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.GetMySqlConnectionString()))
            {
                connection.Delete(p_entity);
            }
        }

        public T Get<T>(long p_id) where T : IEntity
        {
            using (MySqlConnection connection = new MySqlConnection(DbConfig.GetMySqlConnectionString()))
            {
                return connection.Get<T>(p_id);
            }
        }
    }
}