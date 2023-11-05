namespace WebAppRESTAPI.Models
{
    public class Product : BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HandlerByRole { get; set; }
        public string Category { get; set; }
        public string AuthorUrl { get; set; }
        public string CategoryUrl { get; set; }

    }
}
