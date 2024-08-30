using DevApi.Configuration;
using DevBusiness.Interfaces;
using DevBusiness.Notificacoes;
using DevBusiness.Services;
using DevData.Context;
using DevData.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder
    .AddApiConfig()
    .AddSwaggerConfig()
    .ResolveDependencies()
    .AddDbContextConfig()
    .AddCorsConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
