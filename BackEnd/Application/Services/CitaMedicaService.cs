using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Models;

namespace Services
{
    public class CitaMedicaService : ICitaMedicaService
    {
        private readonly ICitaMedicaRepository _repository;

        public CitaMedicaService(ICitaMedicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CitaMedica>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CitaMedica?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(CitaMedica cita)
        {
            return await _repository.AddAsync(cita);
        }

        public async Task<int> UpdateAsync(CitaMedica cita)
        {
            return await _repository.UpdateAsync(cita);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
