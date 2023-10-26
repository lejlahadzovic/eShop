using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class ProductsService : IProductsService
    {
        List<Products> products = new List<Products>()
        {
            new Products()
            {
                Id=1,
                Name="Laptop"
            }
        };
        public IList<Products> Get()
        {
            throw new NotImplementedException();
        }
    }
}
