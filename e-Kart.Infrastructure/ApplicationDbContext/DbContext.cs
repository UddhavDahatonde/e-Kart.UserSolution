using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace e_Kart.Infrastructure.ApplicationDbContext;

public class DbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;
    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}
