using eShop.Models;
using eShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [Route("[controller]")]
    public class BaseCRUDController<T, TSearch,TInsert,TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class
    {
        protected readonly ICRUDService<T,TSearch, TInsert, TUpdate> _service;
        protected readonly ILogger<BaseController<T, TSearch>> _logger;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service, ILogger<BaseController<T, TSearch>> logger) : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost]
        public virtual async Task<T> Insert([FromBody]TInsert insert)
        {
          return await _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public virtual async Task<T> Update(int id, [FromBody] TUpdate update)
        {
            return await _service.Update(id,update);
        }
    }
}
