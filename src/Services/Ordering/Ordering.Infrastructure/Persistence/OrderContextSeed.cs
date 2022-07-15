using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguresOrders());
                await orderContext.SaveChangesAsync();

                logger.LogInformation("Seed database associated with context {DBContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguresOrders()
        {
            return new List<Order>
            {
                new Order(){ UserName="swn", FirstName ="Ernesto", LastName="Cardenas", EmailAddress="alguna@deporahi.com", Country="Mexico"}
            };
        }
    }
}
