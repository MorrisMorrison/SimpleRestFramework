using System;
using System.Collections.Generic;
using System.Linq;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Service;

namespace SimpleRestFramework.Controller
{
    public interface IControllerFactory
    {
        IServiceFactory ServiceFactory { get; set; }
 
    }

    public interface ICrudControllerFactory
    {
        ICrudServiceFactory ServiceFactory { get; set; }
        public IList<IController> Controllers { get; set; }
        public IDictionary<Type, Type> Types {get;set;}
        ICrudController<T> GetController<T>() where T : IEntity;
    }

    public class CrudControllerFactory:ICrudControllerFactory
    {
        public ICrudServiceFactory ServiceFactory { get; set; }
        public IList<IController> Controllers { get; set; } = new List<IController>();
        public IDictionary<Type, Type> Types { get; set; }

        public CrudControllerFactory(IDictionary<Type, Type> p_types, ICrudServiceFactory p_serviceFactory )
        {
            ServiceFactory = p_serviceFactory;
            Types = p_types;
        }
        
        public ICrudController<T> GetController<T>() where T:IEntity
        {
            ICrudController<T> controller = (ICrudController<T>) Controllers.FirstOrDefault(p_dao => p_dao.GetType() == typeof(ICrudController<T>));

            if (controller == null){
                if (Types.ContainsKey(typeof(T))){
                    // Create instance of AbstractDao to get default implementations
                    controller = (ICrudController<T>) Activator.CreateInstance(Types.FirstOrDefault(p_type => p_type.Key == typeof(T)).Value);
                    controller.CrudService = ServiceFactory.GetCrudService<T>();
                    // Set database connection
                }else{
                    // Exception type is not known
                }
            }

            return controller;
        }
    }
}