namespace SocialNetwork.Application.Common.Dto;

public record PostDetailsDto(string? Content, DateTime DateCreated, DateTime LastModified, string UserFirstName);