using SocialNetwork.Domain.BCryptService;

namespace SocialNetwork.Infrastructure.HashService;

public class BcryptPasswordHashService : IPasswordHashService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}