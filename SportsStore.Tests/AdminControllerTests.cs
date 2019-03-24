using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;
namespace SportsStore.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            // Przygotowanie — tworzenie imitacji repozytorium.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
            }.AsQueryable<Product>());
            // Przygotowanie — utworzenie kontrolera.
            AdminController target = new AdminController(mock.Object);
            // Działanie.
            Product[] result =
                GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();
            // Asercje.
            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Product()
        {
            // Przygotowanie — tworzenie imitacji repozytorium.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
            }.AsQueryable<Product>());
            // Przygotowanie — utworzenie kontrolera.
            AdminController target = new AdminController(mock.Object);
            // Działanie.
            Product p1 = GetViewModel<Product>(target.Edit(1));
            Product p2 = GetViewModel<Product>(target.Edit(2));
            Product p3 = GetViewModel<Product>(target.Edit(3));
            // Asercje.
            Assert.Equal(1, p1.ProductId);
            Assert.Equal(2, p2.ProductId);
            Assert.Equal(3, p3.ProductId);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Przygotowanie — tworzenie imitacji repozytorium.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
            }.AsQueryable<Product>());
            // Przygotowanie — utworzenie kontrolera.
            AdminController target = new AdminController(mock.Object);
            // Działanie.
            Product result = GetViewModel<Product>(target.Edit(4));
            // Asercje.
            Assert.Null(result);
        }
    }
}