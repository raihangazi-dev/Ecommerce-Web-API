var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/hello", () =>
{
    return "Get Method: Hello";
});

app.MapGet("/", () =>
{
    return "API is Working";
});
app.MapPost("/hello", () =>
{
    return "POST Method Hello";
});
app.MapPut("/hello", () =>
{
    return "PUT Method Hello";
});
app.MapDelete("/hello", () =>
{
    return "DELETE Method Hello";
});

app.Run();
