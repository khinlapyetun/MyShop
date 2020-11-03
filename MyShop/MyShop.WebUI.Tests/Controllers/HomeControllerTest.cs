using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()

        {
            //Setup
            IRespository<Product> ProductContext = new Mocks.MockContext<Product>();
            IRespository<ProductCategory> ProductCategoryContext = new Mocks.MockContext<ProductCategory>();
           

            //Act
            ProductContext.Insert(new Product());
            HomeController controller = new HomeController(ProductContext, ProductCategoryContext);
            var result = controller.Index() as ViewResult;
            var viewmodel = (ProductListViewModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(1, viewmodel.Products.Count());
        }
    }
}
