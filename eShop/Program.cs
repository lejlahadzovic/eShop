using eShop.Models;
using eShop.Models.SearchObjects;
using eShop.Services;
using eShop.Services.Database;
using eShop.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProizodiService, ProizvodiService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IJediniceMjereService, JediniceMjereService>();
builder.Services.AddTransient<IService<VrsteProizvoda, BaseSearchObject>,BaseService<VrsteProizvoda,VrsteProizvodum, BaseSearchObject>>();
builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<InitialProductState>();
builder.Services.AddTransient<DraftProductState>();
builder.Services.AddTransient<ActiveProductState>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EProdajaContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(IKorisniciService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
