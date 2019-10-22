using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Drink
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private long price;

        public long Price
        {
            get { return price; }
            set { price = value; }
        }

        private long idCategory;

        public long IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public Drink(long id, string name, long price, long idCategory)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.IdCategory = idCategory;
        }

        public Drink(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.Name = row["Name"].ToString();
            this.Price = (long)row["Price"];
            this.IdCategory = (long)row["IdCategory"];
        }
    }
}
