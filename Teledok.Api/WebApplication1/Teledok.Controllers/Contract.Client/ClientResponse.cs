namespace teledok.Teledok.Controllers.Contracts
{
    public record ClientResponse(
        Guid id,
        string Name,
        string INN,
        DateTime date_create,
        DateTime date_update,
        int Client_Type);

}

