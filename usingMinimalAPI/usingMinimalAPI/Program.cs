using usingMinimalAPI.Services;
using usingMinimalAPI.Services.DataTransferObjects.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();
//builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", (IProductService service) =>
{
    return service.GetProducts();
});

app.MapGet("/products/{id}", (IProductService service, int id) =>
{
    return service.GetProductById(id);
});

app.MapGet("/products/search/{name}", (IProductService service, string name) => service.Search(name));

app.MapPost("/products", (IProductService service, CreateProductRequest request) =>
{
    int id = service.Create(request);
    return Results.Created($"/products/{id}", null);
});


app.Run();

