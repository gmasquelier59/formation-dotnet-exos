using ContactApiDTO.Data;
using ContactApiDTO.Models;
using ContactApiDTO.Repositories;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var conn = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(conn));

builder.Services.AddScoped<IRepository<Contact>, ContactRepositoryFakeDb>();

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
