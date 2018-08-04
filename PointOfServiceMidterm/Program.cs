using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PointOfServiceMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> menuList = new List<Product>();
            ReadFromText(menuList);
            Receipt receipt = new Receipt();
            ShoppingCart shoppingCart = new ShoppingCart();
            
            // Welcoming message

            while (true)
            {
                Console.WriteLine("Welcome to C#ffee.Drink();!");
                Product.DisplayMenu(menuList);
                
                int orderchoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);
                shoppingCart.Names.Add(menuList[orderchoice - 1].Name);
                shoppingCart.Price.Add(menuList[orderchoice - 1].Price);

                Console.WriteLine("How many of these would you like to order?");
                int quant = int.Parse(Console.ReadLine());
                shoppingCart.Quantity.Add(quant);
                
                bool choice1 = true;
                while (choice1)
                {
                    string input = Validator.AddOrPayChoiceValidator("Do you want to order additional items or checkout?","That is not a valid choice. Please try again.");

                    if (input == "1")
                    {
                        orderchoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);
                        shoppingCart.Names.Add(menuList[orderchoice - 1].Name);
                        shoppingCart.Price.Add(menuList[orderchoice - 1].Price);

                        Console.WriteLine("How many of these would you like to order?");
                        int quant2 = int.Parse(Console.ReadLine());
                        shoppingCart.Quantity.Add(quant2);

                        if (shoppingCart.Names.Contains(menuList[orderchoice - 1].Name))
                            {
                            int repeatindex = shoppingCart.Names.IndexOf(menuList[orderchoice - 1].Name);
                            shoppingCart.Quantity[repeatindex] += quant2;
                            }
                    }
                    else if (input == "2")
                    {
                        choice1 = false;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice. Please try again.");
                    }
                }

                receipt.Subtotal = Receipt.CalcSubTotal(shoppingCart);
                receipt.Tax = Receipt.CalcSalesTax(receipt.Subtotal);
                receipt.GrandTotal = Receipt.CalcGrandTotal(receipt.Subtotal, receipt.Tax);

                Console.WriteLine($"Subtotal: {receipt.Subtotal}");
                Console.WriteLine($"Sales tax: {receipt.Tax}");
                Console.WriteLine($"Grand total: {receipt.GrandTotal}");

                Console.WriteLine("Would you like to pay via:");
                Console.WriteLine("(1) cash");
                Console.WriteLine("(2) check");
                Console.WriteLine("(3) credit card");
                
                string payChoice = Validator.PaymentChoiceValidator("Choose 1, 2, or 3", "Please choose a valid number from the list.");// method goes here

                if (payChoice == "1")
                {
                    CashPayment(receipt);
                }
                else if (payChoice == "2")
                {
                    CheckPayment();
                }
                else
                {
                    CreditCardPayment();
                }



                // RECEIPT INFO HERE

                Console.ReadKey();
                shoppingCart.Names.Clear();
                shoppingCart.Price.Clear();
                shoppingCart.Quantity.Clear();
            }
            
        }

        public static void ReadFromText(List<Product> menuList)
        {
            StreamReader reader = new StreamReader("../../Products.txt");

            List<string> stringList = new List<string>();
            string fileData = "";
            string nextLine = reader.ReadLine(); //reads one line at a time.

            while (nextLine != null)//we did not reach the end of the file.
            {
                fileData += nextLine;
                stringList.Add(nextLine);
                nextLine = reader.ReadLine();
            }

            foreach (string item in stringList)
            {
                string[] info = item.Split(';');

                Product temp = new Product(info[0], info[1], info[2], double.Parse(info[3]));
                menuList.Add(temp);
            }

            reader.Close();


        }

        public static void CashPayment(Receipt receipt)
        {
            while (true)
            {
                double cashNum = Validator.CashTenderValidator("Please enter cash payment equivalent to the grand total.", "This is not valid input. Please try again");

                if (cashNum > receipt.GrandTotal)
                {
                    Console.WriteLine("Your change is (change here).");
                    break;
                }
                else if (cashNum == receipt.GrandTotal)
                {
                    Console.WriteLine("You paid the total amount of your order.");
                    break;
                }
                else
                {
                    Console.WriteLine("You did not pay enough. Please re-enter the amount equal to or greater than the grand total.");
                }
            }
        }

        public static void CheckPayment()
        {
            string checkNum = Validator.CheckNumberValidator("Please enter your check number.", "This is not a valid check number. Please try again.");
        }

        public static void CreditCardPayment()
        {
            string ccNum = Validator.CreditCardNumberValidator("Please enter your 16 digit credit card number.","That is not a valid card number. Please try again.");
           
           
            string expNum = Validator.CreditCardExpirationValidator("Please enter your expiration date (MM/YY).", "That is not a valid expiration date.", "Your card has expired. Please try again.");


            string cvvNum = Validator.CreditCardCVVValidator("Please enter your 3-4 digit CVV Code.", "That is not a valid CVV code. Please try again."); 
        }

        
        
    }
}
