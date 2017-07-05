using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Hubb.Core.Services
{
    public class OfflineHubbClient : IHubbClient
    {
        private const string Lipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque fermentum finibus risus in pulvinar. Quisque at dolor interdum, facilisis odio at, ullamcorper urna. Donec suscipit, odio vitae posuere vehicula, nisl massa interdum lorem, quis elementum massa felis sed massa. Phasellus non dui nibh. Praesent porttitor lorem ante, consectetur laoreet felis finibus non. In vitae fermentum nunc. Curabitur volutpat ligula at velit egestas tristique. Etiam tincidunt molestie felis pharetra varius. Morbi ullamcorper iaculis facilisis.";
        private readonly Random random = new Random();

        public Task<IReadOnlyList<Repository>> SearchAsync(string term)
        {
            var repos = new List<Repository>
            {
                CreateRepository(name: "Caliburn.Micro"),
                CreateRepository(name: "Fresh MVVM"),
                CreateRepository(name: "MvvmCross"),
                CreateRepository(name: "MVVM Light"),
                CreateRepository(name: "Prism"),
                CreateRepository(name: "Reactive UI")
            };

            return Task.FromResult<IReadOnlyList<Repository>>(repos);
        }

        public Task<IReadOnlyList<Issue>> GetIssuesAsync(Repository repository)
        {
            var issues = Enumerable.Range(1, 20)
                .Select(i => CreateIssue(title: $"Issue {i}", body: GetLipsum(), comments: random.Next(100)))
                .ToList();

            return Task.FromResult<IReadOnlyList<Issue>>(issues);
        }

        private static Repository CreateRepository(string url = null, string htmlUrl = null, string cloneUrl = null, string gitUrl = null, string sshUrl = null, string svnUrl = null, string mirrorUrl = null, int id = 0, User owner = null, string name = null, string fullName = null, string description = null, string homepage = null, string language = null, bool @private = false, bool fork = false, int forksCount = 0, int stargazersCount = 0, string defaultBranch = null, int openIssuesCount = 0, DateTimeOffset? pushedAt = null, DateTimeOffset? createdAt = null, DateTimeOffset? updatedAt = null, RepositoryPermissions permissions = null, Repository parent = null, Repository source = null, bool hasIssues = false, bool hasWiki = false, bool hasDownloads = false)
        {
            return new Repository(url, htmlUrl, cloneUrl, gitUrl, sshUrl, svnUrl, mirrorUrl, id, owner, name, fullName, description, homepage, language, @private, fork, forksCount, stargazersCount, defaultBranch, openIssuesCount, pushedAt, createdAt ?? DateTimeOffset.UtcNow, updatedAt ?? DateTimeOffset.UtcNow, permissions, parent, source, hasIssues, hasWiki, hasDownloads);
        }

        private static User CreateUser(string avatarUrl = null, string bio = null, string blog = null, int collaborators = 0, string company = null, DateTimeOffset? createdAt = null, int diskUsage = 0, string email = null, int followers = 0, int following = 0, bool? hireable = null, string htmlUrl = null, int totalPrivateRepos = 0, int id = 0, string location = null, string login = null, string name = null, int ownedPrivateRepos = 0, Plan plan = null, int privateGists = 0, int publicGists = 0, int publicRepos = 0, string url = null, bool siteAdmin = false)
        {
            return new User(avatarUrl, bio, blog, collaborators, company, createdAt ?? DateTimeOffset.UtcNow, diskUsage, email, followers, following, hireable, htmlUrl, totalPrivateRepos, id, location, login, name, ownedPrivateRepos, plan, privateGists, publicGists, publicRepos, url, null, siteAdmin, null, null);
        }

        private static Issue CreateIssue(Uri url = null, Uri htmlUrl = null, Uri commentsUrl = null, Uri eventsUrl = null, int number = 0, ItemState state = ItemState.Open, string title = null, string body = null, User closedBy = null, User user = null, IReadOnlyList<Label> labels = null, User assignee = null, Milestone milestone = null, int comments = 0, PullRequest pullRequest = null, DateTimeOffset? closedAt = null, DateTimeOffset? createdAt = null, DateTimeOffset? updatedAt = null, int id = 0, bool locked = false, Repository repository = null)
        {
            return new Issue(url, htmlUrl, commentsUrl, eventsUrl, number, state, title, body, closedBy, user, labels, assignee, milestone, comments, pullRequest, closedAt, createdAt ?? DateTimeOffset.UtcNow, updatedAt, id, locked, repository);
        }

        private string GetLipsum()
        {
            return Lipsum.Substring(0, random.Next(Lipsum.Length));
        }
    }
}
