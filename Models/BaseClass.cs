namespace WebAppRESTAPI.Models
{
    
    public class BaseClass
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpodatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
