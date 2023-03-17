using Application.Interfaces;
using Contracts;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IIdentityService identityService,
            UserManager<ApplicationUser> userManager)
        {
            _identityService = identityService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _userManager.Users.ToListAsync(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            return Ok(await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userName, string address, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(userName, address);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == result.UserId, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = result.UserId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string userId)
        {
            await _identityService.DeleteUserAsync(userId);

            return NoContent();
        }
    }
}
