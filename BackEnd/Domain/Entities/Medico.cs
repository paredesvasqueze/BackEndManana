using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Medico
    {
        [Required(ErrorMessage = "El Id del medico es obligatorio")]
        public int nIdMedico { get; set; }

        [Required(ErrorMessage = "El número de colegiatura (CMP) es obligatorio")]
        [StringLength(10, ErrorMessage = "El número de CMP no puede tener más de 10 caracteres")]
        public string cCMP { get; set; }

        [Required(ErrorMessage = "El nombre del medico es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string cNombre { get; set; }

        [Required(ErrorMessage = "El apellido del medico es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres")]
        public string cApellido { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100, ErrorMessage = "La especialidad no puede tener más de 100 caracteres")]
        public string cEspecialidad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido")]
        public string cTelefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string cCorreo { get; set; }
    }
}
