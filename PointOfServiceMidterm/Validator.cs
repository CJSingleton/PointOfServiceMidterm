using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class Validator
    {

        /// <summary>
        /// Asks user for input then checks if it's null, if it matches the given regular expression, and if the number is within the range of the list. 
        /// </summary>
        /// <param name="askUser">Question to ask the user</param>
        /// <param name="errorMessage">Message to print if the user's input is null or does not match the regular expression</param>
        /// <param name="rangeErrorMessage">Message to print if user's input is not within the range of the list</param>
        /// <param name="listCount">How many indexes are in the list</param>
        /// <returns>Number input by user as an int</returns>
        public static int ListChoiceValidator(string askUser, string errorMessage, string rangeErrorMessage, int listCount)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{1,9}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else if (int.Parse(userInput) < 1 || int.Parse(userInput) > listCount)
                {
                    Console.WriteLine(rangeErrorMessage);
                }
                else
                {
                    return int.Parse(userInput);
                }
            }
        }

        public static string AddOrPayChoiceValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            Console.WriteLine("1: Order additional items");
            Console.WriteLine("2: Checkout");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^[12]$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static int ChoiceQuantityValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{1,9}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return int.Parse(userInput);
                }
            }
        }

        public static string PaymentChoiceValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^[123]$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static double CashTenderValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{1,9}$|^\d{1,9}.\d{2}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return double.Parse(userInput);
                }
            }
        }

        public static string CreditCardNumberValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{16}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static string CreditCardExpirationValidator(string askUser, string errorMessage, string expiredMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();

                string[] dateParts = userInput.Split('/');
                DateTime expirationDate = DateTime.Parse($"{dateParts[0]}/{"01"}/20{dateParts[1]}");
                expirationDate = expirationDate.AddMonths(1);
                expirationDate = expirationDate.AddSeconds(-1);


                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^([0][1-9]|[1][012])\/(\d\d)$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else if (expirationDate > DateTime.Now)
                {
                    Console.WriteLine(expiredMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static string CreditCardCVVValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{3,4}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static string CheckNumberValidator(string askUser, string errorMessage)
        {
            Console.WriteLine(askUser);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!Regex.IsMatch(userInput, @"^\d{3,10}$"))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        

    }
}
