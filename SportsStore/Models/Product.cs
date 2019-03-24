using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Prosz� poda� nazw� produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Prosz� poda� opis.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Prosz� poda� dodatni� cen�.")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Prosz� okre�li� kategori�.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
    }
}