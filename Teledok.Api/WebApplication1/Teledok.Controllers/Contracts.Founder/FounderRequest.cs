namespace teledok.Teledok.Controllers.Contracts.Founder
{
    public record FounderRequest(
        string INN,
        string Full_Name,
        Guid Client_id);
}
