using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using Octokit;

namespace Demo.App.Services.Offline
{
    public class OfflineServiceBase
    {
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CustomContractResolver()
        };

        protected async Task<T> Deserialize<T>(string filename)
        {
            var path = new Uri($"ms-appx:///resources/{filename}.json");
            var file = await StorageFile.GetFileFromApplicationUriAsync(path);
            var json = await FileIO.ReadTextAsync(file);
            
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
