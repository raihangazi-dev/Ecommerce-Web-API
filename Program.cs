var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpsRedirection();

List<Category> Categories = new List<Category>();

app.MapPost("/api/Categories", () => {
    var newCategory = new Category
    {
        // CategoryId = Guid.NewGuid(),
        CategoryId = Guid.Parse("46744a8f-1d01-4764-9b45-fc2be2c24c5a"),
        CategoryName = "Phone",
        Description = "Description of Phone",
        CreatedAt = DateTime.UtcNow,

    };
    Categories.Add(newCategory);
    return Results.Created($"/api/Categories/{newCategory.CategoryId}", newCategory);
});
app.MapGet("/api/Categories", () => Results.Ok(Categories));
app.MapDelete("/api/Categories", () => {
    var foundCategory = Categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("46744a8f-1d01-4764-9b45-fc2be2c24c5a"));
    if (foundCategory == null)
    {
        return Results.NotFound("Category does not exist with this id");
    }
    else
    {
         Categories.Remove(foundCategory);
    }
    return Results.NoContent();
});

app.MapPut("/api/Categories", () => {
    var foundCategory = Categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("46744a8f-1d01-4764-9b45-fc2be2c24c5a"));
    if (foundCategory == null)
    {
        return Results.NotFound("Category does not exist with this id");
    }
    
        foundCategory.CategoryName = "Smart Phone";
        foundCategory.Description = "Smart Phone Description";
        foundCategory.CreatedAt = DateTime.UtcNow;
    
    return Results.NoContent();
});

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
