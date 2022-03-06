using GrpcClient;
using Grpc.Net.Client;
using System.Text.Json;
using Grpc.Core;

using var channel = GrpcChannel.ForAddress("https://localhost:5000");
var client = new Customer.CustomerClient(channel);

// GetByIdAsync
try
{
    var id = 1;
    var getByIdResponse = await client.GetByIdAsync(new GetByIdRequest { Id = id });
    Console.WriteLine($"Customer {id}: {JsonSerializer.Serialize(getByIdResponse.Customer)}");
    Console.WriteLine($"DateTime: {getByIdResponse.Timestamp.ToDateTime()}");
}
catch (RpcException ex)
{
    Console.WriteLine(ex.Message);
}

// GetAll
Console.WriteLine("\nAll customers:");
var getAllResponse = await client.GetAllAsync(new GetAllRequest());
getAllResponse.Customers.ToList().ForEach(customer => Console.WriteLine(customer));
Console.WriteLine($"DateTime: {getAllResponse.Timestamp.ToDateTime()}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();