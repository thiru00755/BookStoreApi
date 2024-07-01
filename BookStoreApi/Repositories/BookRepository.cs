using BookStoreApi.DataTranferObjects;
using BookStoreApi.DataTranferObjects.Client_Response;
using BookStoreApi.Helper;
using BookStoreApi.Model;
using BookStoreApi.SqlConnectionFactory;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync();
        Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync();
        Task<decimal> GetTotalPriceAsync();
        Task<Book> SaveBooksAsync(Book requests);
    }

    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync()
        {
            return await _context.Book
                .OrderBy(b => b.Publisher)
                .ThenBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync()
        {
            return await _context.Book
                .OrderBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPriceAsync()
        {
            return await _context.Book.SumAsync(b => b.Price);
        }



        public async Task<Book> SaveBooksAsync(Book requests)
        {
            try
            {
                await _context.Book.AddAsync(requests);

                await _context.SaveChangesAsync();

                return requests ?? null;
            }
            catch
            {
                return null;
            }

        }


    }
}

