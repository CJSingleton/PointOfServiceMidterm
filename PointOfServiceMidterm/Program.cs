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


    }
}
