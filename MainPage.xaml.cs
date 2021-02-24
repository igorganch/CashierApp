using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        bool tf;
       bool tf2 = false;
        string num1;
        double total;
        List<Product> prods;
        List<Product> prodSelected;
        List<Product> history;
        public MainPage()
        {
            InitializeComponent();
            prods = new List<Product> {
            new Product(){name = "Banana", qty = 20, price = 1.24},
            new Product(){name = "Apple", qty = 10, price = 1.00},
            new Product(){name = "Frosted Flakes Cerial", qty = 60, price = 2.24},
            new Product(){name = "Marshmellows", qty = 60, price = 3.14},
            };
            
            products.ItemsSource = prods;


            prodSelected = new List<Product>();
            tf = false;
            history = new List<Product>();
        }
        public void mylist_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) {
           tf2 = true;
            if (tf == true) {
                total += prodSelected.Last().price * Convert.ToInt32(num1);
                tf = false;
                total1.Text = Convert.ToString(total);
            }
            num1 = "";
            quantity1.Text = num1;
            Console.WriteLine((e.SelectedItem as Product).name);
            type.Text = (e.SelectedItem as Product).name;
            prodSelected.Add(new Product() { name = (e.SelectedItem as Product).name, qty = 0, price = (e.SelectedItem as Product).price });

       /*   for (int i = 0; i < prods.Count(); i++) {
                if ((e.SelectedItem as Product).name == prods[i].name)
                {

              //    prodSelected.Add(new Product() { name = prods[i].name , qty = 0 , price = prods[i].price  });
                }


            } */

        }
        public void updateProd() {
            for (int i = 0; i < prodSelected.Count(); i++) {
                for (int j = 0; j < prods.Count(); j++) {

                    if (prodSelected[i].name == prods[j].name)
                    {
                        int qty1 = prodSelected[i].getQTY();
                        int qty2 = prods[j].getQTY();

                        prods[j].updtqty((qty2 - qty1));
                    }


                }

            }
            products.ItemsSource = null;
            products.ItemsSource = prods;
        }
        public void add_History()
        {

            for (int i = 0; i < prodSelected.Count(); i++)
            {
                history.Add(new Product() { name = prodSelected[i].name, qty = prodSelected[i].qty, price = prodSelected[i].price });

            }

            prodSelected.Clear();
        }
        async void Manager_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPanelPage(ref history,ref prods));
            products.ItemsSource = null;
            products.ItemsSource = prods;

        }
        
            public void Buy_Clicked(object sender, EventArgs e) {
            //  prodSelected.Last().updtqty(Convert.ToInt32(num1));
            //   products.SelectedItem as Product;
            if (num1 == "")
            {
                prodSelected.RemoveAt((prodSelected.Count() - 1));
                total1.Text = Convert.ToString(total);
                type.Text = "";

                updateProd();
                add_History();
            }
            else if (tf == false) {

                DisplayAlert("Error", "You have not selected a Quantity", "OK");
            }
            else
            {
                total += prodSelected.Last().price * Convert.ToInt32(num1);
                num1 = "";
                quantity1.Text = num1;
                total1.Text = Convert.ToString(total);
                updateProd();
                add_History();
            }
            tf2 = false;
            tf = false;
            quantity1.Text = String.Empty;


            type.Text = String.Empty;
        }

        public void Number_Clicked(object sender, EventArgs e) {
           if (tf2 == true)
            { 
                Button digit = (Button)sender;
                double num = Double.Parse(digit.Text);
                num1 = num1 + ((Button)sender).Text;
                quantity1.Text = num1;

                prodSelected.Last().updtqty(Convert.ToInt32(num1));

                tf = true;

           }
           else {
                DisplayAlert("Error", "You have not selected a Product", "OK");
            }
        }
    }
}
