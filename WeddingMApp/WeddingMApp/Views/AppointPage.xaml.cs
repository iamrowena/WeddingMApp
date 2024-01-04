using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMApp.Models;
using WeddingMApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointPage : ContentPage
    {
        private MongoDBService _mongoDBService;
        public ObservableCollection<AppModelClass> AppDataList { get; set; }

        public AppointPage()
        {
            InitializeComponent();
        }

        public AppointPage(string username)
        {
            InitializeComponent();

            _mongoDBService = new MongoDBService("mongodb://WeddingManagement:DBWEDDING@ac-wqpfbrf-shard-00-00.npbib6e.mongodb." +
    "net:27017,ac-wqpfbrf-shard-00-01.npbib6e.mongodb.net:27017,ac-wqpfbrf-shard-00-02.npbib6e.mongodb.net:27017/?ssl=" +
    "true&replicaSet=atlas-dakj1p-shard-0&authSource=admin&retryWrites=true&w=majority", "DBWEDDING");

            AppDataList = new ObservableCollection<AppModelClass>();
            AppListView.ItemsSource = AppDataList;

            LoadAppData(username);
        }

        public async void LoadAppData(string username)
        {
            var clientData = await _mongoDBService.AppDataAsync(username);
            foreach (var appItem in clientData)
            {
                AppDataList.Add(appItem);
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());  //Go to LoginPage
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedData = e.Item as AppModelClass;
            if (selectedData != null)
            {
                await Navigation.PushAsync(new AppointmentDetailPage(selectedData));
            }
            else
            {
                await DisplayAlert("Error", "Not selected not null", "OK");
            }
        }




    }
}