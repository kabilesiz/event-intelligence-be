using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class AssignUserToEventCommandHandler : IRequestHandler<AssignUserToEventCommand>
{
    private readonly IGenericRepository<EventUser> _eventUserRepository;
    private readonly IMapper _mapper;

    public AssignUserToEventCommandHandler(IGenericRepository<EventUser> eventUserRepository, IMapper mapper)
    {
        _eventUserRepository = eventUserRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AssignUserToEventCommand request, CancellationToken cancellationToken)
    {
        foreach (var userDto in request.AssignedUserList)
        {
            var checkedUser = _eventUserRepository
                .Query()
                .SingleOrDefault(x => x.EventId == userDto.EventId && x.UserId == userDto.UserId);
            if (userDto.IsExist)
            {
                if (checkedUser == null)
                {
                    EventUser eventUser = new()
                    {
                        EventId = userDto.EventId,
                        UserId = userDto.UserId
                    };
                    await _eventUserRepository.AddAsync(eventUser);
                }
            }
            else
            {
                if (checkedUser != null)
                {
                    await _eventUserRepository.DeleteAsync(checkedUser);
                }
            }
        } 
        return Unit.Value;
    }
}