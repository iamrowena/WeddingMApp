using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingMApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppointmentDetailPage : ContentPage
	{
		public AppointmentDetailPage (AppModelClass selectedData)
		{
			InitializeComponent ();
            BindingContext = selectedData;
        }
	}
}