using FluentValidation;

namespace CalendarEvent.Models.UsersInformation
{
    public class UserRegisterDtoValidator:AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name should be minimum 3 length long")
                .MaximumLength(50).WithMessage("Name should be maximum 50 length long");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must contain at least 8 characters, including uppercase, lowercase, number, and special character.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x=>x.Password).WithMessage("Confirm Password should match with password");
                
        }
    }
}
