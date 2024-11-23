using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;

namespace SocialNetwork.Application.Users.Commands;

public record UserUpdateCommand(UserUpdateDto User) : IRequest<UserDetailsDto>;

public class ProductUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserDetailsDto>
{
    public async Task<UserDetailsDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = request.User.ToUpdateEntity();
        await entity.SaveAsync(cancellation: cancellationToken);
        return entity.ToDetailsDto();
    }
}