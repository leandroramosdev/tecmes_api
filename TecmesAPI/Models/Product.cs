using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecmesAPI.Models
{
    [Table("Products")]
    public class Product
	{
		[Key]
		public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public int? Category { get; set; }
    }
}

