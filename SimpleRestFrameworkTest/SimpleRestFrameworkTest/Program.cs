using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Utils;

namespace SimpleRestFrameworkTest
{
    public class Program
    {
        public static void Run(string[] args)
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
            
            
//            CreateHostBuilder(args).Build().Run();
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