using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce_System.Classes
{
    public class ExpirableShippableProduct : Product , IExpirable, IShippable
    {
        public DateTime ExpirationDate { get; }
        public double Weight { get; }

        public ExpirableShippableProduct(string name, decimal price, int quantity, DateTime expirationDate, double weight) : base(name, price, quantity)  
        {
            ExpirationDate = expirationDate;
            Weight = weight;
        }

        public bool IsExpired() =>  DateTime.Now > ExpirationDate;

        public override bool IsAvailable(int neededQuantity) => base.IsAvailable(neededQuantity) && !IsExpired();
        
    }
}
