using System;
using System.Threading.Tasks;

namespace NDC.Build.Core.Services
{
    public interface ICredentialsService
    {
        Task<Credentials> GetCredentialsAsync();
    }
}
