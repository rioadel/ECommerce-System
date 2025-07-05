using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; }

        public ShippableProduct(string name, decimal price, int quantity, double weight) : base(name, price, quantity)
        {
            Weight = weight;
        }
    }
}
