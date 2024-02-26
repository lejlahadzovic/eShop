using eShop.Models;
using eShop.Models.Request;
using eShop.Models.SearchObjects;
using eShop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services
{
    public interface IProizodiService:ICRUDService<Models.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        Task<Proizvod> Activate(int id);
        Task<Proizvod> Hide(int id);
        Task<List<string>> AllowedActions(int id);
    }
}
