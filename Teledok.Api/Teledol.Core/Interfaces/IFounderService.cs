using teledok.Class_Library.Core.Entiuties;

namespace teledok.Teledok.Application.Services
{
    public interface IFounderService
    {
        Task<Guid> CreateFounder(Founder founder);
        Task<Guid> DeleteFounder(Guid id);
        Task<List<Founder>> GetAllFounders();
        Task<Guid> UpdateFounder(Guid id, string INN, string Full_Name, Guid Client_id);
    }
}