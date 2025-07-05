using ECommerce_System.Classes;

namespace ECommerce_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cheese = new ExpirableShippableProduct("Cheese", 150, 30, DateTime.Now.AddDays(30), 0.25); 
            var tv = new ShippableProduct("TV", 5000, 5, 2.5); 
            var scratchCard = new NonExpirableNonShippableProduct("Mobile Scratch Card", 50, 20);
            var biscuits = new ExpirableShippableProduct("Biscuits", 90, 8, DateTime.Now.AddDays(30), 0.7); 
            var customer = new Customer("Mario Maximous", 12000);
            var cart = new Cart();
            var ecommerce = new ECommerceSystem();


            #region Test Case 1
            Console.WriteLine("=== Test Case 1: Normal Checkout ===");
            cart.Add(cheese, 2);
            cart.Add(tv, 1);
            cart.Add(scratchCard, 1);
            cart.Add(biscuits, 1);
            Console.WriteLine($"Balance of {customer.Name}: {customer.Balance}");
            ecommerce.Checkout(customer, cart);
            Console.WriteLine();
            #endregion

            #region Test Case 2
            Console.WriteLine("=== Test Case 2: Empty Cart ===");
            var emptyCart = new Cart();
            try
            {
                ecommerce.Checkout(customer, emptyCart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine();
            #endregion


            #region Test Case 3
            Console.WriteLine("=== Test Case 3:  Balance is no Enough ===");
            var poorCustomer = new Customer("Abdo Badr", 10);
            var expensiveCart = new Cart();
            expensiveCart.Add(tv, 2);
            try
            {
                ecommerce.Checkout(poorCustomer, expensiveCart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine();
            #endregion

            #region Test Case 4
            Console.WriteLine("=== Test Case 4: Expired Product ===");
            var expiredCheese = new ExpirableShippableProduct("Cheddar Cheese", 100, 5, DateTime.Now.AddDays(-1), 0.2);
            var expiredCart = new Cart();
            try
            {
                expiredCart.Add(expiredCheese, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine();
            #endregion

            #region Test Case 5
            Console.WriteLine("=== Test Case 5: Out of Stock ===");
            var outOfStockCart = new Cart();
            try
            {
                outOfStockCart.Add(tv, 10); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            } 
            #endregion
        }
    }
}
