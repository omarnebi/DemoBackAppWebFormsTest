using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.DAL.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }
    }
}