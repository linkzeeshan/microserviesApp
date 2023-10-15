using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Repositories;
using PlatformService.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Add SQL DB
builder.Services.AddDbContext<AppDbContext>(opt =>
 opt.UseInMemoryDatabase("Inmem")) ;

//dependacny injection
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
PrepDb.PrepPopulation(app);
app.Run();
