using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    internal interface IMoneyTransfer<out T> where T : struct
    {
         T RefillAccount(double Sum, double AddSum);
         T WithdrawalFromAccount(double Sum, double AddSum);
    }
}
