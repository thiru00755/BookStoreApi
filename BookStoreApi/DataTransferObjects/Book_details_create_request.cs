namespace BookStoreApi.DataTranferObjects
{
    public class Book_details_create_request
    {
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
    }
}
