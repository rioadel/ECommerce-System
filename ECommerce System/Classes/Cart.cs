using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class Cart
    {
        public List<CartItem> items { get; }

        public Cart()
        {
            items = new List<CartItem>();
        }

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantity must be greater than zero");

            if (!product.IsAvailable(quantity))
            {
                if (product is IExpirable expirable && expirable.IsExpired())
                    throw new Exception($"'{product.Name}' has expired");
                else
                    throw new Exception($"Quantity of '{product.Name}' is not enough");
            }

            var existingItem = items.FirstOrDefault(item => item.Product == product);

            if (existingItem != null)
            {
                var totalQuantity = existingItem.Quantity + quantity;

                if (!product.IsAvailable(totalQuantity))
                    throw new Exception($"Quantity of '{product.Name}' is not enough");

                existingItem.Quantity = totalQuantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }
        public void Clear() => items.Clear();

        public bool IsEmpty() => items.Count == 0;

        public decimal GetSubtotal() => items.Sum(item => item.GetTotalPrice());


    }
}
