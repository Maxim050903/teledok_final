using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teledok.Teledok.DataBase.Repositories;

namespace Teledok.Core.Utils
{
    public static class Utils
    {
        //private readonly IClientRepository _clientRepository;
        
        private enum ClientType
        {
            [Description("Юридическое лицо")]
            LEGAL_ENTITY = 1,

            [Description("Индивидуальный предприниматель")]
            INDIVIDUAL_ENTREPRENEUR = 2,
        }

        //public Utils(IClientRepository clientRepository)
        //{
        //    _clientRepository = clientRepository;
        //}


        public static void CheckINN(string INN, ref string error)
        {
            try
            {
                ulong.Parse(INN);
            }
            catch (Exception e)
            {
                error = "В строке инн не должно быть букв";
                return;
            }
            if (string.IsNullOrEmpty(INN))
            {
                error = "Введите значение в поле ИНН";
                return;
            }
            else if (INN.Length != 12)
            {
                error = "Поле ИНН должно содержать 12 символов";
                return;
            }
        }

        public static void CheckName(string Name, ref string error)
        {
            if (string.IsNullOrEmpty(Name))
            {
                error = "Поле Имя не должно быть пустым";
                return;
            }
        }
        public static void CheckClientType(int Client_Type, ref string error)
        {
            if (Client_Type != (int)ClientType.LEGAL_ENTITY && Client_Type != (int)ClientType.INDIVIDUAL_ENTREPRENEUR)
            {
                error = "Поле тип клиента должно содержать значение 1 или 2. (1 - Юридическое лицо. 2 - Индивидуальный предприниматель)";
                return;
            }
        }

        public static void CheckFullName(string FullName, ref string error)
        {
            string[] ValueArray = FullName.Split(' ');
            if (ValueArray.Count() != 3)
            {
                error = "Поле полное имя должно содержать (Имя, Фамилию, Отчество) разделенные пробелами)";
                return;
            }
        }

        //public static string CheckClientId(ref Guid ClientId)
        //{
        //    var error = string.Empty;
        //    if (!_clientRepository.GetIdClients().Result.Contains(ClientId))
        //    {
        //        error = "Поле полное имя должно содержать (Имя, Фамилию, Отчество) разделенные пробелами)";
        //        return error;
        //    }
        //    return error;
        //}
    }
}
