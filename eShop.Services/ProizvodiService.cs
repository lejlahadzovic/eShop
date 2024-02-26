using AutoMapper;
using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services.Database;
using eShop.Services.ProizvodiStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eShop.Services
{
    public class ProizvodiService : BaseCRUDService<Models.Proizvod, Database.Proizvodi, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>, IProizodiService
    {
        public BaseState _baseState { get; set; }
        public ProizvodiService(BaseState baseState, EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
            _baseState = baseState;
        }
        public override Task<Proizvod> Insert(ProizvodInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");
            return state.Insert(insert);
        }
        public override async Task<Proizvod> Update(int id, ProizvodUpdateRequest update)
        {
            var entity = await _context.Proizvodis.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Update(id, update);
        }
        public async Task<Proizvod> Activate(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Activate(id);
        }
        public async Task<Proizvod> Hide(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Hide(id);
        }
        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine);
            return await state.AllowedActions();
        }
    }
}
