using Domain.Entities;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IHistoriaClinicaRepository
    {
        Task<IEnumerable<HistoriaClinica>> GetAllAsync();
        Task<HistoriaClinica?> GetByIdAsync(int id);
        Task<int> AddAsync(HistoriaClinica historiaclinica);
        Task<int> UpdateAsync(HistoriaClinica historiaclinica);
        Task<int> Delete(int id);
        Task<IEnumerable<HistoriaClinica>> GetAll();
        Task<int> Update(HistoriaClinica historiaclinica);
        Task<HistoriaClinica?> GetById(int id);
    }
}