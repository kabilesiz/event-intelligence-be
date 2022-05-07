using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Queries;
using EventIntelligenceAPI.Application.Dtos;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventIntelligenceAPI.Application.CQRS.QueryHandlers;

public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, UserDto>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public CheckUserQueryHandler(IGenericRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(CheckUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .Query()
            .Where(x => string.Equals(x.Email, request.Email)
                        && string.Equals(x.Password, request.Password))
            .Include(x => x.Role).AsNoTracking().FirstOrDefaultAsync();
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}