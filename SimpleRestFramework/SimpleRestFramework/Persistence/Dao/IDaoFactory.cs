using System;
using System.Collections.Generic;

namespace SimpleRestFramework.Persistence
{
    public interface IDaoFactory
    {
        IList<IDao<IEntity>> Daos { get; set; }
        public IDictionary<Type, Type> Types {get;set;}

        IDao<T> GetDao<T>() where T : IEntity;
    }
}