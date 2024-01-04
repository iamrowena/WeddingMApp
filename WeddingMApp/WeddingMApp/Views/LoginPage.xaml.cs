using System;
using WeddingMApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeddingMApp
{
    public partial class LoginPage : ContentPage
    {
        private MongoDBService _mongoDBService;

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _mongoDBService = new MongoDBService("mongodb://WeddingManagement:DBWEDDING@ac-wqpfbrf-shard-00-00.npbib6e.mongodb." +
    "net:27017,ac-wqpfbrf-shard-00-01.npbib6e.mongodb.net:27017,ac-wqpfbrf-shard-00-02.npbib6e.mongodb.net:27017/?ssl=" +
    "true&replicaSet=atlas-dakj1p-shard-0&authSource=admin&retryWrites=true&w=majority", "DBWEDDING");


            double eightyPercentWidth = 0.8 * DeviceDisplay.MainDisplayInfo.Width;


            usernameEntry.WidthRequest = eightyPercentWidth;
            passwordEntry.WidthRequest = eightyPercentWidth;
        }


        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Handle validation and display messages as needed
                // ...

                return;
            }

            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            try
            {
                var success = await _mongoDBService.LoginUserAsync(username, password);

                if (success)
                {
                    Preferences.Set("IsLoggedIn", true);
                    Preferences.Set("Username", username);

                    // Create a TabbedPage and add your TaskPage as a tab
                    var tabbedPage = new TabbedPage();
                    tabbedPage.Children.Add(new TaskPage(username) {Title = "Wedding Details" });
                    tabbedPage.Children.Add(new AppointPage(username) { Title = "Appointment" });

                    // Navigate to the TabbedPage
                    await Navigation.PushAsync(tabbedPage);
                }
                else
                {
                    await DisplayAlert("Invalid", "Invalid client no or email!", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Server Problem", "No Internet Connection", "OK");
            }
            finally
            {
                loadingIndicator.IsRunning = false;
                loadingIndicator.IsVisible = false;
            }
        }


        private void OnUsernameEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            usernameMessageLabel.IsVisible = false;
        }

        private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            passwordMessageLabel.IsVisible = false;
        }
    }
}
