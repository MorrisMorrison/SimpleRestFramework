
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRestFramework.Persistence
{
    public class DaoFactory:IDaoFactory
    {
        public IList<IDao<IEntity>> Daos { get; set; } = new List<IDao<IEntity>>();
        public IDictionary<Type, Type> Types {get;set;}
        public DbConfig DbConfig {get;set;}
        public DaoFactory(IDictionary<Type, Type> p_types, DbConfig p_dbConfig)
        {
            Types = p_types;
            DbConfig = p_dbConfig;
        }


        public IDao<T> GetDao<T>() where T:IEntity
        {
            IDao<T> dao = (IDao<T>) Daos.FirstOrDefault(p_dao => p_dao.GetType() == typeof(IDao<T>));

            if (dao == null){
                if (Types.ContainsKey(typeof(T))){
                    // Create instance of AbstractDao to get default implementations
                    dao = (IDao<T>) Activator.CreateInstance(Types.FirstOrDefault(p_type => p_type.Key == typeof(T)).Value);
                    // Set database connection
                    dao.DbConnection = new DbConnectionProvider(DbConfig).GetDbConnection();
                }else{
                    // Exception type is not known
                }
            }

            return dao;
        }

    }
}

