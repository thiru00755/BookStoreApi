using BookStoreApi.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStoreApi.SqlConnectionFactory
{
    public class Dapper_DbContext
    {
        private readonly string _connectionString;
        public Dapper_DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        private async Task<IDbConnection> GetOpenConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<IEnumerable<Book>> QueryBooksAsync(string query)
        {
            using var connection = await GetOpenConnectionAsync();
            return await connection.QueryAsync<Book>(query);
        }
    }
}
