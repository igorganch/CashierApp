using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Product
    {
        public string name { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public DateTime localDate;
        public Product() {
        localDate = DateTime.Now;
        }

        public Product(string name1, int qty1, double price1)
        {
            this.name = name1;
            this.qty = qty1;
            this.price = price1;
            localDate = DateTime.Now;

        }
        public int getQTY()  {
            return this.qty;
        }
        public void updtqty(int i)
        {

            qty = i;


        }
    }
}
