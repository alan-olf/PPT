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


            var result2 = await _userService.GetUserAvatarAsync("userttt@e");

            Assert.IsNotNull(result2);
            Assert.That(result2, Is.EqualTo("https://api.dicebear.com/8.x/pixel-art/png?seed=e&size=150"));

            var result3 = await _userService.GetUserAvatarAsync("userttt@w");

            Assert.IsNotNull(result3);
            Assert.IsTrue((new List<string>{ "https://api.dicebear.com/8.x/pixel-art/png?seed=1&size=150", 
                "https://api.dicebear.com/8.x/pixel-art/png?seed=2&size=150", 
                "https://api.dicebear.com/8.x/pixel-art/png?seed=3&size=150",
                "https://api.dicebear.com/8.x/pixel-art/png?seed=4&size=150",
                "https://api.dicebear.com/8.x/pixel-art/png?seed=5&size=150"}).Contains(result3));


        }
    }
}