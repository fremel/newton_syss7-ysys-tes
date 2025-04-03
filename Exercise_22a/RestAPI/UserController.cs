using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

public class UserController : ControllerBase
{
    private static Dictionary<string, User> users = new Dictionary<string, User>();
    private static int failedLoginAttempts = 0;
    private static DateTime lastFailedLoginTime = DateTime.MinValue;

    [HttpPost("/api/users/register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (users.ContainsKey(request.Username))
        {
            return Conflict("Username already exists.");
        }
        if (request.Password.Length <= 8)
        {
            return UnprocessableEntity("Password too short.");
        }
        string lettersAndNumbersPattern = @"^(?=.*[a-zA-Z]).*$";
        if (!Regex.IsMatch(request.Password, lettersAndNumbersPattern))
        {
            return UnprocessableEntity("Password needs to contain both letters and numbers.");
        }

        var newUser = new User(request.Username, request.Email, request.Password);
        users[newUser.Username] = newUser;
        return Ok("User registered successfully.");
    }

    [HttpPost("/api/users/login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (!users.ContainsKey(request.Username))
        {
            return Unauthorized("Invalid username or password.");
        }
        if (failedLoginAttempts >= 3)
        {
            TimeSpan lockoutDuration = DateTime.Now - lastFailedLoginTime;
            if (lockoutDuration.TotalSeconds < 10)
            {
                return Unauthorized("Account is temporarily locked!");
            }
        }

        if (users[request.Username].Password != request.Password)
        {
            failedLoginAttempts++;
            lastFailedLoginTime = DateTime.Now;
            return Unauthorized("Invalid username or password.");
        }

        // Reset failedLoginAttempts
        failedLoginAttempts = 0;
        lastFailedLoginTime = DateTime.MinValue;

        // Generate and return JWT token
        var token = TokenProvider.GenerateToken(request.Username);
        return Ok(new { Token = token });
    }

    [HttpGet("/api/users/profile")]
    public IActionResult GetProfile()
    {
        var username = GetUsernameFromToken(Request.Headers["Authorization"]);
        if (string.IsNullOrEmpty(username))
        {
            return Unauthorized("Invalid or missing authorization token.");
        }

        if (!users.ContainsKey(username))
        {
            return NotFound("User not found.");
        }

        var user = users[username];
        return Ok(new { Username = user.Username, Email = user.Email });
    }

    [HttpPut("/api/users/update-email")]
    public IActionResult UpdateEmail([FromBody] UpdateEmailRequest request)
    {
        var username = GetUsernameFromToken(Request.Headers["Authorization"]);
        if (string.IsNullOrEmpty(username))
        {
            return Unauthorized("Invalid or missing authorization token.");
        }

        if (!users.ContainsKey(username))
        {
            return NotFound("User not found.");
        }

        users[username].Email = request.NewEmail;
        return Ok("Email updated successfully.");
    }

    [HttpDelete("/api/users/delete-account")]
    public IActionResult DeleteAccount()
    {
        var username = GetUsernameFromToken(Request.Headers["Authorization"]);
        if (string.IsNullOrEmpty(username))
        {
            return Unauthorized("Invalid or missing authorization token.");
        }

        if (!users.ContainsKey(username))
        {
            return NotFound("User not found.");
        }

        users.Remove(username);
        return Ok("Account deleted successfully.");
    }

    private string GetUsernameFromToken(string token)
    {
        Console.WriteLine($"Received Authorization token {token}");
        if (string.IsNullOrEmpty(token))
        {
            return null;
        }

        // Parse and validate JWT token
        return TokenProvider.ValidateToken(token);
    }
}