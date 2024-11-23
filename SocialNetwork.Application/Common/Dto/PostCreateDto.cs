using MongoDB.Entities;

namespace SocialNetwork.Application.Common.Dto;

public record PostCreateDto(string? Content, DateTime DateCreated, DateTime LastModified, string UserId);