using System;
using System.ComponentModel.DataAnnotations;

namespace TestDTO.Models
{
    public class AutorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
