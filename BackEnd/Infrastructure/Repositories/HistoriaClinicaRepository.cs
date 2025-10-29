using Dapper;
using Domain.Entities;
using Infrastructure.Interfaces;
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
    public class HistoriaClinicaRepository : IHistoriaClinicaRepository
    {
        private readonly string _connectionString;

        public HistoriaClinicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<HistoriaClinica>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<HistoriaClinica>(
                "sp_HistoriaClinica_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<HistoriaClinica?> ObtenerPorIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<HistoriaClinica>(
                "sp_HistoriaClinica_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> InsertarAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinica_Insert",
                new { historiaclinica.Nombre, historiaclinica.Descripcion, historiaclinica.Precio, historiaclinica.Stock, historiaclinica.CategoriaId },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> ActualizarAsync(HistoriaClinica historiaclinica)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_HistoriaClinica_Update",
                new { historiaclinica.Id, historiaclinica.Nombre, historiaclinica.Descripcion, historiaclinica.Precio, historiaclinica.Stock, historiaclinica.CategoriaId },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> EliminarAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
               "sp_HistoriaClinica_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
