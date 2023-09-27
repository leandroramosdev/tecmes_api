using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TecmesAPI.Enums;

namespace TecmesAPI.Models
{

    [Table("OrderProducts")]
    public class OrderProduct
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]

        public int? ProductId { get; set; }

        public virtual Product? Product{ get; set; }

        [Required]
        public int Quantity { get; set; }

        public int QuantityDone { get; set; }

        [Required]
        public int Machine { get; set; }

        [Required]
        public StatusOrder Status { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}

