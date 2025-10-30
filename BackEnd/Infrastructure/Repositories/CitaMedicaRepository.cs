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
    public class CitaMedicaRepository : ICitaMedicaRepository
    {
        private readonly string _connectionString;

        public CitaMedicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<CitaMedica>> GetAllAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<CitaMedica>(
                "sp_CitaMedica_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<CitaMedica?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<CitaMedica>(
                "sp_CitaMedica_GetById",
                new { nIdCita = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(CitaMedica cita)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_CitaMedica_Insert",
                new
                {
                    cita.nIdPaciente,
                    cita.nIdMedico,
                    cita.dFechaCita,
                    cita.cMotivo,
                    cita.cEstado
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> UpdateAsync(CitaMedica cita)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_CitaMedica_Update",
                new
                {
                    cita.nIdCita,
                    cita.nIdPaciente,
                    cita.nIdMedico,
                    cita.dFechaCita,
                    cita.cMotivo,
                    cita.cEstado
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_CitaMedica_Delete",
                new { nIdCita = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
