using SocialNetwork.Domain.BCryptService;

namespace SocialNetwork.Domain.EntityServices;

public class UserService
{
    private readonly IPasswordHashService _passwordHashService;

    public UserService(IPasswordHashService passwordHashService)
    {
        _passwordHashService = passwordHashService;
    }
    
    public string HashPassword(string password)
    {
        return _passwordHashService.HashPassword(password);
    }
}