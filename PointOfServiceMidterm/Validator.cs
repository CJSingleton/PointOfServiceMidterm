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
