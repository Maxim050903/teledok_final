namespace teledok.Teledok.DataBase.Entities
{
    public class ClientEntity
    {
        public Guid id { get; set; }
        public string INN { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Client_Type { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Update_Date { get; set; }
    }
}
