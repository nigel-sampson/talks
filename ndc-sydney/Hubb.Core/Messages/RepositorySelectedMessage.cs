using System;
using Octokit;

namespace Hubb.Core.Messages
{
    public class RepositorySelectedMessage
    {
        public RepositorySelectedMessage(Repository repository)
        {
            Repository = repository;
        }

        public Repository Repository { get; }
    }
}
