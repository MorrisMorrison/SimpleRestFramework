using System.Collections.Generic;

namespace SimpleRestFramework.Persistence
{
    public interface IDaoConfig
    {
        IList<string> DaosToCreate { get; set; }       
    }
}