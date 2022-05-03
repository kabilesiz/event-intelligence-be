using System.Reflection;
using AutoMapper;
using EventIntelligenceAPI.Application;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Application.Mapping;
using EventIntelligenceAPI.Domain.Entities;
using EventIntelligenceAPI.Persistence;
using EventIntelligenceAPI.Persistence.Contexts;
using EventIntelligenceAPI.Persistence.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

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