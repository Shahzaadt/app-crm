using System;
using System.Diagnostics;
using Microsoft.WindowsAzure.MobileServices;
using MobileCRM.iOS.Renderers;
using MobileCRM.Pages.Home;
using MobileCRM.Services;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer_iOS))]

namespace MobileCRM.iOS.Renderers
{
    public class LoginPageRenderer_iOS : PageRenderer, ILogin
    {
        public async override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Insights.Track("Login Page");

            try
            {
                if (AuthInfo.Instance.User == null)
                {
                    MobileServiceClient client = AuthInfo.Instance.GetMobileServiceClient();

                    AuthInfo.Instance.User = await client.LoginAsync(this.ViewController, AuthInfo.AUTH_PROVIDER);
                    
                    //SYI: Will implement user info return in v2.
                    //await AuthInfo.Instance.GetUserInfo();

                    MessagingCenter.Send<ILogin>(this, "Authenticated");
                } //end if
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR Authenticating: " + ex.Message);
            } //end catch
        }
    }
    //end class
}