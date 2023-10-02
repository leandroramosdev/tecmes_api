using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using TecmesAPI.Models;
using TecmesAPI.Services.Interfaces;

namespace TecmesAPI.Tests.Controllers;

public class ProductsControllerTest
{
    private readonly IProductService _productService;

    public ProductsControllerTest()
    {
        _productService = A.Fake<IProductService>();
    }

    [TestCase]
    public void getAllProducts()
    {
        var products = A.Fake<List<Product>>();
        A.CallTo(() => _productService.getAllProducts()).Returns(products);
        Assert.NotNull(products);
    }

    [Test]
    public void addProduct()
    {
        var product = A.Fake<Product>();
        product.Name = "Produto Teste";
        A.CallTo(() => _productService.addProduct(product)).Returns(product);

        Assert.NotNull(product.Id);
        Assert.IsInstanceOf<Product>(product);
    }
}

