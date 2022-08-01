using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
      public class Account
      {

        public Bank_A.TypeAccounts typeAccount;
        private double sum;
        private int accountId;
        
        
        public double Sum { get { return sum; } set { sum = value; } }
        public Bank_A.TypeAccounts TypeAccount { get { return typeAccount; } set { typeAccount = value; } }

        public int AccountId { get { return accountId; } set { accountId = value; } }
        public Account(double Sum, int AccountId)
        {
            this.sum = Sum;
            this.accountId = AccountId;
            

        }
        public Account()
        {

        }

        
    }
}
