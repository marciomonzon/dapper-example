using DapperExample.Application.Dtos;

namespace DapperExample.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> AddCustomerAsync(CustomerDto customer);
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task<bool> UpdateCustomerAsync(CustomerDto customer);
        Task<bool> DeleteCustomerAsync(CustomerDto customer);
    }
}
