using eShop.Models;
using eShop.Models.Request;
using eShop.Services;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController( IUserService userservice)
        {
            _userservice = userservice;
        }
        [HttpGet()]
        public List<Models.Korisnik> GetUser()
        {
            return _userservice.Get();
        }
        [HttpPost()]
        public Models.Korisnik Insert(UserInsertRequest request)
        {
            return _userservice.Insert(request);
        }
        [HttpPut()]
        public Models.Korisnik Update(int id,UserUpdateRequest request)
        {
            return _userservice.Update(id,request);
        }
    }  
}