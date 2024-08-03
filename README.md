# ASP.NET API With Dapper
<p>
  EntityFramework Core is a very popular ORM and probably the favourite in .NET community.
  But there is also other ORM non less popular than EF Core and its has a great perfomance, called Dapper.
</p>
<p>
  I cannot ensure that's its perfomance is greater than EF Core, but I can ensure that is very easy to implement and maintain,
  because you can write SQL "as it" and also provides to the developer the ability to write complex queries.
</p>

## Advandages
* It is an ORM;
* Open-source;
* .NET and .NET Core full Compatibility;
* Execute Raw SQL Queries and Stored Procedures;
* Great perfomance;
* Supports parameterized queries to protect againts SQL injection attacks.

## Example Project
<p>
  This project developed as an example, has an ASP.NET API which has Customers CRUD endpoints.
</p>

## Technical Information
* ASP.NET Core;
* .NET 8;
* Dapper;
* Repository Pattern;
* SQL Server in Docker.

## Examples
<p>
  Some examples of the code below
</p>

* Easy to Add and is a parameterized query:

```ruby
public async Task<int> AddAsync(Customer entity)
{
    var sql = "insert into Customer(Name, Email) values (@Name, @Email)";
    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
    {
        connection.Open();
        var result = await connection.ExecuteAsync(sql, entity);

        return result;
    }
}
```


## Diagram

![image](https://github.com/user-attachments/assets/ab80f577-5034-41d3-a5cd-bf3b9c835eaa)


## Docker Commands
* Pull latest Image of SQL Server version: docker pull mcr.microsoft.com/mssql/server
* Run Image in Windows: docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=p@ssw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server
* Run Image Winfows/WSL 2: docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=p@ssw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server
