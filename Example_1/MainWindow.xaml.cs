using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;



namespace Example_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int UserChoiseFlag;
        public static event Action<string> Clue;
        Repository repository = new Repository();
        EventLog eventLog = new EventLog();


       
        public MainWindow()
        {

            InitializeComponent();
            UserChoiseFlag = -1;
            Clue += Bank_A.Clue_Popup;
            UserChoise.SelectionChanged+=(s,e) => UserChoiseFlag = UserChoise.SelectedIndex;
            Bank_A.AllClientsInfo = JsonSerializationAndDeserialization.DeserialiseAllClientInfo("Data.json");
            Bank_A.Events = JsonSerializationAndDeserialization.DeserialiseEventLog("Log.json");
            ListView.ItemsSource = Bank_A.AllClientsInfo;
            eventLog.LogCreate_WarningMsg += Bank_A.Clue_Popup;
            
           

        }

        private void Button_Click_Add_Clients(object sender, RoutedEventArgs e)
        {
            if (UserChoiseFlag == -1)
            {
                Clue.Invoke("Выберите пользователя"); return;
            }
            AddClients addClients = new AddClients();
            addClients.Show();
            this.Close();
        }
        private void Create_Demand_Account_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (SelectedId.Text == string.Empty)  throw new MyExcaption(2);
                if (sum.Text == string.Empty) throw new MyExcaption(3);
                if (Convert.ToDouble(sum.Text) <= 100) throw new MyExcaption(4);

                ListViewAccount.ItemsSource = null;
                ListViewAccount.ItemsSource = repository.CreateDemandAccount(SelectedId.Text, sum.Text);
                eventLog.AddToEventLog(new EventLog(UserChoiseFlag, $"Создание текущего счета- Id клиента{SelectedId.Text} первоначальный вклад:{sum.Text}"), "Депозитный счет создан");
            }
            catch (MyExcaption ex) when (ex.Code== 1)
            {
                Clue?.Invoke("Для начала работы вам стоит выбрать пользователя");
                
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Выберите клиента");
            }
            catch (MyExcaption ex)  when (ex.Code==3)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (MyExcaption ex) when (ex.Code == 4)
            {
                Clue?.Invoke("Для создание счета необходим взнос от 100$");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }
        }
        private void Create_Deposit_Account_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (SelectedId.Text == string.Empty) throw new MyExcaption(2);
                if (sum.Text == string.Empty) throw new MyExcaption(3);
                if (Convert.ToDouble(sum.Text) <= 100) throw new MyExcaption(4);

                ListViewAccount.ItemsSource = repository.CreateDepositAccount(SelectedId.Text, sum.Text);
                
                    eventLog.AddToEventLog(new EventLog(UserChoiseFlag, $"Создание депозитного счета- Id клиента{SelectedId.Text} первоначальный вклад:{sum.Text}"), "Депозитный счет создан");

                
            }
            catch (MyExcaption ex) when (ex.Code == 1)
            {
                Clue?.Invoke("Для начала работы вам стоит выбрать пользователя");

            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Выберите клиента");
            }
            catch (MyExcaption ex) when (ex.Code == 3)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (MyExcaption ex) when (ex.Code == 4)
            {
                Clue?.Invoke("Для создание счета необходим взнос от 100$");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }
           
            

        }
        private void ViewAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (SelectedId.Text == string.Empty) throw new MyExcaption(2);
                List<Account> accounts = new List<Account>();
                
                    foreach (var item in Bank_A.AllClientsInfo)
                    {
                        if (item.Id == Convert.ToInt32(SelectedId.Text))
                        {
                            foreach (var item1 in item.Listaccount)
                            {
                                accounts.Add(item1);
                            }
                            ListViewAccount.ItemsSource = accounts;
                        }
                    }
                
            }
            catch (MyExcaption ex) when (ex.Code==1)
            {
                Clue.Invoke("Выберите пользователя"); 
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Выберите клиента");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }



        }
        private void Button_Click_Transfer_Between_Accounts(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                    TransferMoney transferMoney = new TransferMoney();
                transferMoney.Show();
            }
            catch (MyExcaption ex) when(ex.Code==1)
            {
                Clue.Invoke("Выберите пользователя"); 
            }
        }

        private void Button_Click_Close_Account(object sender, RoutedEventArgs e)
        {
            try
            {
                string UserId = idUser.Text;
                string AcccountId = Idaccount.Text;

                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (UserId == String.Empty || AcccountId == String.Empty) throw new MyExcaption(2);
                ListViewAccount.ItemsSource = null;
                ListViewAccount.ItemsSource = repository.CloseAccount(UserId, AcccountId);
                eventLog.AddToEventLog(new EventLog(UserChoiseFlag,
                        $"Закрытие счета- Id клиента:{UserId} Id счета:{AcccountId}"), "Счет закрыт");
            }
            
            catch (MyExcaption ex) when (ex.Code == 1)
            {
                Clue.Invoke("Выберите пользователя");
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }

        }

        private void Button_Click_Refill(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (idUserTransfer.Text == String.Empty || 
                    IdaccountTransfer.Text == String.Empty ||
                    UserSum.Text == String.Empty) throw new MyExcaption(2);

                List<Account> accounts = new List<Account>();
                accounts = repository.Refill(idUserTransfer.Text, IdaccountTransfer.Text, UserSum.Text);
                ListViewAccount.ItemsSource = null;
                ListViewAccount.ItemsSource = accounts;
                eventLog.AddToEventLog(new EventLog(UserChoiseFlag, $"Пополнение счета- id клиента:{idUserTransfer.Text}" +
                    $",id счета:{IdaccountTransfer.Text} Пополнение на сумму:{UserSum.Text}"), "Счет пополнен");
            }

            catch (MyExcaption ex) when (ex.Code == 1)
            {
                Clue.Invoke("Выберите пользователя");
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }

        }
        private void Button_Click_Withdrawal_From_Account(object sender, RoutedEventArgs e)
        {
            try
            {
                string UserTransferId = idUserTransfer.Text;
                string AccountTransferId = IdaccountTransfer.Text;
                string Sum = UserSum.Text;
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (UserTransferId == String.Empty ||
                    AccountTransferId == String.Empty ||
                    Sum == String.Empty) throw new MyExcaption(2);

                ListViewAccount.ItemsSource = null;
                ListViewAccount.ItemsSource = repository.WithdrawalFromAccount(UserTransferId, AccountTransferId, Sum);
                eventLog.AddToEventLog(new EventLog(UserChoiseFlag, $"Снятие со счета- id клиента:{UserTransferId}" +
                   $",id счета:{AccountTransferId} Сумма снятия:{Sum}"), "Снятие произведено успешно");
            }

            catch (MyExcaption ex) when (ex.Code == 1)
            {
                Clue.Invoke("Выберите пользователя");
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }

        }

        private void Button_Click_Delete_Client(object sender, RoutedEventArgs e)
        {

            try
            {
                if (UserChoiseFlag == -1) throw new MyExcaption(1);
                if (SelectedId.Text == String.Empty ) throw new MyExcaption(2);
                repository.DeleteClient(SelectedId.Text);
                ListView.ItemsSource = null;
                ListView.ItemsSource = Bank_A.AllClientsInfo;
                eventLog.AddToEventLog(new EventLog(UserChoiseFlag,
                        $"Удаление клиента. Id клиента:{SelectedId.Text}"), "Клиент удален");
            }

            catch (MyExcaption ex) when (ex.Code == 1)
            {
                Clue.Invoke("Выберите пользователя");
            }
            catch (MyExcaption ex) when (ex.Code == 2)
            {
                Clue?.Invoke($"Введите значение!");
            }
            catch (FormatException ex)
            {
                Clue?.Invoke($"Введенное значение дожно быть только в числовом формате!  {ex.Message}");
            }

        }

        

        private void Button_Click_Show_EventLog(object sender, RoutedEventArgs e)
        {
            EventLog_Window eventLog_Window = new EventLog_Window();
            eventLog_Window.Show();
            this.Close();
        }

        
    }
}
