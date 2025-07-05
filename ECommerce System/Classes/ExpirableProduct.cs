using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class ExpirableProduct : Product, IExpirable
    {
        public DateTime ExpirationDate { get; }

        public ExpirableProduct(string name, decimal price, int quantity, DateTime expirationDate) : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
        }

        public bool IsExpired() => DateTime.Now > ExpirationDate;

        public override bool IsAvailable(int quantity) =>  base.IsAvailable(quantity) && !IsExpired();
        
    }
}
