namespace WebAppRESTAPI.Models
{
    public class Company : BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}
