using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HistoriaClinica
    {
<<<<<<< HEAD
        public int IdHistoriaa { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }
=======
        public int nIdHistoria { get; set; } // Para Obtener/Actualizar/Eliminar
        public int nIdPaciente { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public string? cDiagnostico { get; set; }
        public string? cTratamiento { get; set; }
        public string? cObservaciones { get; set; }
        // ... otras propiedades que necesites, pero Dapper solo usará las que mapeen
>>>>>>> 95a90f62b513dc0ea4519f217769ba723289ae3c
    }
}