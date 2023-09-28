using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }
    //Dapper to talk to SqlDb
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        //Dapper
        //connect to Sql db
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        //execute storeproced, pass parammeters
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        //Dapper
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
