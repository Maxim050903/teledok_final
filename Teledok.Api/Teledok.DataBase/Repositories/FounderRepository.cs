using Microsoft.EntityFrameworkCore;
using teledok.Class_Library.Core.Entiuties;
using teledok.Teledok.DataBase.Entities;

namespace teledok.Teledok.DataBase.Repositories
{
    public class FounderRepository : IFounderRepository
    {
        private readonly TeledokDBcontext _context;

        public FounderRepository(TeledokDBcontext context)
        {
            _context = context;
        }
        public async Task<List<Founder>> GetFounders()
        {
            var FoundersEntities = await _context.Founders
                .AsNoTracking()
                .ToListAsync();

            var Founders = FoundersEntities
                .Select(b => Founder.Create_Founder(b.id,b.INN, b.Full_Name, b.Client_id).founder)
                .ToList();
            return Founders;
        }

        public async Task<Guid> CreateFounder(Founder founder)
        {
            var FounderEntity = new FounderEntity
            {
                id = founder.id,
                INN = founder.INN,
                Full_Name = founder.Full_Name,
                Create_Date = founder.Create_Date,
                Update_Date = founder.Update_Date,
                Client_id = founder.Client_id
            };
            await _context.Founders.AddAsync(FounderEntity);
            await _context.SaveChangesAsync();

            return FounderEntity.id;
        }

        public async Task<Guid> UpdateFounder(Guid id, string INN, string Full_Name, Guid Client_id)
        {
            await _context.Founders
                .Where(x => x.id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.INN, b => INN)
                    .SetProperty(b => b.Full_Name, b => Full_Name)
                    .SetProperty(b=> b.Update_Date, b=> DateTime.UtcNow)
                    .SetProperty(b => b.Client_id, b => Client_id));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> DeleteFounder(Guid id)
        {
            await _context.Founders
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<Founder>> SearchAllFounderFromClient(Guid id)
        {
            var FoundersEntities = await _context.Founders
                .Where(x => x.Client_id == id)
                .ToListAsync();

            var Founders = FoundersEntities.Select(b => Founder.Create_Founder(b.id,b.INN, b.Full_Name, b.Client_id).founder).ToList();
            return Founders;
        }
    }
}