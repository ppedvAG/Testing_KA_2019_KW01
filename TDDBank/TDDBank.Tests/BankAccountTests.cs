using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDBank.Tests
{

    [TestClass]
    public class BankAccountTests
    {
        //	- Kontostand abfragen
        //	- Betrag einzahlen(nicht Negativ)
        //	- Betrag abheben(nicht Negativ)
        //		- Darf nicht unter 0 fallen
        //	- Neues Konto hat 0 als Kontostand

        [TestMethod]
        public void BankAccount_new_account_has_zero_as_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            Assert.AreEqual(5m, ba.Balance);
            ba.Deposit(3m);
            Assert.AreEqual(8m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_deposit_zero_or_a_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-1));
            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0));
        }

        [TestMethod]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            ba.Withdraw(4m);
            Assert.AreEqual(16m, ba.Balance);
            ba.Withdraw(5m);
            Assert.AreEqual(11m, ba.Balance);
            ba.Withdraw(11m);
            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_with_draw_zero_or_a_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-1));
            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0));
        }

        [TestMethod]
        public void BankAccount_withdraw_over_balance_throws_InvaldOperationException()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(21m));
            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(20.01m));
            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(20.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001m));
        }

    }
}
