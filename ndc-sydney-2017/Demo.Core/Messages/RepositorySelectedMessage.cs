namespace Demo.Core.Messages
{
    public class RepositorySelectedMessage
    {
        public RepositorySelectedMessage(string owner, string name)
        {
            Owner = owner;
            Name = name;
        }

        public string Owner { get; }
        public string Name { get; }
    }
}
