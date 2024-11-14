using teledok.Class_Library.Core.Entiuties;
using teledok.Teledok.DataBase.Repositories;

namespace teledok.Teledoc.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IFounderRepository _founderRepository;

        public ClientService(IClientRepository clientRepository, IFounderRepository founderRepository)
        {
            _clientRepository = clientRepository;
            _founderRepository = founderRepository;
        }

        public async Task<List<Client>> GetAllClients(int page)
        {
            return await _clientRepository.GetClients(page);
        }

        public async Task<Guid> CreateClient(Client client)
        {
            return await _clientRepository.CreateClient(client);
        }

        public async Task<Guid> UpdateClient(Guid id, string INN, string Name, int Client_Type)
        {
            return await _clientRepository.UpdateClient(id, INN, Name, Client_Type);
        }

        public async Task<Guid> DeleteClient(Guid id)
        {
            return await _clientRepository.DeleteClient(id);
        }

        public async Task<List<Founder>> GetAllFounderFromClient(Guid id)
        {
            return await _founderRepository.SearchAllFounderFromClient(id);
        }
    }
}
