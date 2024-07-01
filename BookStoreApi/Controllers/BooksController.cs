using BookStoreApi.DataTranferObjects;
using BookStoreApi.DataTranferObjects.Client_Response;
using BookStoreApi.Model;
using BookStoreApi.Repositories;
using BookStoreApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {


        private readonly IBook_service _IBook_service;
        private readonly IBook_Dapper_service _IBook_Dapper_service;
        public BooksController(IBook_service book_service, IBook_Dapper_service book_Dapper_service)
        {
            _IBook_service = book_service;
            _IBook_Dapper_service = book_Dapper_service;

        }

        [HttpGet("sorted_by_publisher")]
        public async Task<IActionResult> GetBooksSortedByPublisher()
        {
            var books = await _IBook_service.GetBooksSortedByPublisherAsync_service();
            return Ok(books);
        }

        [HttpGet("sorted_by_author")]
        public async Task<IActionResult> GetBooksSortedByAuthor()
        {
            var books = await _IBook_service.GetBooksSortedByAuthorAsync_service();
            return Ok(books);
        }

        [HttpGet("total_price")]
        public async Task<IActionResult> GetTotalPrice()
        {
            var totalPrice = await _IBook_service.GetTotalPriceAsync_service();
            return Ok(totalPrice);
        }

        [HttpPost("save_books")]
        public async Task<ActionResult<List<BookCreateResponse>>> SaveBooks([FromBody] IEnumerable<Book_details_create_request> Client_request)
        {
            var result = await _IBook_service.Create_book(Client_request);

            return result != null ? Ok(result) : BadRequest();
        }


        [HttpGet("sorted_by_publisher_dapper")]
        public async Task<IActionResult> GetBooksSortedByPublisherDapper()
        {
            var books = await _IBook_Dapper_service.GetBooksSortedByPublisher();
            return Ok(books);
        }

        [HttpGet("sorted_by_author_dapper")]
        public async Task<IActionResult> GetBooksSortedByAuthorDapper()
        {
            var books = await _IBook_Dapper_service.GetBooksSortedByAuthor();
            return Ok(books);
        }
    }
}
