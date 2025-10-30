using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HistoriaClinica
    {
        public int IdHistoria { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }

    }
}