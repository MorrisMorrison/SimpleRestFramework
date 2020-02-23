using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleRestFramework.Controller;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Service;
using SimpleRestFramework.Utils;

namespace SimpleRestFrameworkTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            
            IDictionary<Type, Type> daos = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };
            
            DbConfig dbConfig =  ConfigUtils.GetDefaultDbConfig();
            
            DaoFactory daoFactory = new DaoFactory(daos, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();
            
            IDictionary<Type, Type> services = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleService)}
            };
            ICrudServiceFactory serviceFactory = new CrudServiceFactory(services, daoFactory);
            ICrudService<ExampleEntity> crudService = serviceFactory.GetCrudService<ExampleEntity>();
            
            IDictionary<Type, Type> controllers = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleService)}
            };
            ICrudControllerFactory controllerFactory = new CrudControllerFactory(controllers, serviceFactory);
            ICrudController<ExampleEntity> crudController = controllerFactory.GetController<ExampleEntity>();
            
            
            // CreateHostBuilder(args).Build().Run();
        }
        
        
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
    
    public class ExampleEntity:IEntity
    {
        
        public string Name { get; set; }
    }

    public class ExampleDao:AbstractDao<ExampleEntity>{

    }
    
    public class ExampleService:AbstractCrudService<ExampleEntity>{

    }
    
    public class ExampleController:AbstractCrudController<ExampleEntity>{

    }
}