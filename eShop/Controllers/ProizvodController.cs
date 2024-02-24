using eShop.Models;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController : ControllerBase
    {
        private readonly IProizodiService _productsService;

        public ProizvodController(IProizodiService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet()]
        public IEnumerable<Proizvodi> GetProducts()
        {
            return _productsService.Get();
        }
    }
}