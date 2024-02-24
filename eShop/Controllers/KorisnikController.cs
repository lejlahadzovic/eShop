using eShop.Models;
using eShop.Models.Request;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisniciService _userservice;
        public KorisnikController( IKorisniciService userservice)
        {
            _userservice = userservice;
        }
        [HttpGet()]
        public async Task<List<Models.Korisnik>> GetUser()
        {
            return await _userservice.Get();
        }
        [HttpPost()]
        public Models.Korisnik Insert(UserInsertRequest request)
        {
            return _userservice.Insert(request);
        }
        [HttpPut("{id}")]
        public Models.Korisnik Update(int id,UserUpdateRequest request)
        {
            return _userservice.Update(id,request);
        }
    }  
}