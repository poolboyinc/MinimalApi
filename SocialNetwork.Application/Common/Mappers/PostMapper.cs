using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Common.Mappers;

[Mapper]
public static partial class PostMapper
{
    public static Post ToPostEntity(this PostCreateDto dto)
    {
        var entity = new Post
        {
            Content = dto.Content,
            DateCreated = dto.DateCreated,
            LastModified = dto.LastModified,
            Owner = new One<User>(dto.UserId)
        };
        return entity;
    }

    public static async Task<PostDetailsDto> ToPostDetailsDto(this Post entity)
    {
        var user = await entity.Owner.ToEntityAsync();
        var dto = new PostDetailsDto(entity.Content, entity.DateCreated, entity.LastModified, user.Name);
        return dto;
    }
}