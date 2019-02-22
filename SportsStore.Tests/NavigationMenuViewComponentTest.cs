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
                new Product {ProductID = 1, Name = "P1", Category = "Jab³ka"},
                new Product {ProductID = 2, Name = "P2", Category = "Jab³ka"},
                new Product {ProductID = 3, Name = "P3", Category = "Œliwki"},
                new Product {ProductID = 4, Name = "P4", Category = "Pomarañcze"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);

            // Dzia³anie — pobranie zbioru kategorii.
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();

            // Asercje.
            Assert.True(Enumerable.SequenceEqual(new string[] { "Jab³ka", "Pomarañcze", "Œliwki" }, results));
        }
    }
}