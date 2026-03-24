using Home_Central.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Home_Central.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HomeCentral.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeCentral.Controllers.api;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private ApplicationDbContext context;
    private IConfiguration configuration;

    public UsersController(ApplicationDbContext context,IConfiguration configuration)
    {
        this.context = context;
        this.configuration = configuration;
    }
    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<IdentityUser> Get()
    {
        return this.context.Users.ToList<IdentityUser>();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public IdentityUser? Get(int id)
    {
        return this.context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();  
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] IdentityUser value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] IdentityUser value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest model)
    {
        // Implement your login logic here
        // Validate the user's credentials and generate a token if valid
        var user = context.Users.FirstOrDefault(u => u.Email == model.Username);
        if(user == null || !new PasswordHasher<IdentityUser>().VerifyHashedPassword(user, user.PasswordHash, model.Password).Equals(PasswordVerificationResult.Success))
        {
                return Unauthorized();
        }
        //var tokenHandler = new JwtSecurityTokenHandler();
        //var test = new LoginModel
        {
              
        }
        var token = GenerateJwtToken(user);
        return Ok(new { Token = token});
    }
    private string GenerateJwtToken(IdentityUser user)
    {        
        var secretKey = configuration["Jwt:SecretKey"];
        var key = System.Text.Encoding.ASCII.GetBytes(secretKey);
        var tokenHandler = new JwtSecurityTokenHandler();        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}