
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using BookStoreApi.Model;
using BookStoreApi.SqlConnectionFactory;

namespace BookStoreApi.Repositories
{
    public class BookRepositoryDapper : Dapper_DbContext
    {
        private readonly string _connectionString;

        public BookRepositoryDapper(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync()
        {
            return await QueryBooksAsync("EXEC GetBooksSortedByPublisher");
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync()
        {
            return await QueryBooksAsync("EXEC GetBooksSortedByAuthor");
        }


    }
}
