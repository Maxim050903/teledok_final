using teledok.Class_Library.Core.Entiuties;

namespace teledok.Teledoc.Application.Services
{
    public interface IClientService
    {
        Task<Guid> CreateClient(Client client);
        Task<Guid> DeleteClient(Guid id);
        Task<List<Client>> GetAllClients();
        Task<List<Founder>> GetAllFounderFromClient(Guid id);
        Task<Guid> UpdateClient(Guid id, string INN, string Name, int Client_Type);
    }
}