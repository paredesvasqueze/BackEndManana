using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> ObtenerTodosAsync();
        Task<Medico?> ObtenerPorIdAsync(int nIdMedico);
        Task<int> InsertarAsync(Medico medico);
        Task<int> ActualizarAsync(Medico medico);
        Task<int> EliminarAsync(int nIdMedico);
    }
}
