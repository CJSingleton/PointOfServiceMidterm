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

            //Product prod1 = new Product("1) Tomato & Mozzarella Sandwich", "Food:", "Baked tomatoes with melted mozzarella on toasted Halal bread.", 11.50);
            //Product prod2 = new Product("2) Chicken BLT Sandwich", "Food:", "Grilled chicken with lettuce, tomato, and honey maple bacon on toasted rye bread.", 12.95);
            //Product prod3 = new Product("3) Reduced-Fat TBE Breakfast Sandwich", "Food:", "Reduced-fat thin sliced smoked turkey, maple bacon, and cage-free egg whites on a flakey croissant.", 7.50);
            //Product prod4 = new Product("4) Parmesan Spinach Knots", "Food:", "Fresh spinach baked in flakey buttermilk dough, brushed with a mix of butter, Parmesan, garlic powder, oregano and parsley.", 7.95);
            //Product prod5 = new Product("5) Spiced Apple Pie Cake", "Food:", "Baked with freshly sliced apples and American Buttercream, with hints of cinnamon, nutmeg, and lemon zest.", 5.80);
            //Product prod6 = new Product("6) Chocolate Chip Loaf", "Food:", "Baked soft with buttermilk, hints of vanilla and chocolate chips.", 3.50);
            //Product prod7 = new Product("7) Cafe au Lait", "Drink:", "Hot whole milk, ground cinnamon, vanilla bean extract, sugar, unsweetened honey, orange & lemon zest.", 4.50);
            //Product prod8 = new Product("8) Cortado", "Drink:", "Equal amount of espresso and steamed milk, served in a metal cup.", 5.80);
            //Product prod9 = new Product("9) Cafe Americano", "Drink:", "Espresso and hot water brewed from the same source.", 4.00);
            //Product prod10 = new Product("10) Cold Brew", "Drink:", "Coffee grounds steeped in cold water for 24 hours, filtered, and served cold.", 4.00);
            //Product prod11 = new Product("11) Green Smoothie", "Drink:", "Chopped kale blended with almond milk, frozen banana slices, cinnamon, and hemp, chia, and ground flax seeds.", 8.50);
            //Product prod12 = new Product("12) Hot Chocolate", "Drink:", "Ground cinnamon, unsweetened cocoa beans, vanilla extract, reduced-fat whipped topping. ", 6.50);

            //ListChoiceValidator(string askUser, string errorMessage, string rangeErrorMessage, int listCount)

            // Welcoming message
            Console.WriteLine("Welcome to C#ffee.Drink();!");

            // asking for order
            Validator.ListChoiceValidator("Please place your order when you are ready", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);
            //Console.WriteLine("Please place your order when you are ready.");

            // if not a valid option
            //Console.WriteLine("That option is not available on our menu. Please select again.");

            // after selecting an item
            
            Console.WriteLine("Would you like to order an addtional item off the menu? (y/n)");
            string input = Console.ReadLine().ToLower();
            bool choice1 = true;
            do
            {
                if (input == "y" | input == "yes")
                {
                    Validator.ListChoiceValidator("Please place your order when you are ready (choose a number)", "That option is not available on our menu. Please select again.", "You have selected a number that is not on our menu. Please select again.", menuList.Count);
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

                // after order - do not want additional item **OR** order is done completely
                Console.WriteLine("Thank you for your order! Your total is (total variable here). Would you like to pay with cash, credit card, or check?");
            // have "cash", "credit card/cc", and "check" in validation methods

            // after order - want additional items
            Console.WriteLine("Please make your selection when you're ready.");

            // paying with cash
            Console.WriteLine("You paid (amount here).");

            // paying with cash **CASH/CHANGE BACK**
            Console.WriteLine("You paid (amount here), your change is (change here).");

            // paying with cash **DOES NOT PASS INT VALIDATION
            Console.WriteLine("You're short on payment, please pay with the correct amount.");

            // paying with check
            Console.WriteLine("Your check is written out for (amount here).");

            // paying with check **DOES NOT PASS INT VALIDATION
            Console.WriteLine("Your check number is invalid, please enter the check number again.");

            // paying with credit card
            Console.WriteLine("Your card was run for (amount here).");

            // paying with credit card **DOES NOT PASS INT VALIDATION
            Console.WriteLine("Your credit card number is invalid, please try again.");
            Console.WriteLine("Your expiration date has already passed, please try again.");
            Console.WriteLine("Your CVV number is invalid, please try again.");

            //after payment
            Console.WriteLine("Would you like a receipt?");


	         
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
