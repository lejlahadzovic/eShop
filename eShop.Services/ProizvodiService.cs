using eShop.Models;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class ProizvodiService : IProizodiService
    {
        EProdajaContext _context;
        public ProizvodiService(EProdajaContext context)
        {
            _context = context;
        }
        public IList<Proizvodi> Get()
        {
            var list = _context.Proizvodis.ToList();
            return list;
        }
    }
}
