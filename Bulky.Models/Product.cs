using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Title")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(0,1000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for Quantity 1-50 books")]
        public double Price { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for Quantity 50+ books")]
        public double Price50 { get; set; }

        [Required]
        [Range(0, 1000)]
        [DisplayName("Price for Quantity 100+ books")]
        public double Price100 { get; set; }

    }
}
