using System;
using System.Collections.Generic;
using System.Linq;
using SimpleRestFramework.Persistence;

namespace SimpleRestFramework.Service
{
    public class ServiceFactory
    {
        
    }

    public class CrudServiceFactory : ICrudServiceFactory
    {
        
        public IDaoFactory DaoFactory { get; set; }
        public IList<IService> Services { get; set; } = new List<IService>();
        public IDictionary<Type, Type> Types {get;set;}


        public CrudServiceFactory(IDictionary<Type, Type> p_types, IDaoFactory p_daoFactory)
        {
            Types = p_types;
            DaoFactory = p_daoFactory;
        }

        public ICrudService<T> GetCrudService<T>() where T : IEntity
        {
            ICrudService<T> crudService = (ICrudService<T>) Services.FirstOrDefault(p_service => p_service.GetType() == typeof(ICrudService<T>));

            if (crudService == null){
                if (Types.ContainsKey(typeof(T))){
                    // Create instance of AbstractDao to get default implementations
                    crudService = (ICrudService<T>) Activator.CreateInstance(Types.FirstOrDefault(p_type => p_type.Key == typeof(T)).Value);
                    crudService.Dao = DaoFactory.GetDao<T>();
                    // Set database connection
                }else{
                    // Exception type is not known
                }
            }

            return crudService;
        }
    }
}