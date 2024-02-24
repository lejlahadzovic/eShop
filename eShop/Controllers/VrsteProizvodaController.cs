using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace eShop.Controllers
{
    [ApiController]
    public class VrsteProizvodaController : BaseController<Models.VrsteProizvoda, BaseSearchObject>
    {
        public VrsteProizvodaController(IService<VrsteProizvoda, BaseSearchObject> service, ILogger<BaseController<VrsteProizvoda, BaseSearchObject>> logger) : base(service, logger)
        {
        }
    }
}