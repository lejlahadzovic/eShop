using eShop.Models;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class ProductsService : IProductsService
    {
        EProdajaContext _context;
        public ProductsService(EProdajaContext context)
        {
            _context = context;
        }

        //List<Proizvodi> products = new List<Proizvodi>()
        //{
        //    new Proizvodi()
        //    {
        //        ProizvodId=1,
        //        Naziv="Laptop"
        //    }
        //};
        public IList<Proizvodi> Get()
        {
            var list = _context.Proizvodis.ToList();

            return list;
        }

    }
}
