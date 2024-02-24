using AutoMapper;
using Azure.Core;
using eShop.Models;
using eShop.Models.Request;
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
    public class KorisniciService : IKorisniciService
    {
        protected EProdajaContext _context;
        public IMapper _mapper {  get; set; }
        public KorisniciService(EProdajaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Models.Korisnik>> Get()
        {
            var etityLsit = await _context.Korisnicis.ToListAsync();
            return _mapper.Map<List<Models.Korisnik>>(etityLsit);
        }
        public Korisnik Insert(UserInsertRequest request)
        {
            var entity = new Korisnici();
            _mapper.Map(request, entity);
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt,request.Password);
            _context.Korisnicis.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Models.Korisnik>(entity);
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
        public Korisnik Update(int id, UserUpdateRequest request)
        {
            var entity=_context.Korisnicis.Find(id);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Korisnik>(entity);
        }
    }
}
