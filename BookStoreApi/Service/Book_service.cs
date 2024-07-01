
using BookStoreApi.DataTranferObjects.Client_Response;
using BookStoreApi.DataTranferObjects;
using BookStoreApi.Helper;
using BookStoreApi.Model;
using BookStoreApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Service
{
    public interface IBook_service
    {
        Task<List<BookCreateResponse>> Create_book(IEnumerable<Book_details_create_request> requests);
        Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync_service();

        Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync_service();

        Task<decimal> GetTotalPriceAsync_service();

    }

    public class Book_service : IBook_service
    {
        private readonly IBookRepository _IBookRepository;
        public Book_service(IBookRepository bookRepository)
        {
            _IBookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync_service()
        {
            return await _IBookRepository.GetBooksSortedByPublisherAsync();

        }
        public async Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync_service()
        {
            return await _IBookRepository.GetBooksSortedByAuthorAsync();
        }

        public async Task<decimal> GetTotalPriceAsync_service()
        {
            return await _IBookRepository.GetTotalPriceAsync();
        }

        public async Task<List<BookCreateResponse>> Create_book(IEnumerable<Book_details_create_request> requests)
        {
            var BookList = new List<Book>();

            var Book_List_Response = new List<BookCreateResponse>();

            foreach (var request in requests)
            {
                var book = new Book
                {
                    Id = Util.GenerateUniqueCode(),
                    Publisher = request.Publisher,
                    Title = request.Title,
                    AuthorLastName = request.AuthorLastName,
                    AuthorFirstName = request.AuthorFirstName,
                    Price=request.Price,
                    MlaCitation = $"{request.AuthorLastName}, {request.AuthorFirstName}. {request.Title}. {request.Publisher}, {DateTime.Now.Year}.",
                    ChicagoCitation = $"{request.AuthorLastName}, {request.AuthorFirstName}. {request.Title}. {request.Publisher}, {DateTime.Now.Year}."

                };
                var InsertBook = await _IBookRepository.SaveBooksAsync(book);

                if (InsertBook != null)
                {
                    var response = new BookCreateResponse(InsertBook.Id, InsertBook.Publisher, InsertBook.Title, InsertBook.AuthorLastName, InsertBook.AuthorFirstName, InsertBook.Price);

                    Book_List_Response.Add(response);
                }
                else
                {
                    return null;
                }

            }

            return Book_List_Response.Count == 0 ? null : Book_List_Response;


        }

    }
}





