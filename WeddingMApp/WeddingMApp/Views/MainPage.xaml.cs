using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeddingMApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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
            // Simulate loading process (Replace this with your actual loading logic)
            await SimulateLoading();

            await Navigation.PushAsync(new LoginPage());


        }

        // Simulate loading process
        private async Task SimulateLoading()
        {

            await Task.Delay(2000); // Simulate loading for 2 seconds
        }
    }
}
