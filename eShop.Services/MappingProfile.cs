using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eShop.Models.Request;

namespace eShop.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Database.Korisnici, Models.Korisnik>();
            CreateMap<UserInsertRequest,Database.Korisnici>();
            CreateMap<UserUpdateRequest, Database.Korisnici>();
            CreateMap<Database.JediniceMjere,Models.JedinicaMjere>();
            CreateMap<Database.VrsteProizvodum, Models.VrsteProizvoda>();
            CreateMap<Database.KorisniciUloge, Models.KorisnikUloga>();
            CreateMap<Database.Uloge, Models.Uloga>();
            CreateMap<Database.Proizvodi, Models.Proizvod>();
            CreateMap<ProizvodInsertRequest, Database.Proizvodi>();
            CreateMap<ProizvodUpdateRequest, Database.Proizvodi>()
                .ForAllMembers(opts=>opts.Condition((src,dest,srcMember)=>srcMember!=null));
        }
    }
}
