using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetAssignedUserOfEventQueryHandler : IRequestHandler<GetAssignedUsersOfEventQuery, List<AssignedUserDto>>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public GetAssignedUserOfEventQueryHandler(IGenericRepository<User> userRepository, IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }

    public async Task<List<AssignedUserDto>> Handle(GetAssignedUsersOfEventQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository
            .Query()
            .Join(_eventUserRepository.Query(), user => user.Id, eventUser => eventUser.UserId, (user, eventUser) => new
            {
                user,
                eventUser
            })
            .Where(x => x.eventUser.EventId == request.EventId)
            .Select(x => new User()
            {
                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Email = x.user.Email,
            })
            .ToList();
        var toReturn = new List<AssignedUserDto>();
        foreach (var user in users)
        {
            AssignedUserDto assignedUserDto = new();
            assignedUserDto.Email = user.Email;
            assignedUserDto.Name = user.Name;
            assignedUserDto.Surname = user.Surname;
            assignedUserDto.EventId = request.EventId;
            assignedUserDto.UserId = user.Id;
            assignedUserDto.IsExist = true;
            toReturn.Add(assignedUserDto);
        }
        return toReturn;
    }
}