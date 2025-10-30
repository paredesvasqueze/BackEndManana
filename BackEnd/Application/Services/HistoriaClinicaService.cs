using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;
using Models;

namespace Services
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {
        private readonly IHistoriaClinicaRepository _repository;

        public HistoriaClinicaService(IHistoriaClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistoriaClinica>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<HistoriaClinica?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> AddAsync(HistoriaClinica historiaclinica)
        {
            return await _repository.AddAsync(historiaclinica);
        }

<<<<<<< HEAD
        public async Task<int> Update(HistoriaClinica historiaclinica)
=======
        public async Task<int> ActualizarAsync(HistoriaClinica dto)
>>>>>>> 95a90f62b513dc0ea4519f217769ba723289ae3c
        {
            return await _repository.Update(historiaclinica);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}