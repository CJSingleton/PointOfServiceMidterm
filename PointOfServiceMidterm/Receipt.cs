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

        public static double CalcSubTotal(ShoppingCart cart)
        {
            double subTotal = 0;
            for (int i = 0; i < cart.Names.Count; i++)
            {
                
                double q = double.Parse(cart.Quantity[i].ToString()) * cart.Price[i];
                subTotal += q; 
            }
            return subTotal;
        }

        public static void PrintReceipt(ShoppingCart cart)
        {
                Console.WriteLine("{0,66", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)
            {

                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }



        }

    }
    
}
