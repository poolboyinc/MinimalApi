using FluentValidation;
using SocialNetwork.Application.Common.Dto;

namespace SocialNetwork.Application.Validators;

public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
    public PostCreateDtoValidator()
    {
        RuleFor(x => x.Content).NotEmpty().MinimumLength(10);

        RuleFor(x => x.DateCreated).NotEmpty();
        
    }
}