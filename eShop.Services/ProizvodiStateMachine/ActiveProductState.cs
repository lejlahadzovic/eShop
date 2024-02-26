using AutoMapper;
using eShop.Models;
using eShop.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.ProizvodiStateMachine
{
    public class ActiveProductState : BaseState
    {
        public ActiveProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }
        public override async Task<Proizvod> Hide(int id)
        {
            var entity = await _context.Set<Proizvodi>().FindAsync(id);
            entity.StateMachine = "draft";
            await _context.SaveChangesAsync();
            return _mapper.Map<Proizvod>(entity);
        }
        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Hide");
            return list;
        }
    }
}
