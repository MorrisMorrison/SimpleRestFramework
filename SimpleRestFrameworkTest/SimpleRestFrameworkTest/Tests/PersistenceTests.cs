using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using Npgsql;
using NUnit.Framework;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Utils;

namespace SimpleRestFrameworkTest.Tests
{
    
    [TestFixture]
    public class PersistenceTests
    {
        
        private string _connectionString =
            "Server=localhost;Port=3306;Database=tests;User=mysql;Password=developmentPW123!;";


        [SetUp]
        public void SetUp()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sqlScript = File.ReadAllText("../../../../SetupTestData.sql");
                MySqlCommand npgsqlCommand = new MySqlCommand(sqlScript, connection);
                npgsqlCommand.ExecuteNonQuery();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand npgsqlCommand = new MySqlCommand(@"DROP TABLE ExampleEntitys;", connection);
                npgsqlCommand.ExecuteNonQuery();
            }
        }


        [Test]
        public void GeneralPersistenceTest()
        {
            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };

            DbConfig dbConfig =  ConfigUtils.GetDefaultDbConfig();

            DaoFactory daoFactory = new DaoFactory(types, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();

            ExampleEntity exampleEntity = new ExampleEntity(){
                Id = 7,
                Name = "test4"
            };

            dao.Create(exampleEntity);

            ExampleEntity entity = dao.Get(7);
         
            Assert.AreEqual(exampleEntity.Id, entity.Id);
            Assert.AreEqual(exampleEntity.Name, entity.Name);
        }
        
        
    }
}