using DapperExample.Domain;
using DapperExample.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _customerRepository.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);

            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Customer customer)
        {
            var data = await _customerRepository.AddAsync(customer);

            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _customerRepository.DeleteAsync(id);

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            var data = await _customerRepository.UpdateAsync(customer);

            return Ok(data);
        }
    }
}
