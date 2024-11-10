namespace teledok.Teledok.Controllers.Contracts.Founder
{
    public record FounderResponse
    (
        Guid id,
        string Full_Name,
        string INN,
        DateTime date_create,
        DateTime date_update);
}

