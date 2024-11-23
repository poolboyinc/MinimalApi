using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Users.Queries;

public record UsersAllDetailsQuery() : IRequest<List<UserDetailsDto?>>;

public class UsersAllDetailsQueryHandler : IRequestHandler<UsersAllDetailsQuery, List<UserDetailsDto>>
{
    public async Task<List<UserDetailsDto>> Handle(UsersAllDetailsQuery request, CancellationToken cancellationToken)
    {
        List<User> users = await DB.Find<User>().ExecuteAsync();
        
        if (users != null)
        {
            var userDetailsDtos = new List<UserDetailsDto>();
            foreach (var user in users)
            {
                var userDto = user.ToDetailsDto();
                userDetailsDtos.Add(userDto);
            }
            return userDetailsDtos;
        }

        return null;
    }
}
