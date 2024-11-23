using SocialNetwork.Application.BCryptServices;
using SocialNetwork.Application.BCryptServices;

namespace SocialNetwork.Infrastructure.HashService;

public class BCryptPasswordVerificationService : IPasswordVerificationService
{
    public bool VerifyPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}