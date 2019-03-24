using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class FakeProductRepository 
    {
        public IQueryable<Product> Products => new List<Product> {
            new Product { Name = "Piłka nożna", Price = 25 },
            new Product { Name = "Deska surfingowa", Price = 179 },
            new Product { Name = "Buty do biegania", Price = 95 }
        }.AsQueryable<Product>();
    }
}
