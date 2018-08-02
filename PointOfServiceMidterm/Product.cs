using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class Product
    {

        private string name;
        private string description;
        private double price;
        private string category;

        public string Name { get; set; }

        private string Category { get; set; }

        public string Description { get; set; }

        private double Price { get; set; }
        
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



    }
}
