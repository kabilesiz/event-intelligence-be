using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.CQRS.QueryHandlers;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUserListQueryHandler> _logger;

    public DeleteUserCommandHandler(IGenericRepository<User> userRepository, IMapper mapper, ILogger<GetUserListQueryHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(u => u.Id == request.Id);
        if (user != null)
        {
            var deletedUser = await _userRepository.DeleteAsync(user);
            var result = _mapper.Map<UserDto>(deletedUser);
            return result;
        }

        throw new Exception();
    }
}