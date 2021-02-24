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
	public partial class DisplayHistroyItemPage : ContentPage
	{
        Product product;
		public DisplayHistroyItemPage (Product prod)
		{
			InitializeComponent ();
            product = prod;
            name.Text = product.name;
            price.Text = Convert.ToString(product.price * product.qty);
            quantity.Text = Convert.ToString(product.qty);
            date.Text = Convert.ToString(product.localDate);

        }


	}
}