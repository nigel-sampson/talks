using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public class NoNetworkRepositoryService : IRepositoryService
    {
        public Task<IReadOnlyList<Repository>> SearchAsync(string term)
        {
            var repos = new List<Repository>
            {
                CreateRepository(name: "MVVM", owner: CreateUser(login: "lizelu")),
                CreateRepository(name: "mvvm", owner: CreateUser(login: "JsAaron")),
                CreateRepository(name: "MvvmCross", owner: CreateUser(login: "MvvmCross")),
                CreateRepository(name: "MVVMReactiveCocoa", owner: CreateUser(login: "leichunfeng")),
                CreateRepository(name: "mvvmFX", owner: CreateUser(login: "sialcasa"))
            };

            return Task.FromResult<IReadOnlyList<Repository>>(
                new ReadOnlyCollection<Repository>(repos));
        }

        public Task<Repository> GetDetailsAsync(string owner, string name)
        {
            return Task.FromResult(new Repository());
        }

        private Repository CreateRepository(string url = null, string htmlUrl = null, string cloneUrl = null, string gitUrl = null, string sshUrl = null, string svnUrl = null, string mirrorUrl = null, int id = 0, User owner = null, string name = null, string fullName = null, string description = null, string homepage = null, string language = null, bool @private = false, bool fork = false, int forksCount = 0, int stargazersCount = 0, int subscribersCount = 0, string defaultBranch = null, int openIssuesCount = 0, DateTimeOffset? pushedAt = null, DateTimeOffset? createdAt = null, DateTimeOffset? updatedAt = null, RepositoryPermissions permissions = null, User organization = null, Repository parent = null, Repository source = null, bool hasIssues = false, bool hasWiki = false, bool hasDownloads = false)
        {
            return new Repository(url, htmlUrl, cloneUrl, gitUrl, sshUrl, svnUrl, mirrorUrl, id, owner, name, fullName, description, homepage, language, @private, fork, forksCount, stargazersCount, subscribersCount, defaultBranch, openIssuesCount, pushedAt, createdAt ?? DateTimeOffset.UtcNow, updatedAt ?? DateTimeOffset.UtcNow, permissions, organization, parent, source, hasIssues, hasWiki, hasDownloads);
        }

        private User CreateUser(string avatarUrl = null, string bio = null, string blog = null, int collaborators = 0, string company = null, DateTimeOffset? createdAt = null, int diskUsage = 0, string email = null, int followers = 0, int following = 0, bool? hireable = null, string htmlUrl = null, int totalPrivateRepos = 0, int id = 0, string location = null, string login = null, string name = null, int ownedPrivateRepos = 0, Plan plan = null, int privateGists = 0, int publicGists = 0, int publicRepos = 0, string url = null, bool siteAdmin = false)
        {
            return new User(avatarUrl, bio, blog, collaborators, company, createdAt ?? DateTimeOffset.UtcNow, diskUsage, email, followers, following, hireable, htmlUrl, totalPrivateRepos, id, location, login, name, ownedPrivateRepos, plan, privateGists, publicGists, publicRepos, url, siteAdmin);
        }
    }
}
