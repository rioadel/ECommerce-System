using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public void Pay(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Balance is not enough");
            Balance -= amount;
        }
    }
}
