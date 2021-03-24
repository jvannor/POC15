using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC15.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> SignIn()
        {
            await Task.Delay(2500);
            return true;
        }

        public async Task<bool> SignOut()
        {
            await Task.Delay(2500);
            return true;
        }
    }
}
