using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Models;

namespace Infrastructure.Repositories
{
    public class HistoriaClinicaRepository : IHistoriaClinicaRepository
    {
        private readonly string _connectionString;

        public HistoriaClinicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<HistoriaClinica?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetById",
                new { nIdHistoria = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Insert",
                new
                {
                    historiaclinica.nIdPaciente,
                    historiaclinica.dFechaRegistro,
                    historiaclinica.cDiagnostico,
                    historiaclinica.cTratamiento,
                    historiaclinica.cObservaciones
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> UpdateAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Update",
                new
                {

                    historiaclinica.nIdPaciente,
                    historiaclinica.dFechaRegistro,
                    historiaclinica.cDiagnostico,
                    historiaclinica.cTratamiento,
                    historiaclinica.cObservaciones
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> Delete(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Delete",
                new { nIdHistoria = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}