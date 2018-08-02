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
            bool globalExit = true;
            while (globalExit)
            {
                bool menuExit = true;
                while (menuExit)
                {
                    //Console.WriteLine("STORE GREETING");
                    //item list
                    //SELECT ITEM -- add to cart?
                    //SELECT QUANTITY -- add to cart?
                    //print total 
                    //exit prompt
                }

                //calculate tax and grand total, save separately.
                //print grand total
                //prompt user for payment method 

                // if cash --> ask for amount received
                // if check --> ask for check number
                // if credit card ask for card number, exp date, and cvv (save in separate variables)

                //Display Receipt to user - has itemized list, line total, grand total, and all payment info*

                //Receipt base class (ArrayList) with three receipt subclasses: 'cash receipt' 'credit receipt' and 'check receipt'

                //Prompt user for exit info
            }
        }
    }
}
