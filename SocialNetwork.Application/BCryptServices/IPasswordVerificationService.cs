namespace SocialNetwork.Application.BCryptServices;


public interface IPasswordVerificationService 
{ 
    bool VerifyPassword(string hashedPassword, string password);
}

