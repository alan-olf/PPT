using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PPT.App.Core.ApiModels.User;
using PPT.App.Core.GuardClause;
using PPT.App.Core.Services;
using PPT.App.Core.Services.Interface;

namespace PPT.App.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger) 
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Route("", Name = nameof(GetUserAvatar))]
        [Produces("application/json")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<UserInfoApiResponse>> GetUserAvatar(string userIdentifier)
        {
            Guard.Against.NullOrEmpty(userIdentifier, "userIdentifier is not available !");

            _logger.LogInformation("get user avatar #{userIdentifier} ", userIdentifier);

            var result = await _userService.GetUserAvatarAsync(userIdentifier);
            if(result == null)
                return BadRequest("Failed to Get user Avatar.");

            return Ok(new UserInfoApiResponse { url = result});

        } 

    }
}
