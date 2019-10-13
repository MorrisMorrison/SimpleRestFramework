
using SimpleRestFramework.Persistence.Database;

namespace SimpleRestFramework.Persistence
{
    public interface IDbConnection
    {
        IDatabase Database {get;set;}
        DbConfig DbConfig {get;set;}
        
    }
}