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

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Names.Add("Tomato Sandwich");
            shoppingCart.Price.Add(9.95);
            shoppingCart.Quantity.Add(5);

            Console.WriteLine($"{shoppingCart.Quantity[0]} {shoppingCart.Names[0]} will be {shoppingCart.Price[0] * shoppingCart.Quantity[0]}.");

            //Console.WriteLine(menuList[0].Name);

            //ListChoiceValidator(string askUser, string errorMessage, string rangeErrorMessage, int listCount)

            // Welcoming message

            while (true)
            {

                Console.WriteLine("Welcome to C#ffee.Drink();!");

                // asking for order



                int orderchoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);


                Console.WriteLine("How many of these would you like to order?");

                Console.WriteLine("Would you like to order addtional items off the menu, or would you like to pay?");
                string input = Console.ReadLine().ToLower();
                bool choice1 = true;
                do
                {
                    if (input == "y" | input == "yes")
                    {
                        orderchoice = Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);

                    }
                    else if (input == "n" | input == "no")
                    {
                        choice1 = false;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice.");
                    }
                } while (choice1 == true);

                Console.WriteLine("Would you like to pay via:");
                Console.WriteLine("(1) cash");
                Console.WriteLine("(2) check");
                Console.WriteLine("(3) credit card");
                string payChoice = Console.ReadLine(); // method goes here

                if (payChoice == "1")
                {
                    CashPayment();
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

            // Console.WriteLine(fileData);

            foreach (string item in stringList)
            {
                string[] info = item.Split(';');

                Product temp = new Product(info[0], info[1], info[2], double.Parse(info[3]));
                menuList.Add(temp);
            }

            reader.Close();


        }

        public static void CashPayment()
        {
            while (true)
            {
                Console.WriteLine("Please enter cash payment equivalent to the grand total.");
                string cashNum = Console.ReadLine(); // validation method goes here

                if (cashNum > grandtotal)
                {
                    Console.WriteLine("Your change is (change here).");
                    break;
                }
                else if (cashNum == grandtotal)
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
            Console.WriteLine("Please enter your check number.");
            string checkNum = Console.ReadLine(); // validation method goes here

        }

        public static void CreditCardPayment()
        {
            Console.WriteLine("Please enter your 16 digit credit card number.");
            string ccNum = Console.ReadLine(); // validation method goes here 

            Console.WriteLine("Please enter your expiration date (MM/YY).");
            string expNum = Console.ReadLine(); // validation method goes here

            Console.WriteLine("Please enter your 3-4 digit CVV code.");
            string cvvNum = Console.ReadLine(); // method goes here
        }


    }
}
