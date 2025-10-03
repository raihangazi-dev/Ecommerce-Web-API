var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpsRedirection();

List<Category> Categories = new List<Category>();

app.MapPost("/api/Categories", () => {
    var newCategory = new Category
    {
        CategoryId = Guid.NewGuid(),
        CategoryName = "Phone",
        Description = "Description of Phone",
        CreatedAt = DateTime.UtcNow,

    };
    Categories.Add(newCategory);
    return Results.Created($"/api/Categories/{newCategory.CategoryId}", newCategory);
});
app.MapGet("/api/Categories", () => Results.Ok(Categories));

app.Run();

// CRUD Operation
// DTO
public record Category
{
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
