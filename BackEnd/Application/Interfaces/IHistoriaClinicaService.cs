using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Models;

namespace Application.Interfaces
{
    public interface IHistoriaClinicaService
    {
        Task<IEnumerable<HistoriaClinica>> GetAllAsync();
        Task<HistoriaClinica?> GetByIdAsync(int id);
        Task<int> AddAsync(HistoriaClinica historiaclinica);
        Task<int> UpdateAsync(HistoriaClinica historiaclinica);
        Task<int> DeleteAsync(int id);        
    }
}
