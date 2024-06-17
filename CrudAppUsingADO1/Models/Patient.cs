using System.ComponentModel.DataAnnotations;

namespace CrudAppUsingADO1.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        [Required]
        public string  Mobile { get; set; }

        [Required]
        public string PatientAddress { get; set; }
    }
}
