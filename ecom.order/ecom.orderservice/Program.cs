using Dapr.Client;
using ecom.order.application.Order;
using ecom.order.database.order;
using ecom.order.infrastructure.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IOrderApplication, OrderApplication>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddControllers().AddDapr();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddControllers();

Console.WriteLine($"order Dapr port: {Environment.GetEnvironmentVariable("DAPR_HTTP_PORT")}");
builder.Services.AddDaprClient();
// Using the DAPR SDK to create a DaprClient, in stead of fiddling with URI's our selves
builder.Services.AddSingleton<IProductService>(sc =>
    new ProductService(DaprClient.CreateInvokeHttpClient("product")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());


app.UseAuthorization();

app.MapControllers();

app.Run();

