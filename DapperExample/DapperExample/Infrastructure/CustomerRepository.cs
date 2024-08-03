using Dapper;
using DapperExample.Domain;
using DapperExample.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DapperExample.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Customer entity)
        {
            var sql = "insert into Customers(Name, Email) values (@Name, @Email)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });

                return result;
            }
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            var sql = "SELECT Id, Name, Email FROM Customers";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Customer>(sql);

                return result.ToList();
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var sql = "SELECT Id, Name, Email FROM Customers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var result = await connection
                                   .QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });

                return result;
            }
        }

        public async Task<int> UpdateAsync(Customer entity)
        {
            var sql = "UPDATE Customers SET Name = @Name, Email = @Email WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }
    }
}
