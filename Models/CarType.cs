using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalPortal.Models
{
    public class CarType
    {
        [Key]   // Primary Key burası(Tanımlamasan da olur fakat daha anlaşılır kod yazmak açısından burada belirtmen bir + olur.)
        public int Id { get; set; }

        [Required(ErrorMessage = "Burası Boş Olamaz!")] // NOT NULL
        [MaxLength(30)]
        [DisplayName("Yeni Araç Türü Adı")]


        public string Name { get; set; }
    }
}
