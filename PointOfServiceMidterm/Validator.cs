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

    }
}
