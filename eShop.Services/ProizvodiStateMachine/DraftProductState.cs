using AutoMapper;
using Azure.Core;
using eShop.Models;
using eShop.Models.Request;
using eShop.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eShop.Services.ProizvodiStateMachine
{
    public class DraftProductState : BaseState
    {
        public DraftProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }
        public override async Task<Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            var entity = await _context.Set<Proizvodi>().FindAsync(id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Proizvod>(entity);
        }
        public override async Task<Proizvod> Activate(int id)
        {
            var entity = await _context.Set<Proizvodi>().FindAsync(id);
            entity.StateMachine = "active";
            await _context.SaveChangesAsync();
            return _mapper.Map<Proizvod>(entity);
        }
    }
}
