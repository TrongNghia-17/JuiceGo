using JuiceGo.Application.Extensions;
using JuiceGo.Infrastructure.Extensions;
using JuiceGo.Infrastructure.Seeders;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IJuiceGoSeeder>();
    await seeder.Seed();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
