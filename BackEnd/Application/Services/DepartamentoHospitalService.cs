using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartamentoHospitalService : IDepartamentoHospitalService
    {
        private readonly IDepartamentoHospitalRepository _repo;

        public DepartamentoHospitalService(IDepartamentoHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DepartamentoHospital>> GetAllAsync()
        {
            var entidades = await _repo.GetAllAsync();
            return entidades;
        }

        public async Task<DepartamentoHospital?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;
            return e;
        }

        public async Task<int> AddAsync(DepartamentoHospital dto)
        {

            return await _repo.AddAsync(dto);
        }

        public async Task<int> UpdateAsync(DepartamentoHospital dto)
        {
            return await _repo.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
