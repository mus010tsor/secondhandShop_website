using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProje.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        // !!!
        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        // !!!
        [Required]
        public string BuyerId { get; set; } = string.Empty;
        public IdentityUser? Buyer { get; set; }

        [Display(Name = "Satın Alma Tarihi")]
        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;

        [Range(1, 1_000_000, ErrorMessage = "Satın alma fiyatı geçersiz.")]
        [Display(Name = "Satın Alma Fiyatı")]
        // !!!
        public decimal PriceAtPurchase { get; set; }
    }
}
