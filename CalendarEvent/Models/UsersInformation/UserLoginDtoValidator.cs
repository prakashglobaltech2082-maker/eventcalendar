using FluentValidation;

namespace CalendarEvent.Models.UsersInformation
{
    public class UserLoginDtoValidator:AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required")
                 .MinimumLength(3).WithMessage("Name should be minimum 3 length long")
                 .MaximumLength(50).WithMessage("Name should be maximum 50 length long");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password should be  minimum 8 length long");
        }
    }
}
