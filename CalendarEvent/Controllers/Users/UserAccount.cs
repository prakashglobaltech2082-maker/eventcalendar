using BCrypt.Net;
using CalendarEvent.Common;
using CalendarEvent.DBHelper;
using CalendarEvent.Models.UsersInformation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvent.Controllers.Users
{
    [Route("api/UserAccount")]
    [ApiController]
    public class UserAccount : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<UserRegisterDto> _userRegistervalidator;
        private readonly IValidator<UserLoginDto> _userLoginvalidator;

        public UserAccount(ApplicationDbContext context, IValidator<UserRegisterDto> userRegistervalidator,
                           IValidator<UserLoginDto> userLoginvalidator)
        {
            _context = context;
            _userRegistervalidator = userRegistervalidator;
            _userLoginvalidator = userLoginvalidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUpUser([FromBody] UserRegisterDto userRegisterdto)
        {
            try
            {
                ValidationResult validationResult = await _userRegistervalidator.ValidateAsync(userRegisterdto);

                if (!validationResult.IsValid)
                    return Ok(ResponseHandler.GetValidationErrorResponse(validationResult));

                var getName = await _context.Users.AnyAsync(x=>x.Name.ToLower()==userRegisterdto.Name.ToLower());

                if (getName)
                {
                    return Ok(ResponseHandler.GetBadRequestResponse("Name is already taken. try another"));
                }

                var hashPassword =
                    BCrypt.Net.BCrypt.HashPassword(userRegisterdto.Password);

                var usersinfo = new UsersRegister
                {
                    Name = userRegisterdto.Name,
                    Password = hashPassword,
                    CreatedDate = DateTimeOffset.Now,
                };

                //await _context.AddAsync(usersinfo);
                await _context.Users.AddAsync(usersinfo);   
                await _context.SaveChangesAsync();

                return Ok(ResponseHandler.GetSuccessResponse(userRegisterdto, "Save Success"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto loginDto)
        {
            ValidationResult validationResult = _userLoginvalidator.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                return Ok(ResponseHandler.GetValidationErrorResponse(validationResult));
            }
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Name==loginDto.Name);

            if(getUser == null)
            {
                return Ok(ResponseHandler.GetNotFoundResponse($"User Not found with Id {loginDto.Name}"));
            }
            bool hashPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, getUser.Password);
            if (!hashPassword)
            {
                return Ok(ResponseHandler.GetUnAuthorizeResponse("Invalid password"));
            }
            return Ok(ResponseHandler.GetSuccessResponse(loginDto.Name,"Login success"));
        }
    }
}
