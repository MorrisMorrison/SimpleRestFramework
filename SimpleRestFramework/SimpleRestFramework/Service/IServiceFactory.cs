using SimpleRestFramework.Persistence;

namespace SimpleRestFramework.Service
{
    public interface IServiceFactory
    {
    }

    public interface ICrudServiceFactory : IServiceFactory
    {
        ICrudService<T> GetCrudService<T>() where T : IEntity;
    }
}