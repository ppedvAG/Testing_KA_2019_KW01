using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public Wealth Wealth
        {
            get
            {
                if (Balance == 0)
                    return Wealth.Zero;
                else if (Balance > 1000000)
                    return Wealth.Rich;
                else if (Balance > 1000)
                    return Wealth.OK;
                else return Wealth.Poor;
            }
        }

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

    public enum Wealth
    {
        Zero,
        Poor,
        OK,
        Rich
    }
}
