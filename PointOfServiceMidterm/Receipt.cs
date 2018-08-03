using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class Receipt
    {
        public ShoppingCart Cart { set; get; }
        public double Subtotal   { set; get; }
        public double GrandTotal { set; get; }

        public Receipt()
        {
            Cart = new ShoppingCart();
            Subtotal = 0;
            GrandTotal = 0;
        }

    }
    
}
