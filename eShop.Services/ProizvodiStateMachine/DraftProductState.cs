using AutoMapper;
using Azure.Core;
using EasyNetQ;
using eShop.Models;
using eShop.Models.Request;
using eShop.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
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
        protected ILogger _logger;
        public DraftProductState(ILogger<DraftProductState> logger,IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }
        public override async Task<Proizvod> Update(int id, ProizvodUpdateRequest request)
        {
            var entity = await _context.Set<Proizvodi>().FindAsync(id);
            _mapper.Map(request, entity);
            if (entity.Cijena < 0)
            {
                throw new Exception("Server side error");
            }
            if (entity.Cijena<1)
            {
                throw new UserException("Cijena ispod minimuma");
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Proizvod>(entity);
        }
        public override async Task<Proizvod> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");
            _logger.LogWarning($"W :Aktivacija proizvoda: {id}");
            _logger.LogError($"E :Aktivacija proizvoda: {id}");
            var entity = await _context.Set<Proizvodi>().FindAsync(id);
            entity.StateMachine = "active";
            await _context.SaveChangesAsync();

            //var factory = new ConnectionFactory { HostName = "localhost" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();

            //string message = "";

            ////JSON$"{entity.ProizvodId}, {entity.Sifra}, {entity.Naziv}";
            //var body = Encoding.UTF8.GetBytes(message);

            //channel.BasicPublish(exchange: string.Empty,
            //                     routingKey: "product_added",
            //                     basicProperties: null,
            //                     body: body);
            //return _mapper.Map<Proizvod>(entity);

            var mappedEntity = _mapper.Map<Proizvod>(entity);

            using var bus = RabbitHutch.CreateBus("host=localhost");

            bus.PubSub.Publish(mappedEntity);

            return mappedEntity;

        }
        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();
            list.Add("Update");
            list.Add("Activate");
            return list;
        }
    }
}
