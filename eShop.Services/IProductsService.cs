using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eShop.Services
{
    public interface IProductsService
    {
        IList<Products> Get();
    }
}
