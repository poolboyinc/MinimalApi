using Amazon.Runtime.Internal;
using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Users.Queries;

public record UserPostsDetails(string Email) : IRequest<List<PostDetailsDto?>>;

public class UserPostsQueryHandler : IRequestHandler<UserPostsDetails, List<PostDetailsDto>>
{
    public async Task<List<PostDetailsDto>> Handle(UserPostsDetails request, CancellationToken cancellationToken)
    {
        List<Post> posts = await DB.Find<Post>().Match(p => p.UserEmbeded.Email == request.Email).ExecuteAsync();

        if (posts != null)
        {
            var postDetailsDtos = new List<PostDetailsDto>();
            foreach (var post in posts)
            {
                var postDto = await post.ToPostDetailsDto();
                postDetailsDtos.Add(postDto);
            }
            return postDetailsDtos;
        }

        return null;
    }
}
