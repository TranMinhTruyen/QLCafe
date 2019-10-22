using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cafe
{
    public class Category
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

        public Category(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Category(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.Name = row["Name"].ToString();
        }
    }
}
