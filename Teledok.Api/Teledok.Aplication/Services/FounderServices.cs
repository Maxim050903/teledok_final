using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using teledok.Class_Library.Core.Entiuties;
using teledok.Teledok.DataBase.Repositories;

namespace teledok.Teledok.Application.Services
{
    public class FounderService : IFounderService
    {
        private readonly IFounderRepository _founderRepository;
        //private readonly IClientRepository _clientRepository;

        public FounderService(IFounderRepository FounderRepository)
        {
            _founderRepository = FounderRepository;
        }

        public async Task<List<Founder>> GetAllFounders()
        {
            return await _founderRepository.GetFounders();
        }

        public async Task<Guid> CreateFounder(Founder founder)
        {
            return await _founderRepository.CreateFounder(founder);            
        }

        public async Task<Guid> UpdateFounder(Guid id, string INN, string Full_Name, Guid Client_id)
        {
            return await _founderRepository.UpdateFounder(id, INN, Full_Name, Client_id);
        }

        public async Task<Guid> DeleteFounder(Guid id)
        {
            return await _founderRepository.DeleteFounder(id);
        }
    }
}