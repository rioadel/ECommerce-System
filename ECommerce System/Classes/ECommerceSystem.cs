using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class ECommerceSystem
    {
        private ShippingService shippingService;

        public ECommerceSystem()
        {
            shippingService = new ShippingService();
        }

        public void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new Exception("Cart is empty");

            foreach (var cartItem in cart.items)
            {
                if (!cartItem.Product.IsAvailable(cartItem.Quantity))
                {
                    if (cartItem.Product is IExpirable expirable && expirable.IsExpired())
                        throw new Exception($"Product '{cartItem.Product.Name}' has expired");
                    else
                        throw new Exception($"Product '{cartItem.Product.Name}' is out of stock");
                }
            }

            var shippableItems = new List<IShippable>();
            foreach (var cartItem in cart.items)
            {
                if (cartItem.Product is IShippable shippable)
                {
                    for (int i = 0; i < cartItem.Quantity; i++)
                    {
                        shippableItems.Add(shippable);
                    }
                }
            }

            decimal shippingFee = shippingService.CalculateShippingFee(shippableItems);
            decimal totalPrice = cart.GetSubtotal() + shippingFee;

            if (customer.Balance < totalPrice)
                throw new Exception($"{customer.Name}: your balance is not enough");

            shippingService.ProcessShipment(shippableItems);

            foreach (var cartItem in cart.items)
            {
                cartItem.Product.ReduceQuantity(cartItem.Quantity);
            }

            customer.Pay(totalPrice);

            Console.WriteLine("** Checkout receipt **");
            foreach (var cartItem in cart.items)
            {
                Console.WriteLine($"{cartItem.Quantity} x {cartItem.Product.Name} {cartItem.GetTotalPrice()}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {cart.GetSubtotal()}");
            Console.WriteLine($"Shipping {shippingFee}");
            Console.WriteLine($"Amount {totalPrice}");
            Console.WriteLine($"Balance of {customer.Name} after payment: {customer.Balance}");
        }
    }
}
