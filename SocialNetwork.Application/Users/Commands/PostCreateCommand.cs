using MediatR;
using MongoDB.Entities;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Users.Commands;

public record PostCreateCommand(PostCreateDto Post) : IRequest<PostDetailsDto?>;

public class PostCreateCommandHandler : IRequestHandler<PostCreateCommand, PostDetailsDto?>
{
    public async Task<PostDetailsDto?> Handle(PostCreateCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await DB.Find<User>().OneAsync(request.Post.UserId);

        if( userEntity != null)
        {
            var entity = request.Post.ToPostEntity();
            entity.UserEmbeded = userEntity;
            await entity.SaveAsync(cancellation: cancellationToken);
            return await entity?.ToPostDetailsDto();
        }

        return null;
    }
}