using teledok.Class_Library.Core.Entiuties;

namespace teledok.Teledok.DataBase.Repositories
{
    public interface IFounderRepository
    {
        Task<Guid> CreateFounder(Founder founder);
        Task<Guid> DeleteFounder(Guid id);
        Task<List<Founder>> GetFounders();
        Task<List<Founder>> SearchAllFounderFromClient(Guid id);
        Task<Guid> UpdateFounder(Guid id, string INN, string Full_Name, Guid Client_id);
    }
}