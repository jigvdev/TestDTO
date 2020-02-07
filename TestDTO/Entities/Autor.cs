using System;
using System.ComponentModel.DataAnnotations;

namespace TestDTO.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
