using Microsoft.AspNetCore.Mvc;
using SimpleRestFramework.Persistence;
using SimpleRestFramework.Service;

namespace SimpleRestFramework.Controller
{

    public interface ICrudController<T> where T:IEntity
    {
        ICrudService<T> CrudService { get; set; }
        IActionResult Get();
    }
    
    
    
    public abstract class AbstractCrudController<T>: Microsoft.AspNetCore.Mvc.Controller, ICrudController<T> where T:IEntity
    {
        public ICrudService<T> CrudService
        {
            get; set; 
            
        }

        protected AbstractCrudController(ICrudService<T> p_crudService)
        {
            CrudService = p_crudService;
        }

        public IActionResult Get()
        {
            throw new System.NotImplementedException();
        }
    }
}