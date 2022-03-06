using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Repositories;

namespace GrpcService.Services;

public class CustomerService : Customer.CustomerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public override async Task<GetByIdResponse> GetById(GetByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"The client is asking for customer with id {request.Id}");

        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Customer not found!"));
        }

        return new GetByIdResponse
        {
            Customer = new CustomerData
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Age = customer.Age,
                Vip = customer.Vip
            },
            Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
        };
    }

    public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
    {
        _logger.LogInformation("The client is asking for all the customers");

        var customers = await _customerRepository.GetAllAsync();

        var response = new GetAllResponse
        {
            Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
        };

        foreach (var customer in customers)
        {
            response.Customers.Add(new CustomerData
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Age = customer.Age,
                Vip = customer.Vip
            });
        }

        return response;
    }
}
