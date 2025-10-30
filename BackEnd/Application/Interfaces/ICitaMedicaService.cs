using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICitaMedicaService
    {
        Task<IEnumerable<CitaMedica>> GetAllAsync();
        Task<CitaMedica?> GetByIdAsync(int id);
        Task<int> AddAsync(CitaMedica cita);
        Task<int> UpdateAsync(CitaMedica cita);
        Task<int> DeleteAsync(int id);
    }
}
