# SimpleRestFramework
This framework supports buildinging simple rest apis in .NET Core.
The Goal is to just define the entities and get a default implementation for all layers to provide a full api.

```csharp

public class Example{

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
                {typeof(ExampleEntity), typeof(ExampleController)}
            };
            ICrudControllerFactory controllerFactory = new CrudControllerFactory(controllers, serviceFactory);
            ICrudController<ExampleEntity> crudController = controllerFactory.GetController<ExampleEntity>();
        }
}

public class ExampleEntity:IEntity{}
public class ExampleDao:AbstractDao<ExampleEntity>{}
public class ExampleService:AbstractCrudService<ExampleEntity>{}
public class ExampleController:AbstractCrudController<ExampleEntity>{}
```

```csharp
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IDao<ExampleEntity>, ExampleDao>();
            services.AddSingleton<ICrudService<ExampleEntity>, ExampleService>();
            services.AddSingleton<ICrudController<ExampleEntity>, ExampleController>();

        }
    }

public class ExampleEntity:IEntity{}
public class ExampleDao:AbstractDao<ExampleEntity>{}
public class ExampleService:AbstractCrudService<ExampleEntity>{}
public class ExampleController:AbstractCrudController<ExampleEntity>{}

```


