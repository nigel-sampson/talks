using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TechEd.Services
{
    public static class ApplicationSettings
    {
        private static ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public static string InitialQuery
        {
            get
            {
                if (!settings.Values.ContainsKey("InitialQuery"))
                    return String.Empty;

                return (string)settings.Values["InitialQuery"]; 
            }
            set
            {
                settings.Values["InitialQuery"] = value;
            }
        }
    }
}
