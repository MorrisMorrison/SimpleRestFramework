namespace SimpleRestFramework.Persistence
{
    public class DbConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ServerUrl { get; set; }
        public string Provider { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public bool IsSqlDb { get; set; }
        public string Schema { get; set; }

        public DbConfig(string username, string password, string serverUrl, int port, string dbName, string schema)
        {
            Username = username;
            Password = password;
            ServerUrl = serverUrl;
            Port = port;
            DbName = dbName;
            IsSqlDb = true;
            Schema = schema;
        }

        public DbConfig(string provider, string username, string password, string serverUrl, int port, string dbName)
        {
            Provider = provider;
            Username = username;
            Password = password;
            ServerUrl = serverUrl;
            Port = port;
            DbName = dbName;
            IsSqlDb = false;
        }

        public string GetMongoConnectionString()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password)){
                return  "mongodb://" + ServerUrl + ":" + Port + "/" + DbName;
            }

            return "mongodb://" + Username + ":" + Password + "@" + ServerUrl + ":" + Port + "/" + Username;
        }


        public string GetMySqlConnectionString()
        {
            
            return $"server={ServerUrl};port={Port};database={DbName};user={Username};password={Password};";

        }

        public string GetPostgresConnectionString()
        {
            return $"Server={ServerUrl};Port={Port};Database={DbName};User ID={Username};Password={Password};";
        }

        public string GetConnectionString()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password)){
                return  Provider + "://" + ServerUrl + ":" + Port + "/" + DbName;
            }

            return Provider + Username + ":" + Password + "@" + ServerUrl + ":" + Port + "/" + DbName;
        }



    }
}