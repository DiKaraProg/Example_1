using System;
using System.Windows;


namespace Example_1
{
    /// <summary>
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        EventLog eventLog = new EventLog();
        public event Action<string> Warning;
        public TransferMoney()
        {
            InitializeComponent();
            Warning += Bank_A.Clue_Popup;
            
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            bool senderFlag= false;
            bool resipientFlag= false;
            try
            {
                foreach (var item in Bank_A.AllClientsInfo)
                {
                    if (item.Id == Convert.ToInt32(SenderUserId.Text))
                    {
                        foreach (var item1 in item.Listaccount)
                        {
                            if (item1.AccountId == Convert.ToInt32(SenderAccountId.Text))
                            {
                                if (item1.Sum - Convert.ToInt32(Sum.Text) >= 0)
                                {
                                    item1.Sum -= Convert.ToInt32(Sum.Text);
                                    senderFlag = true; break;
                                }
                            }
                        }
                        break;
                    }
                }
                foreach (var item in Bank_A.AllClientsInfo)
                {
                    if (item.Id == Convert.ToInt32(RecipientUserId.Text))
                    {
                        foreach (var item1 in item.Listaccount)
                        {
                            if (item1.AccountId == Convert.ToInt32(RecipientAccountId.Text))
                            {
                                if (item1.Sum - Convert.ToInt32(Sum.Text) >= 0)
                                {
                                    if (senderFlag)
                                    {
                                        item1.Sum += Convert.ToInt32(Sum.Text);
                                        resipientFlag = true; break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                if (senderFlag && resipientFlag)
                {
                    JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                    eventLog.AddToEventLog(new EventLog(MainWindow.UserChoiseFlag, $"Перевод средств - Клиент с Id: {SenderUserId.Text} перевел со счетa: {SenderAccountId.Text} -" +
                    $" Сумму: {Sum.Text}$  клиенту с Id: {RecipientUserId.Text} на номер счета: {RecipientAccountId.Text}"), "Перевод состаялся удачно");
                    Warning.Invoke("Перевод прошел успешно");
                }
                else
                {
                    Warning.Invoke("При переводе произошла ошибка");
                }

                
            }
            catch (Exception ex)
            {
                Warning.Invoke($"При переводе произошла ошибка {ex.Message}");

            }
        }
    }
}
