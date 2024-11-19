using Microsoft.Extensions.Logging;
using Moq;
using PPT.App.Core.Data.Entities;
using PPT.App.Core.Data.Store;
using PPT.App.Core.Services;
using PPT.App.Core.Services.Interface;

namespace PPT.Test.UserServiceTests
{
    public class UserServiceTests
    {
        [Test]
        public async Task Should_Assign_ExpectedValues()
        {
            var _logger = new Mock<ILogger<UserService>>();
            var _mockRepository = new Mock<IStore<Image>>();

            var _userService = new UserService(_logger.Object, _mockRepository.Object);

            var result = await _userService.GetUserAvatarAsync("77787");

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("https://api.dicebear.com/8.x/pixel-art/png?seed=7&size=150"));
             

        }
    }
}