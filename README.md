# SimpleRestFramework
This framework supports buildinging simple rest apis in .NET Core.
The Goal is to just define the entities and get a default implementation for all layers to provide a full api.

### Persistence
```csharp

public class Example{

     public static void Main(string[] args)
        {

            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };


            DbConfig dbConfig = ConfigUtils.GetDefaultDbConfig();

            DaoFactory daoFactory = new DaoFactory(types, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();

            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 4,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            dao.Create(exampleEntity);

            ExampleEntity entity = dao.Get(4);
        }
}

public class ExampleEntity:IEntity{}
public class ExampleDao:AbstractDao<ExampleEntity>{}
```

### Service

```csharp

public class Example{

    public static void Main(string[] args)
    {
            ServiceFactory serviceFactory = new ServiceFactory();
            IService<ExampleEntity> service = serviceFactory.GetService<ExampleEntity>();
    
    }
}

public class ExampleEntity:IEntity{}


```

### Controller

```csharp

public class Example{
    public static void Main(string[] args)
        {

                ControllerFactory controllerFactory = new ControllerFactory();
                IController<ExampleEntity> controller = serviceFactory.GetController<ExampleEntity>();

        }
}

public class ExampleEntity:IEntity{}


```

