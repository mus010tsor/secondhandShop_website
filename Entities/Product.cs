using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProje.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(120, ErrorMessage = "Başlık en fazla 120 karakter olmalıdır.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(2000, ErrorMessage = "Açıklama en fazla 2000 karakter olmalıdır.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 1_000_000, ErrorMessage = "Fiyat 1 ile 1.000.000 arasında olmalıdır.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        // !!!
        [Display(Name = "Satıldı mı?")]
        public bool IsSold { get; set; } = false;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // !!!
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // !!!
        [Required]
        public string SellerId { get; set; } = string.Empty;
        public IdentityUser? Seller { get; set; }
    }
}
