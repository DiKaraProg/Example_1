using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    internal class DepositAccount : Account,IMoneyTransfer<decimal>
    {
       
        //Bank_A.TypeAccounts typeAccount = Bank_A.TypeAccounts.DepositAccount;
        //public Bank_A.TypeAccounts TypeAccount { get { return typeAccount; } set { typeAccount = value; } }

        public DepositAccount()
        {

        }
        public DepositAccount(double Sum, int AccountId) : base(Sum, AccountId)
        {
            this.typeAccount = Bank_A.TypeAccounts.DepositAccount;
        }

        public decimal RefillAccount(double Sum, double AddSum)
        {
            decimal resultSum = Convert.ToDecimal(Sum) + Convert.ToDecimal(AddSum);


            return resultSum;
        }

        public decimal WithdrawalFromAccount(double Sum, double AddSum)
        {
            decimal resultSum = Convert.ToDecimal(Sum) - Convert.ToDecimal(AddSum);


            return resultSum;
        }
    }

        
    
}
