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
        var connectionStringTemplate = configuration.GetConnectionString("PostgresConnectionString")!;
        string connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"))
            .Replace("$POSTGRES_DATABASE", Environment.GetEnvironmentVariable("POSTGRES_DATABASE"))
            .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT"))
            .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"));

        connection = new NpgsqlConnection(connectionString);
    }
}
