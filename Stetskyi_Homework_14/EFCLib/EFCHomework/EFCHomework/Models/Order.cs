using System;
using System.ComponentModel.DataAnnotations;

namespace EFCHomework.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
    }
}
