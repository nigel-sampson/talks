using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NDC.Build.Core.Model;
using Newtonsoft.Json;

namespace NDC.Build.Core.Services
{
    public class TeamServicesClient
    {
        private readonly ICredentialsService credentialsService;

        public TeamServicesClient(ICredentialsService credentialsService)
        {
            this.credentialsService = credentialsService;
        }

        public Task<IReadOnlyCollection<Project>> GetProjectsAsync()
        {
            return GetListResponseAsync<Project>(new Uri("/DefaultCollection/_apis/projects", UriKind.Relative));
        }

        public Task<Project> GetProjectAsync(string id)
        {
            return GetResponseAsync<Project>(new Uri($"/DefaultCollection/_apis/projects/{id}?api-version=1.0", UriKind.Relative));
        }

        public Task<IReadOnlyCollection<BuildDetail>> GetBuildsAsync(Project project)
        {
            return GetListResponseAsync<BuildDetail>(new Uri($"/DefaultCollection/{project.Id}/_apis/build/builds?api-version=2.0", UriKind.Relative));
        }

        public Task<IReadOnlyCollection<Definition>> GetDefinitionsAsync(Project project)
        {
            return GetListResponseAsync<Definition>(new Uri($"/DefaultCollection/{project.Id}/_apis/build/definitions?api-version=2.0", UriKind.Relative));
        }

        public async Task<BuildDetail> QueueBuildAsync(Project project, BuildRequest buildRequest)
        {
            var credentials = await credentialsService.GetCredentialsAsync();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"username:{credentials.Token}".ToBase64());

                var uri = new Uri($"https://{credentials.Account}.visualstudio.com/DefaultCollection/{project.Id}/_apis/build/builds?api-version=2.0", UriKind.Absolute);

                var requestJson = JsonConvert.SerializeObject(buildRequest);

                var request = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var responseJson = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<BuildDetail>(responseJson);
                }
            }
        }

        private async Task<IReadOnlyCollection<T>> GetListResponseAsync<T>(Uri relativeUri)
        {
            var credentials = await credentialsService.GetCredentialsAsync();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"username:{credentials.Token}".ToBase64());

                var baseUri = new Uri($"https://{credentials.Account}.visualstudio.com", UriKind.Absolute);

                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUri, relativeUri));

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();

                    var list = JsonConvert.DeserializeObject<ListResponse<T>>(json);

                    return new ReadOnlyCollection<T>(list.Value.ToList());
                }
            }
        }

        private async Task<T> GetResponseAsync<T>(Uri relativeUri)
        {
            var credentials = await credentialsService.GetCredentialsAsync();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"username:{credentials.Token}".ToBase64());

                var baseUri = new Uri($"https://{credentials.Account}.visualstudio.com", UriKind.Absolute);

                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUri, relativeUri));

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
        }
    }
}
