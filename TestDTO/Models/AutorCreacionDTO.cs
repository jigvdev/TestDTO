using System;
using System.ComponentModel.DataAnnotations;

namespace TestDTO.Models
{
    public class AutorCreacionDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
    }
}
