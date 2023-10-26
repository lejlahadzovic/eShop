using eShop.Models;
using eShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        private readonly ILogger<WeatherForecastController> _logger;

        public ProductsController(ILogger<WeatherForecastController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet()]
        public IEnumerable<Products> GetProducts()
        {
            return _productsService.Get();
        }
    }
}