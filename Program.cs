var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpsRedirection();
var products = new List<Product>() {
    new Product("Iphone 17 PRO Max", 32000),
    new Product("Samsung S23 ULTRA PRO", 29000),
};
app.MapGet("/Products", () =>
{
    return Results.Ok(products);
});


app.Run();

// DTO
public record Product(string Name, decimal Price);
