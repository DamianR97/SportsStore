using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using Xunit;
namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Przygotowanie.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Jabłka"},
                new Product {ProductId = 2, Name = "P2", Category = "Jabłka"},
                new Product {ProductId = 3, Name = "P3", Category = "Śliwki"},
                new Product {ProductId = 4, Name = "P4", Category = "Pomarańcze"},
            }).AsQueryable<Product>());
            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            // Działanie — pobranie zbioru kategorii.
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();
            // Asercje.
            Assert.True(Enumerable.SequenceEqual(new string[] { "Jabłka",
                "Pomarańcze", "Śliwki" }, results));
        }
    }
}