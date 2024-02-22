using eShop.Models;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
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