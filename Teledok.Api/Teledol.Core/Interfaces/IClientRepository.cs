using teledok.Class_Library.Core.Entiuties;

namespace teledok.Teledok.DataBase.Repositories
{
    public interface IClientRepository
    {
        Task<Guid> CreateClient(Client client);
        Task<Guid> DeleteClient(Guid id);
        Task<List<Client>> GetClients(int page);
        Task<Guid> UpdateClient(Guid id, string INN, string Name, int Client_Type);
        Task<List<Guid>> GetIdClients();
    }
}