using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.Models
{
    public class AppUser : IdentityUser 
    {
        [Required]
        public int Customerıd { get; set; }
        [Required]
        public string Address { get; set; } //Bir kaza durumunda müşterinin iliğini sömürmek için adresi kesinlikle yazdırmalıyız//
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }


    }
}
