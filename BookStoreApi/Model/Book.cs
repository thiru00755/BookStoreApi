
namespace BookStoreApi.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public string MlaCitation { get; set; }
        public string ChicagoCitation { get; set; }
        //public string MlaCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";
        //public string ChicagoCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";
    }
}
