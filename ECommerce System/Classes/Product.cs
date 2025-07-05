using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public abstract class Product
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public virtual bool IsAvailable(int neededQuantity) => Quantity >= neededQuantity;
        

        public virtual void ReduceQuantity(int amount)
        {
            if (amount > Quantity)
                throw new Exception("Cannot reduce quantity below zero");

            Quantity -= amount;
        }
    }
}
