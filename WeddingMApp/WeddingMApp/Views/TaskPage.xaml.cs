using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMApp.Models;
using WeddingMApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MongoDbModule;
using static MongoDBService;

namespace WeddingMApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        private MongoDBService _mongoDBService;
        public ObservableCollection<TaskModelClass> ClientDataList { get; set; }

        public TaskPage()
        {
            InitializeComponent();

        }


        public TaskPage(string username)
        {
            InitializeComponent();

            _mongoDBService = new MongoDBService("mongodb://WeddingManagement:DBWEDDING@ac-wqpfbrf-shard-00-00.npbib6e.mongodb." +
    "net:27017,ac-wqpfbrf-shard-00-01.npbib6e.mongodb.net:27017,ac-wqpfbrf-shard-00-02.npbib6e.mongodb.net:27017/?ssl=" +
    "true&replicaSet=atlas-dakj1p-shard-0&authSource=admin&retryWrites=true&w=majority", "DBWEDDING");

            ClientDataList = new ObservableCollection<TaskModelClass>();
            clientListView.ItemsSource = ClientDataList;

            LoadClientData(username);

        }

        public async void LoadClientData(string username)
        {
            var clientData = await _mongoDBService.GetClientDataAsync(username);
            foreach (var dataItem in clientData)
            {
                ClientDataList.Add(dataItem);
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());  //Go to LoginPage
        }


        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedData = e.Item as TaskModelClass;
            if (selectedData != null)
            {
                await Navigation.PushAsync(new TaskDetailPage(selectedData));
            }
        }

    }
}