using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repo;

        public MedicoService(IMedicoRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<Medico>> ObtenerTodosAsync()
        {
            return await _repo.ObtenerTodosAsync();
        }

        public async Task<Medico?> ObtenerPorIdAsync(int nIdMedico)
        {
            if (nIdMedico <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var medico = await _repo.ObtenerPorIdAsync(nIdMedico);
            return medico;
        }

        public async Task<int> CrearAsync(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico));

            return await _repo.InsertarAsync(medico);
        }

        public async Task<int> ActualizarAsync(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico));

            if (medico.nIdMedico <= 0)
                throw new ArgumentException("El ID del médico no es válido.", nameof(medico.nIdMedico));

            return await _repo.ActualizarAsync(medico);
        }

        public async Task<int> EliminarAsync(int nIdMedico)
        {
            if (nIdMedico <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(nIdMedico));

            return await _repo.EliminarAsync(nIdMedico);
        }
    }
}
