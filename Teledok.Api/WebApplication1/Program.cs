using Microsoft.EntityFrameworkCore;
using teledok.Teledoc.Application.Services;
using teledok.Teledok.Application.Services;
using teledok.Teledok.DataBase;
using teledok.Teledok.DataBase.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TeledokDBcontext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TeledokDBcontext)));
    });

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IFounderService, FounderService>();
builder.Services.AddScoped<IFounderRepository, FounderRepository>();

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
