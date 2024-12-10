using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalPortal.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; } // Veritabanındaki numarası.

        [Required]
        public string Name { get; set; } //İsim.

        public string Definition { get; set; } //Tanım.

        [Required]
        public string Brand { get; set; } //Marka.

        [Required]
        [Range(1000, 1000000)]
        public double Price { get; set; } //Fiyat. Bir arabayı kiralamak 1 lira olamayacağı için buna bir aralık vermemiz lazım bunu da [Range] ile tanımlıyoruz.

        [ValidateNever]
        public int CarTypeId { get; set; }
        [ForeignKey("CarTypeId")]
        
        [ValidateNever]
        public CarType CarType { get; set; }
       
        [ValidateNever]
        public string ImageUrl { get; set; }

        



    }
}
