using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.BL.Dtos.Auth;
using ShoppingCart.DAL.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    public UsersController(IConfiguration configuration,
    UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }
    #region Login
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto login)
    {
        var user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }
        bool isAuthend = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!isAuthend) { return Unauthorized("Invalid username or password."); }

        var userClaims = await _userManager.GetClaimsAsync(user);

        return GenerateToken(userClaims);

    }

    #endregion

    #region register
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register(RegisterDto register)
    {
        var existingUser = await _userManager.FindByNameAsync(register.UserName);
        if (existingUser != null)
            return BadRequest("Username already exists.");
        var employee = new User
        {
            UserName = register.UserName,
            Email = register.Email,
            type = register.type,
        };
        var result = await _userManager.CreateAsync(employee, register.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new (ClaimTypes.Name, employee.UserName),
            new (ClaimTypes.Email, employee.Email),
            new ("type", register.type),
        };
        await _userManager.AddClaimsAsync(employee, claims);

        return Ok("User created successfully.");
    }

    #endregion
    private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
    {
        var keyFromConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        var signingCredentials = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256Signature);

        var expiryDateTime = DateTime.Now.AddMinutes(10);

        var jwt = new JwtSecurityToken(
            claims: userClaims,
            expires: expiryDateTime,
            signingCredentials: signingCredentials);

        var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new TokenDto(jwtAsString, expiryDateTime);
    }

}
