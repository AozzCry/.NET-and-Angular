using CompaniesAndEmployees.dotnet_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesAndEmployees.dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }


    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginVm loginUser)
    {
        if (loginUser is null)
        {
            return BadRequest("Invalid client request");
        }

        User? user = _userService.IsExist(loginUser).Result;

        var role = await _userService.GetRole(loginUser);

        if (user is not null && loginUser.Email is not null && role is not null)
        {
            string tokenString = _authService.GenerateToken(loginUser.Email, role);

            return Ok(new LoginResponse { Token = tokenString, FirstName = user.FirstName, LastName = user.LastName, UserId = user.Id, Email = user.Email });
        }
        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult> Registration([FromBody] UserRegistrationVm registrationUser)
    {
        if (string.IsNullOrWhiteSpace(registrationUser.Email) ||
            string.IsNullOrWhiteSpace(registrationUser.Password) ||
            string.IsNullOrWhiteSpace(registrationUser.FirstName) ||
            string.IsNullOrWhiteSpace(registrationUser.LastName))
        {
            return BadRequest("One or more fields are empty");
        }

        bool IsExist = await _userService.IfEmailExists(registrationUser.Email);

        if (IsExist)
            return BadRequest("User with that email is exist");

        await _userService.Create(registrationUser);

        return Ok();
    }
}
