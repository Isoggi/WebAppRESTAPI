﻿namespace WebAppRESTAPI.Models
{
    public class Product : BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? HandlerId { get; set; }
        public string? CategoryId { get; set; }
        public string? ContactPerson { get; set; }
    }
}
