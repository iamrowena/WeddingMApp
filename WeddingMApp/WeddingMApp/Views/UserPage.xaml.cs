using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using MongoDB.Driver.Core.Authentication;

namespace WeddingMApp
{

    public partial class UserPage : ContentPage
    {
        private string username;
       

        public UserPage(string username)
        {
            InitializeComponent();
            MongoDbModule.InitializeMongoDb();

            this.username = username;

            double eightyPercentWidth = 0.9 * DeviceDisplay.MainDisplayInfo.Width;

            NavigationPage.SetHasBackButton(this, false);

            var titleViewLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            NavigationPage.SetHasBackButton(this, false);

            welcomeLabel.Text = $"Welcome, {username}!";

            NavigationPage.SetTitleView(this, titleViewLayout);


        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Check for internet connectivity
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("No Internet", "Please connect to the internet and try again.", "OK");

                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }

        }


        private async void LogoutClicked(object sender, EventArgs e)
        {
            bool logoutConfirmed = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
            if (logoutConfirmed)
            {

                App.Logout();
            }

        }
    }


    }


