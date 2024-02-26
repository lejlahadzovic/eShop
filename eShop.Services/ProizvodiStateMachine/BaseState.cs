using AutoMapper;
using eShop.Models;
using eShop.Models.Request;
using eShop.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.ProizvodiStateMachine
{
    public class BaseState
    {
        protected EProdajaContext _context;
        public IMapper _mapper { get; set; }
        protected IServiceProvider _serviceProvider { get; set; }
        public BaseState(IServiceProvider serviceProvider,EProdajaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public virtual Task<Models.Proizvod> Insert(ProizvodInsertRequest request)
        {
            throw new UserException("Not allowed!");
        }
        public virtual Task<Models.Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            throw new UserException("Not allowed!");
        }
        public virtual Task<Models.Proizvod> Activate(int id)
        {
            throw new UserException("Not allowed!");
        }
        public virtual Task<Models.Proizvod> Hide(int id)
        {
            throw new UserException("Not allowed!");
        }
        public virtual Task<Models.Proizvod> Delete(int id)
        {
            throw new UserException("Not allowed!");
        }
        public BaseState CreateState(string stateName) 
        { 
            switch(stateName)
            {
                case "initial":
                case null:
                    return _serviceProvider.GetService<InitialProductState>();
                    break;
                case "draft":
                    return _serviceProvider.GetService<DraftProductState>();
                    break;
                case "active":
                    return _serviceProvider.GetService<ActiveProductState>();
                    break;
                default:
                    throw new Exception("Not allowed");
            }
        }
        public virtual async Task<List<string>> AllowedActions()
        {
            return new List<string>();
        }
    }
}
