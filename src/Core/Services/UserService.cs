using Microsoft.Extensions.Logging;
using PPT.App.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.App.Core.Services
{

    public class UserService : IUserService
    {  
        private readonly ILogger _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public Task<string> GetUserAvatarAsync(string userIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
