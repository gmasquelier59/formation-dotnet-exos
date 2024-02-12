using Exercice04_ContactsAPI.Data;
using Exercice04_ContactsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Exercice04-ContactsAPI.xml");
    c.IncludeXmlComments(filePath);

    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ASP.Net Core API - Exercice 4",
            Version = "v1",
            Description = "Gestion simple de contacts",
            Contact = new OpenApiContact
            {
                Name = "Guillausaure",
                Email = "guillausaure@jurassic-park.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
            }
        }
    );
});

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
