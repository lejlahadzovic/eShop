﻿using AutoMapper;
using eShop.Models;
using eShop.Models.SearchObjects;
using eShop.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class JediniceMjereService : BaseService<Models.JedinicaMjere,Database.JediniceMjere,JediniceMjereSearchObject>, IJediniceMjereService
    {
        public JediniceMjereService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<JediniceMjere> AddFilter(IQueryable<JediniceMjere> query, JediniceMjereSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                query = query.Where(x => x.Naziv.Contains(search.FTS));
            }
            return base.AddFilter(query, search);
        }
    }
}
