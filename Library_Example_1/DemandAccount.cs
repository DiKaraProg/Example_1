using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    internal class DemandAccount : Account,IMoneyTransfer<double>
    {
        
        //Bank_A.TypeAccounts typeAccount = Bank_A.TypeAccounts.DemandAccount;
        //public Bank_A.TypeAccounts TypeAccount { get { return typeAccount; } set { typeAccount = value; } }

        
        public DemandAccount()
        {

        }
        public DemandAccount(double Sum, int AccountId) : base(Sum, AccountId)
        {
            this.typeAccount = Bank_A.TypeAccounts.DemandAccount;
        }

        public double RefillAccount(double Sum,double AddSum)
        {
            double resultSum = Sum + AddSum;
            

            return resultSum;
        }

        public double WithdrawalFromAccount(double Sum, double AddSum)
        {
            double resultSum = Sum - AddSum;


            return resultSum;
        }
    }
    
}
