using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    public class EventLog
    {
        public event Action<string> LogCreate_WarningMsg;

        private string user;
        private string eventTime;
        private string eventUser;
        

        public string User { get { return user; } set { user = value; } }
        public string EventTime { get { return eventTime; } set { eventTime = value; } }
        public string EventUser { get { return eventUser; } set { eventUser = value; } }
        

        public EventLog()
        {

        }
        public EventLog(int User, string Userevent)
        {
            if (User == 0)
            {
                this.user = "Консультант";
            }
            else if (User == 1) this.user = "Менеджер";
            else if (User == -1) this.user = "Пользователь не был выбран";
            this.eventTime = DateTime.Now.ToString();
            this.eventUser = Userevent;
        }
        
        public void AddToEventLog(EventLog eventLog,string PopupText)
        {
            if (Bank_A.Events==null)
            {
                Bank_A.Events = new ObservableCollection<EventLog>();
            }
            Bank_A.Events.Add(eventLog);
            JsonSerializationAndDeserialization.SerialiseEventLog("Log.json");
            LogCreate_WarningMsg?.Invoke(PopupText);
        }
    }
}
