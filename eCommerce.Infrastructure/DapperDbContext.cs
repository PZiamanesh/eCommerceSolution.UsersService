using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure;

public class DapperDbContext
{
    private readonly IConfiguration configuration;
    private readonly IDbConnection connection;

    public IDbConnection DbConnection => connection;

    public DapperDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
        var connectionString = configuration.GetConnectionString("Postgres");

        connection = new NpgsqlConnection(connectionString);
    }
}
