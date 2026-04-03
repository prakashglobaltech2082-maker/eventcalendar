using FluentValidation.Results;

namespace CalendarEvent.Models.UsersInformation
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        private UserRegisterDtoValidator _validator=new UserRegisterDtoValidator();

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }
    }
}
