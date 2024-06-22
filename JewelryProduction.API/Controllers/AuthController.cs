using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Service.Account;
using JewelryProduction.Service.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly JwtService _jwtService;

        public AuthController(IAccountService accountService, JwtService jwtService)
        {
            _accountService = accountService;
            _jwtService = jwtService;
        }

        [HttpGet("/api/v1/auth")]
        public IActionResult Hello() {
            return Ok("Success");
        }

        [HttpPost("/api/v1/register")]
        public IActionResult Register(CreateUserRequest createUserRequest)
        {
            var user = new CreateUserRequest
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createUserRequest.Password),
                Role = createUserRequest.Role,
                Income = createUserRequest.Income,
                CreateBy = createUserRequest.CreateBy,
                CreatedDate = createUserRequest.CreatedDate,
                UpdateBy = createUserRequest.UpdateBy,
                UpdatedDate = createUserRequest.UpdatedDate
            };

            return Created("Success", _accountService.Create(user));
        }

        [HttpPost("/api/v1/login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _accountService.GetByEmail(request.Email);

            if(user == null)
            {
                return BadRequest(new {message = "Invalid credentials" });
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });

            return Ok(new {message = "success"});
        }

        [HttpGet("/api/v1/get-logged-user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                Guid id = Guid.Parse(token.Issuer);

                var user = _accountService.GetById(id);

                return Ok(user);
            } catch (Exception ex)
            {
                return Unauthorized();
            }

        }

        [HttpPost("/api/v1/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "success" });
        }


    }
}