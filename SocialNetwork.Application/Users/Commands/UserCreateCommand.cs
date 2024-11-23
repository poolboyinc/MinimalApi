using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.EntityServices;

namespace SocialNetwork.Application.Users.Commands;

public record UserCreateCommand(UserCreateDto User) : IRequest<UserDetailsDto?>;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserDetailsDto?>
{
    private readonly UserService _userService;

    public UserCreateCommandHandler(UserService userService)
    {
        _userService = userService;
    }

    public async Task<UserDetailsDto?> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        string hashedPassword = _userService.HashPassword(request.User.Password);
        
        var entity = request.User.ToEntity();
        entity.Password = hashedPassword; 
        await entity.SaveAsync(cancellation: cancellationToken);
        
        return entity?.ToDetailsDto();
    }
}