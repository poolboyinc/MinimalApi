using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Users.Queries;

public record UserDetailsQuery(string Id) : IRequest<UserDetailsDto?>;

public class UserCreateCommandHandler : IRequestHandler<UserDetailsQuery, UserDetailsDto?>
{
    public async Task<UserDetailsDto?> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await DB.Find<User>().OneAsync(request.Id, cancellationToken);
        
        if (entity != null)
        {
            return entity.ToDetailsDto();
        }

        return null;
    }
}
