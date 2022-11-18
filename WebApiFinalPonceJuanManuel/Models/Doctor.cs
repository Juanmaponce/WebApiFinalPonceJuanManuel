using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalPonceJuanManuel.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Required]
        public int DoctorNo { get; set; }

        [Required]
        public int HospitalCod { get; set; }

    
        [StringLength(50)]
        public string Apellido { get; set; }

     
        [StringLength(50)]
        public string Especialidad { get; set; }

        [ForeignKey("HospitalCod")]
        public Hospital Hospital { get; set; }


    }
}
