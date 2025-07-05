using ECommerce_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_System.Classes
{
    public class ShippingService
    {
        private const decimal FeesPerKg = 15; 
        private const decimal BaseFees = 10;   

        public decimal CalculateShippingFee(List<IShippable> shippableItems)
        {
            if (shippableItems == null || shippableItems.Count == 0)
                return 0;

            double totalWeight = shippableItems.Sum(item => item.Weight);
            decimal shippingFee = BaseFees + ((decimal)totalWeight * FeesPerKg);

            return shippingFee;
        }

        public void ProcessShipment(List<IShippable> shippableProducts)
        {
            if (shippableProducts == null || shippableProducts.Count == 0)
                return;


            var groupedItems = shippableProducts
                .GroupBy(item => item.Name)
                .Select(group => new {
                    Name = group.Key,
                    Count = group.Count(),
                    TotalWeight = group.Sum(item => item.Weight)
                });

            Console.WriteLine("** Shipment notice **");

            double totalPackageWeight = 0;

            foreach (var group in groupedItems)
            {
                Console.WriteLine($"{group.Count} x {group.Name} {group.TotalWeight * 1000}g");
                totalPackageWeight += group.TotalWeight;
            }

            Console.WriteLine($"Total package weight {totalPackageWeight:F2}kg");
        }
    }
}
