using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Utils;

namespace SimpleRestFrameworkTest.Tests
{
    
    [TestFixture]
    public class PersistenceTests
    {
        
        private string _connectionString =
            "Server=localhost;Port=3306;Database=tests;User=mysql;Password=password;";

        private DbConfig _dbConfig;
        private DaoFactory _daoFactory;
        private IDao<ExampleEntity> _dao;


        [SetUp]
        public void SetUp()
        {
            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };

            _dbConfig =  ConfigUtils.GetDefaultDbConfig();
            _daoFactory = new DaoFactory(types, _dbConfig);
            _dao = _daoFactory.GetDao<ExampleEntity>();
            
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sqlScript = File.ReadAllText("../../../../SetupTestData.sql");
                MySqlCommand mysqlCommand = new MySqlCommand(sqlScript, connection);
                mysqlCommand.ExecuteNonQuery();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand mysqlCommand = new MySqlCommand(@"DROP TABLE ExampleEntitys;", connection);
                mysqlCommand.ExecuteNonQuery();
            }
        }

        [Test]
        public void GetShouldReturnEntity()
        {
            ExampleEntity entity = _dao.Get(5);
         
            Assert.AreEqual(5, entity.Id);
            Assert.AreEqual("test5", entity.Name);
        }

        [Test]
        public void GetShouldReturnNull()
        {
            ExampleEntity entity = _dao.Get(99);
            
            Assert.IsNull(entity);
        }

        [Test]
        public void CreateShouldCreateEntity()
        {
            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 7,
                Name = "test7"
            };

            _dao.Create(exampleEntity);

            ExampleEntity entity = _dao.Get(7);
         
            Assert.AreEqual(exampleEntity.Id, entity.Id);
            Assert.AreEqual(exampleEntity.Name, entity.Name);

        }

        [Test]
        public void DeleteShouldDeleteEntity()
        {
            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 7,
                Name = "test7"
            };

            _dao.Create(exampleEntity);
            _dao.Delete(exampleEntity);
            ExampleEntity entity = _dao.Get(7);

            Assert.IsNull(entity);

        }
        
        [Test]
        public void UpdateShouldDeleteEntity()
        {
            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 5,
                Name = "test36"
            };

            _dao.Update(exampleEntity);
            ExampleEntity entity = _dao.Get(5);

                    
            Assert.AreEqual(exampleEntity.Id, entity.Id);
            Assert.AreEqual(exampleEntity.Name, entity.Name);
        }
        


        [Test]
        public void GeneralPersistenceTest()
        {
            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 7,
                Name = "test4"
            };

            _dao.Create(exampleEntity);

            ExampleEntity entity = _dao.Get(7);
         
            Assert.AreEqual(exampleEntity.Id, entity.Id);
            Assert.AreEqual(exampleEntity.Name, entity.Name);

            exampleEntity.Name = "test36";
            
            _dao.Update(exampleEntity);
            
            ExampleEntity entityAfterUpdate = _dao.Get(7);
            Assert.AreEqual(exampleEntity.Name, entityAfterUpdate.Name);
            
            _dao.Delete(exampleEntity);
            
            ExampleEntity entityAfterDelete = _dao.Get(7);
            Assert.IsNull(entityAfterDelete);
        }
        
        
    }
}