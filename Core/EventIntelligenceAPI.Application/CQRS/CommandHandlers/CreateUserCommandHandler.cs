using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IGenericRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var mappedUser = _mapper.Map<User>(request);
        await _userRepository.AddAsync(mappedUser);
        return Unit.Value;
    }
}