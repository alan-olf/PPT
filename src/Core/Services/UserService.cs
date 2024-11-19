using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PPT.App.Core.ApiModels.ApiResponse;
using PPT.App.Core.Services.Interface;

namespace PPT.App.Core.Services
{

    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetUserAvatarAsync(string userIdentifier)
        {
            var last = userIdentifier.Last();
            var partOne = "6789";

            if (partOne.Contains(last))
            {
                var url = AppConstant.BaseUrlPartOne.Replace("{identifier}", last.ToString());

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<AvatarApiResponse>(content)?.Url;

                    }

                }


            }

            return null;

        }
         
    }
}
