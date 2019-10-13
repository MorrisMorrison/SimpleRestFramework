namespace SimpleRestFramework.Persistence.Database
{
    public interface IDatabase
    {
        DbConfig DbConfig {get;set;}
        void Create<T>(T p_entity) where T:IEntity;
        void Update<T>(T p_entity) where T:IEntity;
        void Delete<T>(T p_entity) where T:IEntity;
        T Get<T>(long p_id) where T : IEntity;
    }
}