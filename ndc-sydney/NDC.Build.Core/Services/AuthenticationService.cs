using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NDC.Build.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> AuthenticateCredentialsAsync(Credentials credentials)
        {
            var relativeUri = new Uri("/DefaultCollection/_apis/projects", UriKind.Relative);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"username:{credentials.Token}".ToBase64());

                var baseUri = new Uri($"https://{credentials.Account}.visualstudio.com", UriKind.Absolute);

                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUri, relativeUri));

                using (var response = await client.SendAsync(request))
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
        }
    }
}
