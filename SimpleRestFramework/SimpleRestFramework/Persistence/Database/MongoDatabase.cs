using System;
using MongoDB.Driver;

namespace SimpleRestFramework.Persistence.Database
{
    public class MongoDatabase : IDatabase
    {

        private IMongoDatabase  _database { get; set; }
        public DbConfig DbConfig {get;set;}

        public MongoDatabase(DbConfig p_dbConfig){
            DbConfig = p_dbConfig;

            InitMongoDbDatabase();
        }

        private void InitMongoDbDatabase(){
             var client = new MongoClient(connectionString: DbConfig.GetMongoConnectionString());
            _database = client.GetDatabase(DbConfig.DbName);
        }

        public void Create<T>(T p_entity) where T : IEntity
        {
            Type type = typeof(T);

            IMongoCollection<T> collection = _database.GetCollection<T>(type.Name);
            collection.InsertOne(p_entity);
        }

        public void Delete<T>(T p_entity) where T: IEntity
        {
            Type type = typeof(T);

            IMongoCollection<T> collection = _database.GetCollection<T>(type.Name);
            DeleteResult result = collection.DeleteOne(p_item => p_item.Id == p_entity.Id);
        }

        public T Get<T>(long p_id) where T: IEntity
        {
            Type type = typeof(T);

            IMongoCollection<T> collection = _database.GetCollection<T>(type.Name);
            T entity = (T) collection.Find(p_item => p_item.Id == p_id).FirstOrDefault();

            return entity;
        }

        public void Update<T>(T p_entity) where T: IEntity
        {
            // Type type = typeof(T);

            //  IMongoCollection<T> collection = _database.GetCollection<T>(type.Name);
            // var updateDef = Builders<T>.Update.Set(p_task => p_task.Email, p_job.Email)
            //                                                        .Set(p_task => p_task.Repositories, p_job.Repositories)
            //                                                        .Set(p_task => p_task.SearchKeywords, p_job.SearchKeywords)
            //                                                        .Set(p_task => p_task.LastExecutedAt, p_job.LastExecutedAt)
            //                                                        .Set(p_task => p_task.Status, p_job.Status)
            //                                                        .Set(p_task => p_task.Results, p_job.Results)
            //                                                        .Set(p_task => p_task.PhoneNumber, p_job.PhoneNumber)
            //                                                        .Set(p_task => p_task.EmailNotificationEnabled, p_job.EmailNotificationEnabled)
            //                                                        .Set(p_task => p_task.SmsNotificationEnabled, p_job.SmsNotificationEnabled)
            //                                                        .Set(p_task => p_task.WhatsappNotificationEnabled, p_job.WhatsappNotificationEnabled)
            //                                                        .Set(p_task => p_task.UpdatedAt, p_job.UpdatedAt)
            //                                                        .Set(p_task => p_task.SchedulerEnabled, p_job.SchedulerEnabled);

            // UpdateResult result = collection.UpdateOne(p_task => p_task.Username == p_job.Username && p_task.Frequency == p_job.Frequency, updateDef);


        }
    }
}