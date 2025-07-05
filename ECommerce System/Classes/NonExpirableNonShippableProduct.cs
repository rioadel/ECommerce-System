using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class NonExpirableNonShippableProduct : Product
    {
        public NonExpirableNonShippableProduct(string name, decimal price, int quantity) : base(name, price, quantity)
        {
            
        }
    }
}
