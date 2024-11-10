using System.ComponentModel;
using teledok.Teledoc.Application.Services;
using teledok.Teledok.DataBase.Repositories;
using Teledok.Core.Utils;

namespace teledok.Class_Library.Core.Entiuties
{
    public class Founder
    { 
        public Guid id { get; }
        public string INN { get; }
        public string Full_Name { get; }
        public DateTime Create_Date { get; }
        public DateTime Update_Date { get; }
        public Guid Client_id { get; }

        public Founder(Guid id, string INN, string Full_Name, Guid Client_id)
        {
            this.id = id;
            this.INN = INN;
            this.Full_Name = Full_Name;
            Create_Date = DateTime.UtcNow;
            Update_Date = DateTime.UtcNow;
            this.Client_id = Client_id;
        }

        public static (Founder founder, string Error) Create_Founder(Guid id,string INN, string Full_Name, Guid Client_id)
        {
            var error = string.Empty;
            Utils.CheckINN(INN, ref error);
            Utils.CheckFullName(Full_Name, ref error);
            var founder = new Founder(id, INN, Full_Name, Client_id);
            return (founder, error);
        }
    }
}
