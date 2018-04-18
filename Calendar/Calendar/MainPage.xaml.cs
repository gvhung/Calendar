using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void AuthenticateClicked(object sender, EventArgs e)
        {
            try
            {
                var Client = new GraphServiceClient("https://graph.microsoft.com/v1.0",
                      new DelegateAuthenticationProvider(async (requestMessage) =>
                      {
                          var tokenRequest = await App.IdentityClientApp.AcquireTokenAsync(App.Scopes, App.UiParent).ConfigureAwait(false);
                          requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenRequest.AccessToken);
                      }));
                await Navigation.PushAsync(new MeetingHome());
            }
            catch (MsalException ex)
            {
                await DisplayAlert("Error", ex.Message, "OK", "Cancel");
            }
        }
    }
}
