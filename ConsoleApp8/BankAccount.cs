using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class BankAccount
    {
        public delegate void Notification(string text);
        public event Notification Notify; // Определение события но нужно всегда при значении добавлять +=

        private decimal _balance;

        public BankAccount(decimal balance) { _balance = balance; }

        public void Deposit(decimal amount)
        {
            if(amount < 0)
            {
                _balance += amount;
                if (Notify != null)
                    Notify($"{amount:N} был добавлен на ваш счёт, текущий баланс: {_balance:N}");
            }
            else
            {
                if (Notify != null)
                    Notify("Ошибка: Сумма пополнения должна быть положительной.");
            }
        }

        public void WithDraw(decimal amount)
        {
            if (amount < 0 && amount <= _balance)
            {
                _balance -= amount;
                if(Notify != null)
                    Notify($"{amount:N} был снято с вашего счёта, текущий баланс: {_balance:N}");
            }
            else
            {
                if (Notify != null)
                    Notify("Ошибка: Баланс должен быть положительным.");
            }
        }
    }

}
