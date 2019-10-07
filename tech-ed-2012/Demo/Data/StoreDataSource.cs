using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.ViewModels;
using Newtonsoft.Json;
using Windows.Storage;

namespace Demo.Data
{
    public class StoreDataSource
    {
        public async Task<IList<CategoryViewModel>> LoadCategories()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///data/store.json"));
            var json = await FileIO.ReadTextAsync(file);

            return JsonConvert.DeserializeObject<IList<CategoryViewModel>>(json);
        }
    }
}
