﻿using AutoMapper;
using Azure.Core;
using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class KorisniciService : BaseCRUDService<Models.Korisnik, Database.Korisnici, KorisniciSearchObject,UserInsertRequest,UserUpdateRequest>, IKorisniciService
    {
        public KorisniciService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task BeforeInsert(Korisnici entity, UserInsertRequest insert)
        {
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Password);
        }
        public override Task<Korisnik> Insert(UserInsertRequest insert)
        {
            return base.Insert(insert);
        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public override IQueryable<Korisnici> AddInclude(IQueryable<Korisnici> query, KorisniciSearchObject? search = null)
        {
            if(search?.IsUlogeIncluded==true)
            {
                query = query.Include("KorisniciUloges.Uloga");
            }
            return base.AddInclude(query, search);
        }

        public async Task<Korisnik> Login(string username, string password)
        {
            var entity = await _context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);
            if(entity == null)
            {
                return null;
            }
            var hash = GenerateHash(entity.LozinkaSalt, password);
            if(hash!=entity.LozinkaHash)
            {
                return null;
            }
            return _mapper.Map<Korisnik>(entity);
        }
    }
}
