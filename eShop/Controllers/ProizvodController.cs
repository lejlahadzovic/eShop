using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    public class ProizvodController : BaseCRUDController<Models.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        public ProizvodController(IProizodiService service, ILogger<BaseController<Proizvod, ProizvodSearchObject>> logger) : base(service, logger)
        {
        }
        [HttpPut("{id}/activate")]
        public virtual async Task<Proizvod> Activate(int id)
        {
            return await (_service as IProizodiService).Activate(id);
        }
    }
}