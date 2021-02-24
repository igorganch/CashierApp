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
    public partial class ManagerPanelPage : ContentPage
    {
        List<Product> history;
        List<Product> prods;


        public ManagerPanelPage(ref List<Product> h, ref List<Product> p)
        {
            InitializeComponent();
            history = h;
            prods = p;
        }

        async void Restock_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RestockPage(ref prods));
        }

        async void History_Clicked_View(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPanelPage(ref history));

        }
    }
}