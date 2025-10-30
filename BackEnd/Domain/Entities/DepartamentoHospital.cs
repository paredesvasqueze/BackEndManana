using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DepartamentoHospital
    {
        [Required(ErrorMessage = "El ID del departamento es obligatorio")]
        public int nIdDepartamento { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string? cNombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string? cDescripcion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de personal debe ser cero o mayor")]
        public int nCantidadPersonal { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria")]
        [StringLength(100, ErrorMessage = "La ubicación no puede tener más de 100 caracteres")]
        public string? cUbicacion { get; set; }

    }
}
