namespace SocialNetwork.Domain.BCryptService;

public interface IPasswordHashService
{
    string HashPassword(string password);
}