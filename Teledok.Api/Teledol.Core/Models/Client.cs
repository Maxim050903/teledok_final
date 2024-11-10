using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using teledok.Teledok.DataBase.Repositories;
using Teledok.Core.Utils;

namespace teledok.Class_Library.Core.Entiuties
{
    public class Client
    {
        public Guid id { get; }
        public string INN { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public int Client_Type { get; }
        public DateTime Create_Date { get; }
        public DateTime Update_Date { get; }

        private Client(Guid id, string INN, string Name, int Client_Type)
        {
            this.id = id;
            this.INN = INN;
            this.Name = Name;
            this.Client_Type = Client_Type;
            Create_Date = DateTime.UtcNow;
            Update_Date = DateTime.UtcNow;
        }

        public static (Client client, string Error) CreateClient(Guid id, string INN, string Name, int Client_Type)
        {
            var error = string.Empty;
            Utils.CheckINN(INN,ref error);
            
            Utils.CheckName(Name, ref error);
            
            Utils.CheckClientType(Client_Type, ref error);

            var client = new Client(id, INN, Name, Client_Type);
           
            return (client, error);
        }
    }
}
