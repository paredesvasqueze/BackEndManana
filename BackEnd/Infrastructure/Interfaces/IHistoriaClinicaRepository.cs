using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IHistoriaClinicaRepository
    {
        Task<IEnumerable<HistoriaClinica>> ObtenerTodosAsync();
        Task<HistoriaClinica?> ObtenerPorIdAsync(int id);
        Task<int> InsertarAsync(HistoriaClinica historiaclinica);
        Task<int> ActualizarAsync(HistoriaClinica historiaclinica);
        Task<int> EliminarAsync(int id);
    }
}
