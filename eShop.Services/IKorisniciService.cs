using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Models.Request;
using eShop.Models.SearchObjects;

namespace eShop.Services
{
    public interface IKorisniciService : ICRUDService<Models.Korisnik, KorisniciSearchObject,UserInsertRequest,UserUpdateRequest>
    {
        public Task<Models.Korisnik> Login(string username, string password); 
    }
}
