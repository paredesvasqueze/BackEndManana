using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HistoriaClinica
    {
        public int nIdHistoria { get; set; } // Para Obtener/Actualizar/Eliminar
        public int nIdPaciente { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public string? cDiagnostico { get; set; }
        public string? cTratamiento { get; set; }
        public string? cObservaciones { get; set; }
        // ... otras propiedades que necesites, pero Dapper solo usará las que mapeen
    }
}
