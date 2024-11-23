using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Common.Dto;
using SocialNetwork.Application.RegularServices;

namespace SocialNetwork.Application.Users.Commands;

public record LoginCommand(LoginDto Dto) : IRequest<UserDetailsDto?>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDetailsDto?>
{
    private readonly AuthenticationService _authenticationService;

    public LoginCommandHandler(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<UserDetailsDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.Authenticate(request.Dto.Email, request.Dto.Password);
    }

}

