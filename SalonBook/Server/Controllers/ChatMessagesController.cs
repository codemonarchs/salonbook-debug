using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalonBook.Server.Data.Users.Entities;
using SalonBook.Shared;
using System.Security.Claims;

namespace SalonBook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatMessagesController : ControllerBase
    {

        private readonly ILogger<ChatMessagesController> _logger;
        private readonly UserManager<User> _userManager;

        public ChatMessagesController(ILogger<ChatMessagesController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetMessages()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
        }
    }
}