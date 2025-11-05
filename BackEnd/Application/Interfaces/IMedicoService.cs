using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> ObtenerTodosAsync();
        Task<Medico?> ObtenerPorIdAsync(int nIdMedico);
        Task<int> CrearAsync(Medico dto);
        Task<int> ActualizarAsync(Medico dto);
        Task<int> EliminarAsync(int nIdMedico);
    }
}
