using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    

    public class Invoice
    {
        public int Invoice_id { set; get; }
        public int Customer_id { set; get; }
        public DateTime Date { set; get; }
        public decimal Total { set; get; }
        public bool Active { set; get; }

    }
}
