using System;

namespace NDC.Build.Core.Services
{
    public class Credentials
    {
        public static readonly Credentials None = new Credentials(String.Empty, String.Empty);

        public Credentials(string account, string token)
        {
            Account = account;
            Token = token;
        }

        public string Account { get; }

        public string Token { get; }
    }
}
