using System.ComponentModel.DataAnnotations;

namespace dotnet_inmob_primer_entrega.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Domicilio { get; set; }
    }
}
