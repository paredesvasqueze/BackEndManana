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
            // Asegúrate de que "DefaultConnection" esté configurado correctamente en tus settings.
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_GetAll" (con doble 'a')
            var items = await conn.QueryAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<HistoriaClinica?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_GetById" (con doble 'a')
            // Se asume que la propiedad de la entidad es 'Id' y se mapea al parámetro '@Id' del SP.
            var item = await conn.QueryFirstOrDefaultAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetById",
                new { nIdHistoria = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Insert" (con doble 'a')
            // Los parámetros del SP son: @nIdPaciente, @dFechaRegistro, @cDiagnostico, @cTratamiento, @cObservaciones.
            // He asumido los nombres de las propiedades de tu entidad para el mapping.
            var newId = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Insert",
                new
                {
                    historiaclinica.IdPaciente,
                    historiaclinica.FechaRegistro,
                    historiaclinica.Diagnostico,
                    historiaclinica.Tratamiento,
                    historiaclinica.Observaciones
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> UpdateAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Update" (con doble 'a')
            // Los parámetros del SP son: @nIdHistoria, @nIdPaciente, @dFechaRegistro, @cDiagnostico, @cTratamiento, @cObservaciones.
            // He asumido los nombres de las propiedades de tu entidad para el mapping.
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Update",
                new
                {
                    historiaclinica.IdPaciente,
                    historiaclinica.FechaRegistro,
                    historiaclinica.Diagnostico,
                    historiaclinica.Tratamiento,
                    historiaclinica.Observaciones
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> Delete(int id)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Delete" (con doble 'a')
            // Se asume que la propiedad de la entidad es 'Id' o 'nIdHistoria' y se mapea al parámetro '@Id' del SP.
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Delete",
                new { nIdHistoria = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}