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
        public double Tax { set; get; }

        public Receipt()
        {
            Cart = new ShoppingCart();
            Subtotal = 0;
            GrandTotal = 0;
            Tax = 0;
        }

        public static double CalcSalesTax(double subtotal)
        {
            double tax = subtotal * .06;
            return tax;
        }

        public static double CalcGrandTotal(double subtotal, double tax)
        {
            return subtotal + tax;
        }

        public static double CalcSubTotal(List<ShoppingCart> cart)
        {
            double subTotal = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                
                double q = double.Parse(cart[i].Quantity.ToString()) * double.Parse(cart[i].Price.ToString());
                subTotal += q; 
            }
            return subTotal;
        }

        public static void PrintReceipt(List<ShoppingCart> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{cart[i].Names} x {cart[i].Quantity} = {cart[i].Price * cart[i].Quantity}");
            }
        }

    }
    
}
