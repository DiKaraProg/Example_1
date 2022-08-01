using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace Example_1
{
    public class Bank_A
    {
       

        public static ObservableCollection<Client> AllClientsInfo = new ObservableCollection<Client>();
        public static ObservableCollection<EventLog> Events = new ObservableCollection<EventLog>();

        public enum TypeAccounts
        {
            DemandAccount,
            DepositAccount
        }

        public static void Clue_Popup(string text)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Внимание!";
            popup.ContentText = text;
            popup.Image = SystemIcons.Warning.ToBitmap();
            popup.HeaderColor = Color.Gray;
            popup.BodyColor = Color.Black;
            popup.ContentColor = Color.White;
            popup.TitleColor = Color.Gray;
            popup.Popup();
        }
        
        
       
    }
}
