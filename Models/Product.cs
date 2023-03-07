using System;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Models
{
    public class Product
    {
        // EF will instruct the database to automatically generate this value
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Code.")]
        [Range(1000, 9999, ErrorMessage = "Code must be between 1000 and 9999.")]
        public int? Code { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Price can't have more than 2 decimal places")]
        public decimal price { get; set; }

        [Range(1, 100000000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; } = 1;
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please select a Warehouse.")]
        public int WarehouseId { get; set; } = 1;
        public Warehouse Warehouse { get; set; }

        public string Vendor { get; set; }
        public string Description { get; set; }

        // [Range(1, 100, ErrorMessage = "Code must be between 1 and 9999.")]
        public int Quantity { get; set; }

        public string Slug => 
            Name?.Replace(' ', '-').ToLower() + '-' + Code?.ToString();
    }
}