using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.ViewModels;
using Newtonsoft.Json;
using Windows.Storage;

namespace Demo.Data
{
    public class GitHubDataSource
    {
        public async Task<IList<RepositoryViewModel>> LoadRepositories()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///data/github.json"));
            var json = await FileIO.ReadTextAsync(file);

            return JsonConvert.DeserializeObject<IList<RepositoryViewModel>>(json);
        }
    }
}
