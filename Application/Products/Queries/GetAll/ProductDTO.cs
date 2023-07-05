using System;

namespace Application.Products.Queries.GetAll
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsActive { get; set; }

        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
    }
}
