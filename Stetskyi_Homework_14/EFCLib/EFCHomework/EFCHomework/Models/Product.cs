using System.ComponentModel.DataAnnotations;


namespace EFCHomework.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public decimal Weight { get; set; } 
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
    }
}
