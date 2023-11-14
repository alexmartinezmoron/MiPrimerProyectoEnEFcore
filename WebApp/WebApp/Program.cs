using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);  // utilizamos para ignorar las relaciones circulares
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion con la bbdd
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

// Automapper
builder.Services.AddAutoMapper(typeof(Program));


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
