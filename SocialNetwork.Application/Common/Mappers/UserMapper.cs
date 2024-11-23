using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.EntityServices;

namespace SocialNetwork.Application.Common.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial User ToEntity(this UserCreateDto dto);

    public static partial User ToUpdateEntity(this UserUpdateDto dto);
    public static partial UserDetailsDto ToDetailsDto(this User entity);
}