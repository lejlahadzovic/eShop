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
    public class JediniceMjereController : BaseController<Models.JedinicaMjere,JediniceMjereSearchObject>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<BaseController<JedinicaMjere, JediniceMjereSearchObject>> logger) : base(service, logger)
        {
        }
    }
}