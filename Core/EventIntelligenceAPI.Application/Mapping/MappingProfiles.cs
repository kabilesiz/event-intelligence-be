using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces;
using EventIntelligenceAPI.Domain.Entities;

namespace EventIntelligenceAPI.Application.Mapping;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        ConfigureMappings();
    }
    private void ConfigureMappings()
    {
        CreateMap<Role, CreateRoleCommand>().ReverseMap();
        CreateMap<Role,RoleDto>().ReverseMap();
        CreateMap<IPaginate<Role>,RoleListDto>().ReverseMap();
        
        CreateMap<Message, CreateMessageCommand>().ReverseMap();
        CreateMap<Message,MessageDto>().ReverseMap();
        CreateMap<IPaginate<Message>,MessageListDto>().ReverseMap();
        
        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event,EventDto>().ReverseMap();
        CreateMap<IPaginate<Event>,EventListDto>().ReverseMap();
        
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<IPaginate<User>,UserListDto>().ReverseMap();
        
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Comment,CommentDto>().ReverseMap();
        CreateMap<IPaginate<Comment>,CommentListDto>().ReverseMap();
        
        CreateMap<EventUser, CreateEventUserCommand>().ReverseMap();
        CreateMap<EventUser,EventUserDto>().ReverseMap();
        CreateMap<IPaginate<EventUser>,EventUserListDto>().ReverseMap();
    }
}