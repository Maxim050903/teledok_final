using Microsoft.EntityFrameworkCore;
using teledok.Class_Library.Core.Entiuties;
using teledok.Teledok.DataBase.Entities;

namespace teledok.Teledok.DataBase.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly TeledokDBcontext _context;

        public ClientRepository(TeledokDBcontext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClients(int page)
        {
            var ClientEntities = await _context.Clients
                .Skip((page-1) * 2)
                .Take(2)
                .ToListAsync();

            var Clients = ClientEntities
                .Select(b => Client.CreateClient(b.id, b.INN, b.Name, b.Client_Type).client)
                .ToList();
            return Clients;
        }

        public async Task<List<Guid>> GetIdClients()
        {
            var ClientEntities = await _context.Clients
                    .AsNoTracking()
                    .ToListAsync();
            var Clients_Id = ClientEntities
                .Select(b => b.id).ToList();

            return Clients_Id;
        }

        public async Task<Guid> CreateClient(Client client)
        {
            var cliententity = new ClientEntity
            {
                INN = client.INN,
                Name = client.Name,
                Client_Type = client.Client_Type,
                Create_Date = client.Create_Date,
                Update_Date = client.Update_Date,
            };
            await _context.Clients.AddAsync(cliententity);
            await _context.SaveChangesAsync();

            return cliententity.id;
        }

        public async Task<Guid> UpdateClient(Guid id, string INN, string Name, int Client_Type)
        {
            await _context.Clients
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.INN, b => INN)
                    .SetProperty(b => b.Name, b => Name)
                    .SetProperty(b => b.Update_Date, b=>DateTime.UtcNow)
                    .SetProperty(b => b.Client_Type, b => Client_Type));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteClient(Guid id)
        {
            await _context.Clients
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
            return id;
        }
    }

}

