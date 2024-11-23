using MongoDB.Entities;
using SocialNetwork.Application.BCryptServices;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.Common.Mappers;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.RegularServices;

public class AuthenticationService
{
    private readonly IPasswordVerificationService _passwordVerificationService;
    
    public AuthenticationService(IPasswordVerificationService passwordVerificationService)
    {
        _passwordVerificationService = passwordVerificationService;
    }
    public async Task<UserDetailsDto?> Authenticate(string email, string password)
    {
        var user = await DB.Find<User>().Match(u => u.Email == email).ExecuteFirstAsync();
            
        if (user != null && _passwordVerificationService.VerifyPassword(user.Password, password))
        {
            return user.ToDetailsDto();
        }

        return null;
    }
}