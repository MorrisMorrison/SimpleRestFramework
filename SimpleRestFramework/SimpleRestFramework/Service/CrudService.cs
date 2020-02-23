using System.Runtime.CompilerServices;
using SimpleRestFramework.Persistence;

namespace SimpleRestFramework.Service
{

    public interface ICrudService<T>:IService where T:IEntity
    {
        IDao<T> Dao { get; set; }

        T Get(long p_id);
        void Create(T p_entity);
        void Update(T p_entity);
        void Delete(T p_entity);

    }
    
    public abstract class AbstractCrudService<T>:ICrudService<T>  where T:IEntity
    {
        public IDao<T> Dao { get; set; }

        protected AbstractCrudService(IDao<T> p_dao)
        {
            Dao = p_dao;
        }

        public T Get(long p_id)
        {
            return Dao.Get(p_id);
        }

        public void Create(T p_entity)
        {
            Dao.Create(p_entity);
        }

        public void Update(T p_entity)
        {
            Dao.Update(p_entity);
        }

        public void Delete(T p_entity)
        {
            Dao.Delete(p_entity);
        }
    }
}