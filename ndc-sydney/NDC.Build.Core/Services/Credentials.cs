using System;

namespace NDC.Build.Core.Services
{
    public class Credentials
    {
        public Credentials(string account, string token)
        {
            Account = account;
            Token = token;
        }

        public string Account { get; }

        public string Token { get; }
    }
}
