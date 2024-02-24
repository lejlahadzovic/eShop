﻿using eShop.Models;
using eShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [Route("[controller]")]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        private readonly IService<T,TSearch> _service;
        private readonly ILogger<BaseController<T, TSearch>> _logger;
        public BaseController(IService<T, TSearch> service, ILogger<BaseController<T, TSearch>> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet()]
        public async Task<PagedResult<T>> Get([FromQuery]TSearch? search = null)
        { 
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);

        }
    }
}