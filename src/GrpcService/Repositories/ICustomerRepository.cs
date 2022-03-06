using GrpcService.Models;

namespace GrpcService.Repositories;

public interface ICustomerRepository
{
    Task<CustomerModel?> GetByIdAsync(int id);
    Task<IEnumerable<CustomerModel>> GetAllAsync();
}
