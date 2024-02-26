using AutoMapper;
using eShop.Models;
using eShop.Models.Request;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.ProizvodiStateMachine
{
    public class InitialProductState : BaseState
    {
        public InitialProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) : base(serviceProvider,context, mapper)
        {
        }
        public override async Task<Proizvod> Insert(ProizvodInsertRequest request)
        {
            var set = _context.Set<Proizvodi>();
            var entity = _mapper.Map<Proizvodi>(request);
            entity.StateMachine = "draft";
            set.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Proizvod>(entity);
        }
        public override async Task<List<string>> AllowedActions()
        {
            var list= await base.AllowedActions();
            list.Add("Insert");
            return list;
        }
    }
}
