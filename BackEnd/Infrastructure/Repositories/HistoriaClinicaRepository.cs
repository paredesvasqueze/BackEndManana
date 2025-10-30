using Dapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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

        // --- ObtenerTodosAsync ---
        public async Task<IEnumerable<HistoriaClinica>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_GetAll" (con doble 'a')
            var items = await conn.QueryAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        // --- ObtenerPorIdAsync ---
        public async Task<HistoriaClinica?> ObtenerPorIdAsync(int id)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_GetById" (con doble 'a')
            // Se asume que la propiedad de la entidad es 'Id' y se mapea al parámetro '@Id' del SP.
            var item = await conn.QueryFirstOrDefaultAsync<HistoriaClinica>(
                "sp_HistoriaClinicaa_GetById",
                new { Id = id }, // Si el SP espera @Id, esto funciona. Si espera @nIdHistoria, debe coincidir con la propiedad del objeto que se pasa (generalmente se usa el nombre de la propiedad de la entidad para el parámetro anónimo).
                commandType: CommandType.StoredProcedure);
            return item;
        }

        // --- InsertarAsync ---
        public async Task<int> InsertarAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Insert" (con doble 'a')
            // Los parámetros del SP son: @nIdPaciente, @dFechaRegistro, @cDiagnostico, @cTratamiento, @cObservaciones.
            // He asumido los nombres de las propiedades de tu entidad para el mapping.
            var newId = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Insert",
                new
                {
                    nIdPaciente = historiaclinica.nIdPaciente, // Asume que la entidad tiene esta propiedad.
                    dFechaRegistro = historiaclinica.dFechaRegistro, // Asume que la entidad tiene esta propiedad.
                    cDiagnostico = historiaclinica.cDiagnostico, // Asume que la entidad tiene esta propiedad.
                    cTratamiento = historiaclinica.cTratamiento, // Asume que la entidad tiene esta propiedad.
                    cObservaciones = historiaclinica.cObservaciones // Asume que la entidad tiene esta propiedad.
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        // --- ActualizarAsync ---
        public async Task<int> ActualizarAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Update" (con doble 'a')
            // Los parámetros del SP son: @nIdHistoria, @nIdPaciente, @dFechaRegistro, @cDiagnostico, @cTratamiento, @cObservaciones.
            // He asumido los nombres de las propiedades de tu entidad para el mapping.
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinicaa_Update",
                new
                {
                    nIdHistoria = historiaclinica.nIdHistoria, // Asume que la entidad tiene esta propiedad.
                    nIdPaciente = historiaclinica.nIdPaciente, // Asume que la entidad tiene esta propiedad.
                    dFechaRegistro = historiaclinica.dFechaRegistro, // Asume que la entidad tiene esta propiedad.
                    cDiagnostico = historiaclinica.cDiagnostico, // Asume que la entidad tiene esta propiedad.
                    cTratamiento = historiaclinica.cTratamiento, // Asume que la entidad tiene esta propiedad.
                    cObservaciones = historiaclinica.cObservaciones // Asume que la entidad tiene esta propiedad.
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        // --- EliminarAsync ---
        public async Task<int> EliminarAsync(int id)
        {
            await using var conn = GetConnection();
            // Se usa "sp_HistoriaClinicaa_Delete" (con doble 'a')
            // Se asume que la propiedad de la entidad es 'Id' o 'nIdHistoria' y se mapea al parámetro '@Id' del SP.
            var rows = await conn.QuerySingleAsync<int>(
               "sp_HistoriaClinicaa_Delete",
                new { Id = id }, // Si el SP espera @Id, esto funciona. Si espera @nIdHistoria, usa new { nIdHistoria = id }
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}