using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC15.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsSignedIn();

        Task<bool> SignIn();

        Task<bool> SignOut();
    }
}
