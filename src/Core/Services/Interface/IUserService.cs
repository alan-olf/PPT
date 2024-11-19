using PPT.App.Common.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.App.Core.Services.Interface
{
    public interface IUserService : IScopeDependency
    {
        Task<string> GetUserAvatarAsync(string userIdentifier);
    }
}
