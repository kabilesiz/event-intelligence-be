using AutoMapper;
using EventIntelligenceAPI.Application.CQRS.Commands;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities;
using MediatR;

namespace EventIntelligenceAPI.Application.CQRS.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IGenericRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Id == request.Id);
        if (user != null)
        { 
            user.Address = request.Address;
            user.Department = request.Department;
            user.Email = request.Email;
            user.Name = request.Name;
            user.Password = request.Password;
            user.Surname = request.Surname;
            user.Age = request.Age;
            user.RoleId = request.RoleId;
            user.Age = request.Age;
            user.UpdatedDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }

        throw new Exception();
    }
}