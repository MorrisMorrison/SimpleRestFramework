using System;
using System.Collections.Generic;

namespace SimpleRestFramework.Generator
{
    public class DaoConfig
    {
        public IDictionary<string, Type> DaosToCreate{get;set;}

        public DaoConfig(IDictionary<string, Type> p_daosToCreate){
            p_daosToCreate = DaosToCreate;
        }

    }
}