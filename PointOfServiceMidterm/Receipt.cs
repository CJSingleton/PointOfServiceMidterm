using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class Receipt
    {
        // Properties

        public ShoppingCart Cart { set; get; }
        public double Subtotal   { set; get; }
        public double GrandTotal { set; get; }
        public double Tax { set; get; }
        public double Change { set; get; }

        public Receipt() //setting default values
        {
            Cart = new ShoppingCart();
            Subtotal = 0;
            GrandTotal = 0;
            Tax = 0;
            Change = 0;
        }

        // Passes through subtotal to be multipled with double tax input.
        public static double CalcSalesTax(double subtotal)
        {
            double tax = subtotal * .06; 
            return Math.Round(tax, 2); // rounds the double decimal to the nearest two digit placement.
        }

        // passes through subtotal and tax to be added together
        public static double CalcGrandTotal(double subtotal, double tax)
        {
            return subtotal + tax;
        }

        /// <summary>
        /// takes user choices from shopping cart, calculates line total of each based on quantity and price,
        /// adds to subtotal variable.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>returns total calculated subtotal for initialization.</returns>
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
            for (int i = 0; i < cart.Names.Count; i++)//lists name and quantity of line items
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }

            Console.WriteLine("==================================================================");//basic receipt cost info w/ formatting
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "Cash Tendered: ", $"{cashTendered:C}");// displays the amount of cash user provided at checkout
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", "CHANGE: ", $"{receipt.Change:C}");// displays the difference between GrandTotal and cashTendered, i.e. the change

        }

        public static void PrintCheckReceipt(ShoppingCart cart, Receipt receipt, string checkNum)
        {
            Console.WriteLine("{0,66}", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)//lists name and quantity of line items
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }
            Console.WriteLine("==================================================================");//basic receipt cost info w/ formatting
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "Amount paid: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("==================================================================");
            Console.WriteLine("{0,-15}{1,51}", "CHECK NUMBER: ", checkNum);//prints user's check number as part of receipt 
        }
        
        public static void PrintCreditReceipt(ShoppingCart cart, Receipt receipt, List<string> creditInfo)
        {
            List<string> cInfo = creditInfo;
            Console.WriteLine("{0,66}", "---------------------------------------------------------PURCHASES");
            for (int i = 0; i < cart.Names.Count; i++)//lists name and quantity of line items
            {
                Console.WriteLine("{0,-30}   {1,20} = {2,10}", cart.Names[i], $"x {cart.Quantity[i]}", $"{(cart.Price[i] * cart.Quantity[i]):C}");
            }
            Console.WriteLine("=================================================================="); // basic receipt cost info w/ formatting
            Console.WriteLine("{0,-15}{1,51}", $"Subtotal: ", $"{receipt.Subtotal:C}");
            Console.WriteLine("{0,-15}{1,51}", "6% State Tax:", $"{receipt.Tax:C}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("{0,-15}{1,51}", "Grand total: ", $"{receipt.GrandTotal:C}");
            Console.WriteLine("==================================================================");
            //string ccString = (creditInfo.ElementAt(0).Length > 16) ? creditInfo.ElementAt(0).Substring(creditInfo.ElementAt(0).Length - 4, 4) : creditInfo.ElementAt(0);
            Console.WriteLine("{0,-15}{1,51}", "CARD NUMBER:", $"****-****-****-{creditInfo.ElementAt(0).Substring(creditInfo.ElementAt(0).Length - 4, 4)}");// prints only last four digits of user's credit card for display
            Console.WriteLine("{0,-15}{1,51}", "EXPIRATION:", $"{creditInfo.ElementAt(1)}");
            Console.WriteLine("{0,-15}{1,51}", "APPROVAL CODE:", $"000000");//cosmetic purposes only.
            
        }
    }
}
