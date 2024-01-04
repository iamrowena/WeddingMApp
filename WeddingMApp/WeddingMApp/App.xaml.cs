using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeddingMApp

{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("IsLoggedIn") && Preferences.Get("IsLoggedIn", false))
            {
                //string savedUsername = Preferences.Get("Username", string.Empty);
                //MainPage = new NavigationPage(new UserPage(savedUsername))
                MainPage = new NavigationPage(new MainPage())
                {
                    //BarBackgroundColor = Color.FromHex("#db7093"),
                    
                };
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    //BarBackgroundColor = Color.FromHex("#db7093"),
                };
            }
        }
        // Logout method
        public static void Logout()
        {
            Preferences.Remove("IsLoggedIn");
            Preferences.Remove("Username");

            Current.MainPage = new NavigationPage(new LoginPage())//pag logout balik mainpage andg start
            {
                BarBackgroundColor = Color.FromHex("#db7093")
            };
        }

    }
}
