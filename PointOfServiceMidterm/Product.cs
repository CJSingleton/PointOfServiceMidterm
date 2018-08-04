using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class Product
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        
        //Constructors

        public Product()// default constructor (no argument constructor)
        {
            Name = "not assigned";
            Category = "not assigned";
            Description = "not assigned";
            Price = 0;
        }

        public Product(string nam, string cat, string desc, double pr)
        {
            Name = nam;
            Category = cat;
            Description = desc;
            Price = pr;
        }

        public static void DisplayMenu(List<Product> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine("{0,-4}{1,-38}{2,-126}{3,10}", $"{i+1}: ", menu[i].Name, menu[i].Description, $"{menu[i].Price:C}");
            }
        }
    }
}
