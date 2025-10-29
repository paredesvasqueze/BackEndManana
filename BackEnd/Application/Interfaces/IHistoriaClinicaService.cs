using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHistoriaClinicaService
    {
        Task<IEnumerable<HistoriaClinica>> ObtenerTodosAsync();
        Task<HistoriaClinica?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(HistoriaClinica dto);
        Task<int> ActualizarAsync(HistoriaClinica dto);
        Task<int> EliminarAsync(int id);
    }
}
