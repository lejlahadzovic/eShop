using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Models.Request;

namespace eShop.Services
{
    public interface IUserService
    {
        List<Models.Korisnik> Get();
        Models.Korisnik Insert(UserInsertRequest request);
        Models.Korisnik Update(int id, UserUpdateRequest request);
    }
}
