using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Interfaces
{
    public interface IDepartamentoHospitalRepository
    {
        Task<IEnumerable<DepartamentoHospital>> GetAllAsync();
        Task<DepartamentoHospital> GetByIdAsync(int id);
        Task AddAsync(DepartamentoHospital departamento);
        Task UpdateAsync(DepartamentoHospital departamento);
        Task DeleteAsync(int id);
    }
}
