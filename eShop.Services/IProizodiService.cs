using eShop.Models;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eShop.Services
{
    public interface IProizodiService
    {
        IList<Proizvodi> Get();
    }
}
