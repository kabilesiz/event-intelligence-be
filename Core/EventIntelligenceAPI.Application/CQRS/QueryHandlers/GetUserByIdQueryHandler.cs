using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserDto>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUserListQueryHandler> _logger;

    public GetUserByIdQueryHandler(IGenericRepository<User> userRepository, IMapper mapper, ILogger<GetUserListQueryHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(u => u.Id == request.Id);
        var toReturn = _mapper.Map<UserDto>(user);
        return toReturn;
    }
}