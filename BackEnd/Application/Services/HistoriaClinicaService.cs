using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Models;


namespace Application.Services
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {
        private readonly IHistoriaClinicaRepository _repository;

        public HistoriaClinicaService(IHistoriaClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HistoriaClinica?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(HistoriaClinica historiaclinica)
        {
            return await _repository.AddAsync(historiaclinica);
        }

        public async Task<int> UpdateAsync(HistoriaClinica historiaclinica)
        {
            return await _repository.UpdateAsync(historiaclinica);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.Delete(id);
        }

        
    }
}