using AutoMapper;
using eShop.Models.SearchObjects;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        public BaseCRUDService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public virtual async Task BeforeInsert(TDb db, TInsert insert)
        {
        }
        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _context.Set<TDb>(); 
            TDb entity= _mapper.Map<TDb>(insert);
            set.Add(entity);
            await BeforeInsert(entity, insert);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
        public virtual async Task<T> Update(int id, TUpdate update)
        {
            var entity =await _context.Set<TDb>().FindAsync(id);
            _mapper.Map(update,entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
    }
}
