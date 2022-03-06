using GrpcService.Repositories;
using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("https://localhost:5000");

app.MapGrpcService<CustomerService>();

app.Run();
