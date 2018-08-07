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
            List<Product> menuList = new List<Product>(); // Creates a list of products to store the menu inside
            ReadFromText(menuList); // Adds products from text file into the menu list
            Receipt receipt = new Receipt(); // Creates receipt to print at end of transaction
            ShoppingCart shoppingCart = new ShoppingCart(); // Creates shopping cart to store selections and prices for the transaction

            while (true) // Endless loop to handle any number of transactions
            {
                Console.WriteLine("Welcome to C#ffee.Drink();!"); // End user salutation
                Console.WriteLine();
                Product.DisplayMenu(menuList); // Displays menu from text file with numbered options

                // Stores user choice to reference that index of the menu list
                int orderChoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count); //initializes 'orderchoice' and validates end user selection from menu
                shoppingCart.Names.Add(menuList[orderChoice - 1].Name); // adds user choice name to shoppingCart
                shoppingCart.Price.Add(menuList[orderChoice - 1].Price);// adds user choice price to shoppingCart - written sequentially to ensure index number alignment

                int quant = Validator.ChoiceQuantityValidator($"{menuList[orderChoice - 1].Name}: How many would you like?", "That was not a valid quantity, please enter a number.");
                shoppingCart.Quantity.Add(quant); // adds quantity user selected to shoppingCart

                // Prints line total for user's item selection multiplied by the price of that product
                Console.WriteLine($"{shoppingCart.Quantity[shoppingCart.Quantity.Count - 1]} {shoppingCart.Names[shoppingCart.Names.Count - 1]} will be {(shoppingCart.Price[shoppingCart.Price.Count - 1] * shoppingCart.Quantity[shoppingCart.Quantity.Count - 1]):C}");

                bool choice1 = true;
                while (choice1) // loop that repeats while user wants to order additional items
                {
                    string input = Validator.AddOrPayChoiceValidator("Do you want to order additional items or checkout?", "That is not a valid choice. Please try again.");

                    if (input == "1")
                    {
                        Product.DisplayMenu(menuList); // re-displays entire menu if user chooses to order additional items
                        orderChoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);
                        // re-initializes 'orderchoice' 


                        if (shoppingCart.Names.Contains(menuList[orderChoice - 1].Name)) 
                        {// if the new item is already in the user's shoppingCart, the new quantity will be added to the initial value
                            int quant2 = Validator.ChoiceQuantityValidator($"{menuList[orderChoice - 1].Name}: How many would you like?", "That was not a valid quantity, please enter a number.");
                            int repeatIndex = shoppingCart.Names.IndexOf(menuList[orderChoice - 1].Name);
                            shoppingCart.Quantity[repeatIndex] += quant2;
                            Console.WriteLine($"{quant2} {shoppingCart.Names[repeatIndex]} will be {(shoppingCart.Price[repeatIndex] * quant2):C}");
                        }
                        else
                        {// new item name, price, and quantity are added to shoppingCart
                            shoppingCart.Names.Add(menuList[orderChoice - 1].Name);
                            shoppingCart.Price.Add(menuList[orderChoice - 1].Price);
                            int quant2 = Validator.ChoiceQuantityValidator($"{menuList[orderChoice - 1].Name}: How many would you like?", "That was not a valid quantity, please enter a number.");
                            shoppingCart.Quantity.Add(quant2);
                            Console.WriteLine($"{shoppingCart.Quantity[shoppingCart.Quantity.Count - 1]} {shoppingCart.Names[shoppingCart.Names.Count - 1]} will be {(shoppingCart.Price[shoppingCart.Price.Count - 1] * shoppingCart.Quantity[shoppingCart.Quantity.Count - 1]):C}");
                        }

                    }
                    else if (input == "2")
                    {// if user chooses not to add additional items, the loop ends
                        choice1 = false;
                    }
                    else
                    {// some additional validation
                        Console.WriteLine("That is not a valid choice. Please try again.");
                    }
                }
                //receipt info added to receipt created at line 16
                receipt.Subtotal = Receipt.CalcSubTotal(shoppingCart);
                receipt.Tax = Receipt.CalcSalesTax(receipt.Subtotal);
                receipt.GrandTotal = Receipt.CalcGrandTotal(receipt.Subtotal, receipt.Tax);

                // formatted lines to print subtotal, tax, and grand total
                Console.WriteLine("==============================");
                Console.WriteLine("{0,-15}{1,15}", $"Subtotal: ", $"{receipt.Subtotal:C}");
                Console.WriteLine("{0,-15}{1,15}", "6% State Tax:", $"{receipt.Tax:C}");
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0,-15}{1,15}", "Grand total: ", $"{receipt.GrandTotal:C}");
                Console.WriteLine("==============================");

                Console.WriteLine("Would you like to pay via:");
                Console.WriteLine("(1) cash");
                Console.WriteLine("(2) check");
                Console.WriteLine("(3) credit card");

                // asks user for their payment choice, and runs through an if/else if/else statement depending on their choice
                string payChoice = Validator.PaymentChoiceValidator("Choose 1, 2, or 3", "Please choose a valid number from the list.");

                if (payChoice == "1") // cash payment
                {
                    double cashTender = CashPayment(receipt); // method asks for cash tendered that must be equal to or greater than the grand total
                    Receipt.PrintCashReceipt(shoppingCart, receipt, cashTender); // prints receipt with cash tendered and change
                }
                else if (payChoice == "2")
                {
                    string checkNum = CheckPayment();// asks for checknumber to initialize checkNum
                    Receipt.PrintCheckReceipt(shoppingCart, receipt, checkNum); // prints receipt info which includes checkNum
                }
                else
                {
                    List<string> creditInfo = new List<string>();// creates new string for creditInfo
                    creditInfo = CreditCardPayment();// asks for three items- credit card number, expiration date, and cvv code
                    Receipt.PrintCreditReceipt(shoppingCart, receipt, creditInfo); // prints receipt info and includes "masked" credit info
                }

                Console.ReadKey(); // Waits with reciept printed until a key is pressed before clearing the screen

                // clears shopping cart and console text before loop restarts for new transaction
                shoppingCart.Names.Clear();
                shoppingCart.Price.Clear();
                shoppingCart.Quantity.Clear();
                Console.Clear();
            }

        }

        public static void ReadFromText(List<Product> menuList)
        {
            StreamReader reader = new StreamReader("../../Products.txt");

            List<string> stringList = new List<string>();
            string nextLine = reader.ReadLine(); //reads one line at a time.

            while (nextLine != null) // continues while not at end of file
            {
                stringList.Add(nextLine);
                nextLine = reader.ReadLine();
            }

            foreach (string item in stringList)
            {
                string[] info = item.Split(';'); // splits each line into name, category, description, and price

                Product temp = new Product(info[0], info[1], info[2], double.Parse(info[3])); // creates temp product object to add to the menu
                menuList.Add(temp); // adds temp object into the menu
            }

            reader.Close();


        }

        
        public static double CashPayment(Receipt receipt)
        {
            while (true) // continues while cash amount is not enough to pay for transaction
            {
                // validates user input to only be numbers in price format
                double cashTender = Validator.CashTenderValidator("Please enter cash payment equivalent to the grand total.", "This is not valid input. Please try again");

                // checks if number is enough to pay for the transaction
                if (cashTender > receipt.GrandTotal)
                {
                    receipt.Change = cashTender - receipt.GrandTotal; // stores change in receipt object to print at end of transaction
                    return cashTender;
                }
                else if ($"{cashTender.ToString():C}" == $"{receipt.GrandTotal.ToString():C}")
                {
                    // message printed when paid exact change
                    Console.WriteLine("You paid the total amount of your order.");
                    return cashTender;
                }
                else // less than grand total entered
                {
                    Console.WriteLine("You did not pay enough. Please re-enter the amount equal to or greater than the grand total.");
                }
            }
        }

        /// <summary>
        /// asks user for check number input, sends it to checknumbervalidator method.
        /// if not valid, displays invalid input message. saves validated check user input to a string.
        /// </summary>
        /// <returns>returns validated input.</returns>
        public static string CheckPayment()
        {
            string checkNum = Validator.CheckNumberValidator("Please enter your check number.", "This is not a valid check number. Please try again.");
            return checkNum;
        }

        /// <summary>
        /// asks user for credit card number, expiration date number, and cvv number; sends each input to individual validation methods. saves each validated 
        /// input to a string. adds validated string inputs for ccNum and expNum to a new list.
        /// </summary>
        /// <returns>returns list of strings.</returns>
        public static List<string> CreditCardPayment()
        {// adding values to creditInfo list w/ validation for each input
            string ccNum = Validator.CreditCardNumberValidator("Please enter your 16 digit credit card number.", "That is not a valid card number. Please enter the credit card number without any special characters.");
            string expNum = Validator.CreditCardExpirationValidator("Please enter your expiration date (MM/YY).", "That is not a valid expiration date.", "Your card has expired. Please try again.");
            string cvvNum = Validator.CreditCardCVVValidator("Please enter your 3-4 digit CVV Code.", "That is not a valid CVV code. Please try again.");

            List<string> creditInfo = new List<string>();
            creditInfo.Add(ccNum);
            creditInfo.Add(expNum);

            return creditInfo;
        }
    }
}
