using Microsoft.EntityFrameworkCore;
using RestfulApisWithRepositoryDesignPattern.Models;
using RestfulApisWithRepositoryDesignPattern.Models.DataManagers;
using RestfulApisWithRepositoryDesignPattern.Models.Entities;
using RestfulApisWithRepositoryDesignPattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Resgiter DbContext
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"))
    );

//Register DataManagers
builder.Services.AddScoped<IDataRepository<User>,UserDataManager>();

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
