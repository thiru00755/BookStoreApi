namespace BookStoreApi.DataTranferObjects.Client_Response
{
    public class BookCreateResponse
    {
        public string Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }

        public string MlaCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";
        public string ChicagoCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";

        public BookCreateResponse(string res_id, string res_Publisher, string res_Title, string res_AuthorLastName, string res_AuthorFirstName, decimal res_Price)
        {
            Id = res_id;
            Publisher = res_Publisher;
            Title = res_Title;
            AuthorLastName = res_AuthorLastName;
            AuthorFirstName = res_AuthorFirstName;
            Price = res_Price;
           

        }

    }
}
