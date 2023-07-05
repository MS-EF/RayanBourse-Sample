using API.Helper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtService _jwtService;

        public UserController(UserManager<AppUser> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpGet("Login/{id}")]
        public async Task<IActionResult> Login(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null) return Unauthorized();

            return Ok(_jwtService.GenerateJwtToken(user));
        }

    }
}
