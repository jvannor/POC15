using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Xamarin.Essentials;
using POC15.Helpers;

namespace POC15.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public static object ParentWindow { get; set; }

        private string RedirectUri
        {
            get
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    return Secrets.androidRedirectUriSecret;
                }
                else if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    return Secrets.iOSRedirectUriSecret;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public AuthenticationService()
        {
            pca = PublicClientApplicationBuilder.Create(Secrets.clientSecret)
                .WithIosKeychainSecurityGroup("com.detroitcyclecar.dev.poc15")                                               
                .WithRedirectUri(RedirectUri)
                .WithAuthority("https://login.microsoftonline.com/common")
                .Build();
        }

        public async Task<bool> IsSignedIn()
        {
            try
            {
                var accounts = await pca.GetAccountsAsync();
                var firstAccount = accounts.FirstOrDefault();
                var authResult = await pca.AcquireTokenSilent(scopes, firstAccount).ExecuteAsync();

                await SecureStorage.SetAsync("AccessToken", authResult?.AccessToken);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> SignIn()
        {
            try
            {
                var authResult = await pca.AcquireTokenInteractive(scopes)
                    .WithParentActivityOrWindow(ParentWindow)
                    .WithUseEmbeddedWebView(true)
                    .ExecuteAsync();

                await SecureStorage.SetAsync("AccessToken", authResult?.AccessToken);
                return true;
            }
            catch(Exception uxEx)
            {
                System.Diagnostics.Debug.WriteLine(uxEx);
                return false;
            }
        }

        public async Task<bool> SignOut()
        {
            try
            {
                var accounts = await pca.GetAccountsAsync();
                while (accounts.Any())
                {
                    await pca.RemoveAsync(accounts.FirstOrDefault());
                    accounts = await pca.GetAccountsAsync();
                }

                SecureStorage.Remove("AccessToken");
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private readonly string[] scopes = { "User.Read" };
        private readonly IPublicClientApplication pca;
    }
}
