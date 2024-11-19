﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PPT.App.Core.ApiModels.ApiResponse;
using PPT.App.Core.Data;
using PPT.App.Core.Data.Entities;
using PPT.App.Core.Data.Store;
using PPT.App.Core.Services.Interface;

namespace PPT.App.Core.Services
{

    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IStore<Image> _imageStore;

        public UserService(ILogger<UserService> logger, IStore<Image> imageStore)
        {
            _logger = logger;
            _imageStore = imageStore;
        }

        public async Task<string> GetUserAvatarAsync(string userIdentifier)
        {
            var last = userIdentifier.Last();
            var partOne = "6789";
            var partTwo = "12345";

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
            else if (partTwo.Contains(last))
            {

                var result = _imageStore.Query.Where(i => i.Id == last.ToString()).FirstOrDefault();

                return result?.Url;

            }


            return null;

        }
         
    }
}
