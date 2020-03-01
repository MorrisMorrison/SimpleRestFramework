namespace SimpleRestFramework.Persistence
{
    public abstract class AbstractDao<T> : IDao<T> where T : IEntity
    {
        public IDbConnection DbConnection
        {
            get; set;
        }

        protected AbstractDao(IDbConnection p_dbConnection)
        {
            DbConnection = p_dbConnection;
        }

        public void Create(T p_entity)
        {
            DbConnection.Database.Create<T>(p_entity);
        }

        public void Delete(T p_entity)
        {
            DbConnection.Database.Delete<T>(p_entity);
        }

        public T Get(long p_id)
        {
            return DbConnection.Database.Get<T>(p_id);
        }

        public void Update(T p_entity)
        {
            DbConnection.Database.Update<T>(p_entity);
        }
    }
}