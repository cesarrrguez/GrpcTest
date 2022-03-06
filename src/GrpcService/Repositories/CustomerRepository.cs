using GrpcService.Models;

namespace GrpcService.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<CustomerModel> _customers = new()
    {
        new(1, "Jim", "Carrey", "jim@carrey.com", 60, true),
        new(2, "Johnny", "Depp", "johnny@depp.com", 58, true),
        new(3, "Tom", "Hanks", "tom@hanks.com", 65, false),
        new(4, "Will", "Smith", "will@smith.com", 53, false),
    };

    public async Task<CustomerModel?> GetByIdAsync(int id)
    {
        await Task.Delay(1000);
        return _customers.SingleOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        await Task.Delay(1000);
        return _customers;
    }
}
