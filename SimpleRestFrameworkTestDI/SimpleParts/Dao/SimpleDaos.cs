using SimpleRestFramework.Persistence;
using SimpleRestFrameworkTestDI.SimpleParts.Entity;

namespace SimpleRestFrameworkTestDI.SimpleParts.Dao
{
    public class ExampleDao : AbstractDao<ExampleEntity>
    {
        public ExampleDao(IDbConnection p_dbConnection) : base(p_dbConnection)
        {
        }
    }
}