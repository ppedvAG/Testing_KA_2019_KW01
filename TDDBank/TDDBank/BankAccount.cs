using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public void Deposit(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException();
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException();
            if (value > Balance)
                throw new InvalidOperationException();

            Balance -= value;

        }
    }
}
