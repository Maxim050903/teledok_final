namespace teledok.Teledok.DataBase.Entities
{
    public class FounderEntity
    {
        public Guid id { get; set; }
        public string INN { get; set; }
        public string Full_Name { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public Guid Client_id { get; set; }
    }
}


