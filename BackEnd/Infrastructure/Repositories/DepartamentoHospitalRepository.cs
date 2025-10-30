using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartamentoHospitalRepository : IDepartamentoHospitalRepository
    {
        private readonly string _connectionString;

        public DepartamentoHospitalRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<DepartamentoHospital>> GetAllAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<DepartamentoHospital>(
                "sp_DepartamentoHospital_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<DepartamentoHospital?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<DepartamentoHospital>(
                "sp_DepartamentoHospital_GetById",
                new { nIdDepartamento = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(DepartamentoHospital departamento)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_DepartamentoHospital_Insert",
                new
                { 
                    departamento.cNombre,
                    departamento.cDescripcion,
                    departamento.nCantidadPersonal,
                    departamento.cUbicacion
                },
                commandType: CommandType.StoredProcedure);
           return newId;
        }

        public async Task<int> UpdateAsync(DepartamentoHospital departamento)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_DepartamentoHospital_Update",
                new
                {
                    departamento.nIdDepartamento,
                    departamento.cNombre,
                    departamento.cDescripcion,
                    departamento.nCantidadPersonal,
                    departamento.cUbicacion
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
               "sp_DepartamentoHospital_Delete",
                new { nIdDepartamento = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
