using Infrastructure.Services;
namespace ProductServiceTest;
using Infrastructure.Models;

public class ProductServiceTests
{
    private readonly string _testFilePath = "test_products.json";

    [Fact]
    public void CreateProduct_ShouldAddProductToList()
    {
        // Rensa testfilen innan testet
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);

        // Arrange
        var fileService = new FileService(_testFilePath);
        var productService = new ProductService(fileService);

        var productRequest = new ProductCreateRequest
        {
            ProductTitle = "Testprodukt",
            ProductPrice = 99.99m
        };

        // Act
        productService.CreateProduct(productRequest);
        var products = productService.GetAllProducts().ToList();

        // Assert
        Assert.Single(products);
        Assert.Equal("Testprodukt", products[0].ProductTitle);
        Assert.Equal(99.99m, products[0].ProductPrice);
    }
}
