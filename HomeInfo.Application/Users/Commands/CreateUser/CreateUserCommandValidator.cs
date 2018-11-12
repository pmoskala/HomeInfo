using FluentValidation;

namespace HomeInfo.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Surname).MinimumLength(2).NotEmpty();
            RuleFor(x => x.UserName).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(5).NotEmpty().EmailAddress();
        }
    }
}
