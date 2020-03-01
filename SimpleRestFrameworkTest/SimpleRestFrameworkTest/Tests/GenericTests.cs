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
    public class GenericTests
    {
        
        private string _connectionString =
            "Server=localhost;Port=3306;Database=tests;User=mysql;Password=password;";
        
        [SetUp]
        public void SetUp()
        {
            
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
        public void GenericDaoFactoryTest()
        {
            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };
            
            DbConfig dbConfig = ConfigUtils.GetDefaultDbConfig();
            DaoFactory daoFactory = new DaoFactory(types, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();
            
            Assert.AreEqual(typeof(ExampleDao), dao.GetType());
        }

        [Test]
        public void GenericDaoTest()
        {
            IDictionary<Type, Type> types = new Dictionary<Type, Type>(){
                {typeof(ExampleEntity), typeof(ExampleDao)}
            };
            
            DbConfig dbConfig = ConfigUtils.GetDefaultDbConfig();
            DaoFactory daoFactory = new DaoFactory(types, dbConfig);
            IDao<ExampleEntity> dao = daoFactory.GetDao<ExampleEntity>();

            ExampleEntity exampleEntity = dao.Get(1);

            Assert.AreEqual(typeof(ExampleEntity), exampleEntity.GetType());
        }
        
    }
}