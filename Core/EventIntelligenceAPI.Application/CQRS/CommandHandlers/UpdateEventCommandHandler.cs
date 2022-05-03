using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eEvent = await _eventRepository.GetAsync(x => x.Id == request.Id);
        if (eEvent != null)
        {
            eEvent.Body = request.Body;
            eEvent.Name = request.Name;
            eEvent.Title = request.Title;
            eEvent.EndDate = request.EndDate;
            eEvent.StartDate = request.StartDate;
            await _eventRepository.UpdateAsync(eEvent);
            return Unit.Value;
        }

        throw new Exception();
    }
}