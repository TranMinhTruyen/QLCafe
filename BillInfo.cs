using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class BillInfo
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long idDrink;

        public long IdDrink
        {
            get { return idDrink; }
            set { idDrink = value; }
        }

        private long idBill;

        public long IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        private long countDrink;

        public long CountDrink
        {
            get { return countDrink; }
            set { countDrink = value; }
        }

        public BillInfo(long id, long idDrink, long idBill, long countDrink)
        {
            this.Id = id;
            this.IdDrink = idDrink;
            this.IdBill = idBill;
            this.CountDrink = countDrink;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdDrink = (long)row["IdDrink"];
            this.IdBill = (long)row["IdBill"];
            this.CountDrink = (long)row["CountDrink"];
        }
    }
}
