namespace WebAppRESTAPI.Models
{
    public class ProductCategory : BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
