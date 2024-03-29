using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    public class KorisnikController : BaseCRUDController<Models.Korisnik, KorisniciSearchObject,UserInsertRequest,UserUpdateRequest>
    {
        public KorisnikController(IKorisniciService service, ILogger<BaseController<Korisnik, KorisniciSearchObject>> logger) : base(service, logger)
        {
        }
        [Authorize(Roles ="Administrator")]
        public override Task<Korisnik> Insert([FromBody] UserInsertRequest insert)
        {
            return base.Insert(insert);
        }
    }  
}