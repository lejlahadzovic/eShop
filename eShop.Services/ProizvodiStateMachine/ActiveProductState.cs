using AutoMapper;
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
    }
}
