
using BookStoreApi.Model;
using BookStoreApi.Repositories;

namespace BookStoreApi.Service
{
    public interface IBook_Dapper_service
    {
        Task<IEnumerable<Book>> GetBooksSortedByPublisher();
        Task<IEnumerable<Book>> GetBooksSortedByAuthor();

    }
    public class Book_Dapper_service : IBook_Dapper_service
    {
        private readonly BookRepositoryDapper _bookRepository;
        public Book_Dapper_service(BookRepositoryDapper bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetBooksSortedByPublisher()
        {
            return await _bookRepository.GetBooksSortedByPublisherAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByAuthor()
        {
            return await _bookRepository.GetBooksSortedByAuthorAsync();
        }
    }
}
