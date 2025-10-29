using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    // Implementa la interfaz IDepartamentoHospitalRepository y debe ser public
    public class DepartamentoHospitalRepository : IDepartamentoHospitalRepository
    {
        private readonly string _connectionString;

        // El constructor recibe la configuración (donde está la cadena de conexión)
        public DepartamentoHospitalRepository(IConfiguration configuration)
        {
            // Asume que la cadena de conexión se llama "DefaultConnection"
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // --- Método GET ALL ---
        public async Task<IEnumerable<DepartamentoHospital>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<DepartamentoHospital>(
                "sp_DepartamentoHospital_GetAll", // Nombre del SP
                commandType: CommandType.StoredProcedure
            );
        }

        // --- Método GET BY ID ---
        public async Task<DepartamentoHospital> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            // El parámetro 'id' en el new { ... } debe coincidir con el nombre del parámetro en el SP
            return await conn.QueryFirstOrDefaultAsync<DepartamentoHospital>(
                "sp_DepartamentoHospital_GetById",
                // Mapeamos 'id' al parámetro de nuestro modelo (nIdDepartamento) o al SP.
                // Usamos el nombre del parámetro del SP: @nIdDepartamento
                new { nIdDepartamento = id },
                commandType: CommandType.StoredProcedure
            );
        }

        // --- Método ADD/INSERT ---
        public async Task AddAsync(DepartamentoHospital departamento)
        {
            using var conn = new SqlConnection(_connectionString);
            // Pasamos un objeto anónimo que mapea las propiedades del modelo
            // a los parámetros del SP: @cNombre, @cDescripcion, etc.
            await conn.ExecuteAsync(
                "sp_DepartamentoHospital_Insert",
                new
                {
                    departamento.cNombre,
                    departamento.cDescripcion,
                    departamento.nCantidadPersonal,
                    departamento.cUbicacion
                },
                commandType: CommandType.StoredProcedure
            );
        }

        // --- Método UPDATE ---
        public async Task UpdateAsync(DepartamentoHospital departamento)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_DepartamentoHospital_Update",
                new
                {
                    // Asegúrate de que el ID (nIdDepartamento) se incluye en el update
                    departamento.nIdDepartamento,
                    departamento.cNombre,
                    departamento.cDescripcion,
                    departamento.nCantidadPersonal,
                    departamento.cUbicacion
                },
                commandType: CommandType.StoredProcedure
            );
        }

        // --- Método DELETE ---
        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_DepartamentoHospital_Delete",
                // Mapeamos 'id' al parámetro del SP: @nIdDepartamento
                new { nIdDepartamento = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
