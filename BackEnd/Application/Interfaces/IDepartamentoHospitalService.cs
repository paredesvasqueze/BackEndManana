using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDepartamentoHospitalService
    {
        Task<IEnumerable<DepartamentoHospital>> GetAllAsync();
        Task<DepartamentoHospital?> GetByIdAsync(int id);
        Task<int> AddAsync(DepartamentoHospital departamento);
        Task<int> UpdateAsync(DepartamentoHospital departamento);
        Task<int> DeleteAsync(int id);
    }
}
