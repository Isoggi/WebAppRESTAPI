using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppRESTAPI.Models
{
    [Table("Company")]
    public class Company : BaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
