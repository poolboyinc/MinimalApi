using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Users.Queries;

public record PostDetailsQuery(string Id) : IRequest<PostDetailsDto?>;

public class PostCreateCommandHandler : IRequestHandler<PostDetailsQuery, PostDetailsDto?>
{
    public async Task<PostDetailsDto?> Handle(PostDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await DB.Find<Post>().OneAsync(request.Id, cancellationToken);
        
        if (entity != null)
        {
            return await entity.ToPostDetailsDto();
        }

        return null;
    }
}