using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPanelPage : ContentPage
	{
        List<Product> history;
		public HistoryPanelPage (ref List<Product> h)
		{
			InitializeComponent ();
            history = h;
            products.ItemsSource = history;

        }

        async void mylist_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e){
            await Navigation.PushAsync(new DisplayHistroyItemPage(e.SelectedItem as Product));
        }

    }
}