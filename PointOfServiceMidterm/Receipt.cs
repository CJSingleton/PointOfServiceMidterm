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
        public double Change { set; get; }

        public Receipt()
        {
            Cart = new ShoppingCart();
            Subtotal = 0;
            GrandTotal = 0;
            Tax = 0;
            Change = 0;
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

        public static void PrintCashReceipt(ShoppingCart cart, Receipt receipt, double cashTendered)
        {
                Console.WriteLine("{0,66}", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }

            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "Cash Tendered: ", $"{cashTendered:C}");
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", "CHANGE: ", $"{receipt.Change:C}");

        }

        public static void PrintCheckReceipt(ShoppingCart cart, Receipt receipt)
        {
            Console.WriteLine("{0,66}", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "Cash Tendered: ", $"");
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", "CHANGE: ", $"{receipt.Change:C}");



        }

        public static void PrintCreditReceipt(ShoppingCart cart, Receipt receipt)
        {
            Console.WriteLine("{0,66}", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "Cash Tendered: ", $"");
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", "CHANGE: ", $"{receipt.Change:C}");


        }


    }

}
