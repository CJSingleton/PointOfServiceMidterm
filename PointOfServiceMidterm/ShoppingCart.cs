﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfServiceMidterm
{
    class ShoppingCart
    {

        // Properties

        public List<string> Names { set; get; }
        public List<double> Price { set; get; }
        public List<int> Quantity { set; get; }
        
        // Constructor
        public ShoppingCart()
        {
            Names = new List<string>();
            Price = new List<double>();
            Quantity = new List<int>();

        }


    }
}
