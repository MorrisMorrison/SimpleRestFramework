namespace SimpleRestFramework.Persistence
{
    public interface IDao<T> where T : IEntity
    {
        IDbConnection DbConnection {get;set;}
        
        // provide crud methods
        void Create(T p_entity);
        T Get(long p_id);
        void Update(T p_entity);
        void Delete(T p_entity);
    }

}