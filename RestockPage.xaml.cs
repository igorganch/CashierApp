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
	public partial class RestockPage : ContentPage
	{
        List<Product> prods;
        int index;
        bool tf = false;
		public RestockPage (ref List<Product> h)
		{

			InitializeComponent();
            prods = h;
            entry.Text = String.Empty;

            products.ItemsSource = prods;
        }

      public void Restock_Clicked(object sender, EventArgs e){
            if (tf != true)
            {

                DisplayAlert("Error", "You have not selected a product", "OK");
            }
            else if (entry.Text == String.Empty) {
                DisplayAlert("Error", "You have not selected a Quantity", "OK");
            }
            else
            {

                    prods[index].qty = Convert.ToInt32(entry.Text);


                
            }
            products.ItemsSource = null;
            products.ItemsSource = prods;

            entry.Text = String.Empty;

            tf = false;
        }

        public void Cancel_Clicked(object sender, EventArgs e)
        {


            products.ItemsSource = null;
            products.ItemsSource = prods;
            entry.Text = String.Empty;







        }

        public void mylist_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            for (int i = 0; i < prods.Count(); i++) {
                if((e.SelectedItem as Product).name == prods[i].name)
                {
                    index = i;
                    tf = true;
                }

          }

        }


     }
}