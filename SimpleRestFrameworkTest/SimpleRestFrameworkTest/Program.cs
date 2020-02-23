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
            
            
            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };
            
            DbConfig dbConfig =  ConfigUtils.GetDefaultDbConfig();
            
            DaoFactory daoFactory = new DaoFactory(types, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();
            
            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 4,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            dao.Create(exampleEntity);
            
            ExampleEntity entity = dao.Get(4);
            Console.WriteLine(entity.Id);
            
            ICrudServiceFactory serviceFactory = new CrudServiceFactory(types, daoFactory);
            ICrudService<ExampleEntity> crudService = serviceFactory.GetCrudService<ExampleEntity>();
            
            ICrudControllerFactory controllerFactory = new CrudControllerFactory(types, serviceFactory);
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
}