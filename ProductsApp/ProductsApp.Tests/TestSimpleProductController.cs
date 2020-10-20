using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApp.Controllers;
using ProductsApp.Models;

namespace ProductsApp.Tests
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);
            var result = controller.GetAllProducts() as Product[];
            Assert.AreEqual(testProducts.Length, result.Length);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);
            var result = controller.GetProduct(4) as
           OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProductsController(GetTestProducts());
            var result = controller.GetProduct(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private Product[] GetTestProducts()
        {
            var testProducts = new Product[]
            {
                new Product { Id = 1, Name = "Demo1", Price = 1 },
                new Product { Id = 2, Name = "Demo2", Price = 3.75M },
                new Product { Id = 3, Name = "Demo3", Price = 16.99M },
                new Product { Id = 4, Name = "Demo4", Price = 11.00M }
            };
            return testProducts;
        }
    }
}