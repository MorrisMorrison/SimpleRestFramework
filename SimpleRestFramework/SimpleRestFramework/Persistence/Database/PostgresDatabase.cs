using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using NpgsqlTypes;
using Utilities.Collections;
using Utilities.Persistence;

namespace SimpleRestFramework.Persistence.Database
{
    public class PostgresDatabase : IDatabase
    {
        public DbConfig DbConfig { get; set; }


        public PostgresDatabase(DbConfig p_dbConfig)
        {
            DbConfig = p_dbConfig;
        }

        private void InitDatabase()
        {
            
        }

        public void Create<T>(T p_entity) where T : IEntity
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbConfig.GetPostgresConnectionString()))
            {
                connection.Insert(p_entity);
            }
        }

        public void Update<T>(T p_entity) where T : IEntity
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbConfig.GetPostgresConnectionString()))
            {
                connection.Update(p_entity);
            }
        }

        public void Delete<T>(T p_entity) where T : IEntity
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbConfig.GetPostgresConnectionString()))
            {
                connection.Delete(p_entity);
            }
        }

        public T Get<T>(long p_id) where T : IEntity
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbConfig.GetPostgresConnectionString()))
            {
                return connection.Get<T>(p_id);
            }
        }
    }

}
