using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalPortal.Models
{
    public class Rental
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ValidateNever]
        public int CarId { get; set; }
        [ForeignKey("CarId")]

        [ValidateNever]
        public CarType Car { get; set; }


    }
}
