using System;
using Dapper.Contrib.Extensions;

namespace SimpleRestFramework.Persistence
{
    public class IEntity
    {
        [ExplicitKey]
        public long Id {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}