using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Menu
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private long countDrink;

        public long CountDrink
        {
            get { return countDrink; }
            set { countDrink = value; }
        }

        private long price;

        public long Price
        {
            get { return price; }
            set { price = value; }
        }

        private long totalPrice;

        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Menu(string name, long count, long price, long totalPrice)
        {
            this.Name = name;
            this.CountDrink = count;
            this.Price = price;
            this.TotalPrice = price;
        }

        public Menu(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.CountDrink = (long)row["CountDrink"];
            this.Price = (long)row["Price"];
            this.TotalPrice = (long)row["TotalPrice"];
        }
    }
}
