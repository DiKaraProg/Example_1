using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    public static class JsonSerializationAndDeserialization
    {
        
        public static void SerialiseEventLog(string Path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    string json = JsonConvert.SerializeObject(Bank_A.Events, Formatting.Indented, settings);
                    sw.WriteLine(json);
                }
        }
        public static ObservableCollection<EventLog> DeserialiseEventLog(string Path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            ObservableCollection<EventLog> clients = new ObservableCollection<EventLog>();

                using (StreamReader sr = new StreamReader(Path))
                {
                    string json = sr.ReadToEnd();
                    clients = JsonConvert.DeserializeObject<ObservableCollection<EventLog>>(json, settings);

                }

            return clients;

        }
        public static void SerialiseAllClientInfo(this string Path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

                using (StreamWriter sw = new StreamWriter(Path))
                {
                    string json = JsonConvert.SerializeObject(Bank_A.AllClientsInfo, Formatting.Indented, settings);
                    sw.WriteLine(json);
                }
        }
        public static ObservableCollection<Client> DeserialiseAllClientInfo(string Path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            
                using (StreamReader sr = new StreamReader(Path))
                {
                    string json = sr.ReadToEnd();
                    clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json, settings);

                }

            return clients;

        }
    }
}
