namespace teledok.Teledok.Controllers.Contracts.Client
{
    public record ClientRequest(
        string INN,
        string Name,
        int Client_Type);
}