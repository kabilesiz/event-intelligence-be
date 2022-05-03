using System.Reflection;
using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Mapping;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventIntelligenceAPI.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfiles());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
        services.AddMediatR(typeof(GetRoleListQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(GetRoleByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateRoleCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateRoleCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteRoleCommand).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(GetMessageListQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(GetMessageByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateMessageCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateMessageCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteMessageCommand).GetTypeInfo().Assembly);
        
        services.AddMediatR(typeof(GetEventListQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(GetEventByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateEventCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateEventCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteEventCommand).GetTypeInfo().Assembly);
        
        services.AddMediatR(typeof(GetUserListQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(GetUserByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateUserCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteUserCommand).GetTypeInfo().Assembly);
        
        return services;
    }
}