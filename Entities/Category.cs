using System.ComponentModel.DataAnnotations;

namespace WebProje.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(60, ErrorMessage = "Kategori adı en fazla 60 karakter olmalıdır.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } = string.Empty;
    }
}
