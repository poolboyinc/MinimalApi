using FluentValidation;
using SocialNetwork.Application.Common.Dto;

namespace SocialNetwork.Application.Validators;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor( x => x.Name).NotEmpty().MaximumLength(30);

        RuleFor(x => x.Age).NotEmpty().GreaterThan(13);

        RuleFor(x => x.Password).NotEmpty().MaximumLength(21).MinimumLength(7).WithMessage("Password doesn't fit criteria.");

        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email address is not valid.");
    }
}