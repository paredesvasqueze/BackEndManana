using Domain.Entities;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICitaMedicaRepository
    {
        Task<IEnumerable<CitaMedica>> GetAllAsync();
        Task<CitaMedica?> GetByIdAsync(int id);
        Task<int> AddAsync(CitaMedica cita);
        Task<int> UpdateAsync(CitaMedica cita);
        Task<int> DeleteAsync(int id);
    }
}
