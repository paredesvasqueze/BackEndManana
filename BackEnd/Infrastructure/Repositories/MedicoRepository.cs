using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly string _connectionString;

        public MedicoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Medico>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Medico>(
                "sp_Medico",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Medico?> ObtenerPorIdAsync(int nIdMedico)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Medico>(
                "sp_ListarMedicos",
                new { Id = nIdMedico },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> InsertarAsync(MedicoRepository medico)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_InsertarMedico",
                new
                {
                    
                    medico.cNombre,
                    medico.cApellido,
                    medico.cCMP,
                    medico.cEspecialidad,
                    medico.cTelefono,
                    medico.cCorreo,
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> ActualizarAsync(MedicoRepository medico)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_ActualizarMedico",
                new
                {
                    medico.nIdMedico,
                    medico.cNombre,
                    medico.cApellido,
                    medico.cCMP,
                    medico.cEspecialidad,
                    medico.cTelefono,
                    medico.cCorreo
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> EliminarAsync(int nIdMedico)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
               "sp_EliminarMedico",
                new { Id = nIdMedico },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
