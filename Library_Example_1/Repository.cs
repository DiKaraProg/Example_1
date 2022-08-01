using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1
{
    public  class Repository
    {

        
        public event Action<string> Clue;
        public List<Account> Refill(string idUserTransfer, string IdaccountTransfer, string UserSum)
        {
            List<Account> list = new List<Account>();
            DemandAccount demand = new DemandAccount();
            DepositAccount deposit = new DepositAccount();
            

            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(idUserTransfer))
                {
                    foreach (var item1 in item.Listaccount)
                    {
                        if (item1.AccountId == Convert.ToInt32(IdaccountTransfer))
                        {
                            if (item1.TypeAccount == Bank_A.TypeAccounts.DepositAccount)
                            {
                                item1.Sum = Convert.ToDouble(deposit.RefillAccount(item1.Sum, Convert.ToDouble(UserSum)));
                                JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                                list = item.Listaccount;
                                break;
                            }
                            else
                            {
                                item1.Sum = demand.RefillAccount(item1.Sum, Convert.ToDouble(UserSum));
                                JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                                list = item.Listaccount;
                                break;
                            }

                        }
                    }
                }
            }
            return list;
        }
        public List<Account> WithdrawalFromAccount(string idUserTransfer, string IdaccountTransfer, string UserSum)
        {
            List<Account> list = new List<Account>();
            DemandAccount demand = new DemandAccount();
            DepositAccount deposit = new DepositAccount();
            try
            {
                foreach (var item in Bank_A.AllClientsInfo)
                {
                    if (item.Id == Convert.ToInt32(idUserTransfer))
                    {
                        foreach (var item1 in item.Listaccount)
                        {
                            if (item1.AccountId == Convert.ToInt32(IdaccountTransfer))
                            {
                                if (item1.TypeAccount == Bank_A.TypeAccounts.DepositAccount)
                                {
                                    item1.Sum = Convert.ToDouble(deposit.WithdrawalFromAccount(item1.Sum, Convert.ToDouble(UserSum)));
                                    if (item1.Sum < 0)
                                    {

                                        Clue?.Invoke("Сумма вывода не должна превышать сумму на балансе "); break;
                                    }
                                    JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                                    list = item.Listaccount;
                                    break;
                                }
                                else
                                {
                                    item1.Sum = demand.WithdrawalFromAccount(item1.Sum, Convert.ToDouble(UserSum));
                                    JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                                    list = item.Listaccount;
                                    break;
                                }

                            }
                        }
                        break;
                    }
                }
                return list;
            }
            
            catch (Exception ex)
            {
                Clue.Invoke("Error");
                return list;
            }
          
            
        }
        public List<Account> CloseAccount(string idUser,string Idaccount)
        {
            List<Account> list = new List<Account>();
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(idUser))
                {
                    foreach (var item1 in item.Listaccount)
                    {
                        if (item1.AccountId == Convert.ToInt32(Idaccount))
                        {
                            item.Listaccount.Remove(item1);
                            SetNewIdAccount(Convert.ToInt32(idUser));
                            JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");

                            list = item.Listaccount;

                            Clue?.Invoke("Счет закрыт");
                            return list;
                        }
                    }
                }

            }
            return list;
        }
        public List<Account> CreateDepositAccount(string SelectedId, string sum)
        {
            List<Account> accountList = new List<Account>();

                foreach (var item in Bank_A.AllClientsInfo)
                {
                    if (item.Id == Convert.ToInt32(SelectedId))
                    {
                        int IdAccountCreate = item.Listaccount.Count;
                        item.Listaccount.Add(new DepositAccount(Convert.ToDouble(sum), ++IdAccountCreate));
                        JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                        accountList = item.Listaccount;
                        return accountList;
                    }

                }
           

            return accountList;
        }
        public List<Account> CreateDemandAccount(string SelectedId, string sum)
            {
                List<Account> accountList = new List<Account>();
                
                        foreach (var item in Bank_A.AllClientsInfo)
                        {
                            if (item.Id == Convert.ToInt32(SelectedId))
                            {
                                int IdAccountCreate = item.Listaccount.Count;
                                item.Listaccount.Add(new DemandAccount(Convert.ToDouble(sum), ++IdAccountCreate));
                            JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                                accountList = item.Listaccount;
                                return accountList;
                            }

                        }

                  
                return accountList;
            }
        public void DeleteClient(string UserIdDelete)
        {
            ObservableCollection<Client> client = new ObservableCollection<Client>();
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id==Convert.ToInt32(UserIdDelete))
                {
                    Bank_A.AllClientsInfo.Remove(item);
                    SetNewIdClient();
                    JsonSerializationAndDeserialization.SerialiseAllClientInfo("Data.json");
                    break;
                }
            }
        }
        public static void SetNewIdAccount(int IdUser)
        {
            int id = 1;
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == IdUser)
                {
                    foreach (var item1 in item.Listaccount)
                    {

                        item1.AccountId = id;
                        id++;

                    }
                }

            }
        }
        public static void SetNewIdClient()
        {
            int id = 1;
            foreach (var item in Bank_A.AllClientsInfo)
            {
                item.Id = id;
                id++;
            }
        }
        
    }
}
