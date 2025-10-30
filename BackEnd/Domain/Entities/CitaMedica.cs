using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CitaMedica
    {
        public int nIdCita { get; set; }
        public int nIdPaciente { get; set; }
        public int nIdMedico { get; set; }
        public DateTime dFechaCita { get; set; }
        public string cMotivo { get; set; }
        public string cEstado { get; set; }
    }
}
