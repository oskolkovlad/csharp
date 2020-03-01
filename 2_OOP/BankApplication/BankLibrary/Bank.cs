using System;
using System.Collections.Generic;

public enum AccountType
{
    Ordinary = 1,
    Deposit
}

namespace BankLibrary
{
    public class Bank<T> where T: Account
    {
        List<T> accounts;

        const int ordinaryPercentage = 1;
        const int depositPercentage  = 40;

        public string Name { get; private set; }

        public Bank(string _name)
        {
            Name = _name;
        }


        public void Open(AccountType accountType, decimal _sum, AccountStateHandler addSumHandler,
                                                                AccountStateHandler withdrawSumHandler,
                                                                AccountStateHandler openAccountHandler,
                                                                AccountStateHandler closeAccountHandler,
                                                                AccountStateHandler calculationHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case (AccountType)1:
                    newAccount = new DemandAccount(_sum, ordinaryPercentage) as T;
                    break;
                case AccountType.Deposit:
                    newAccount = new DepositAccount(_sum, depositPercentage) as T;
                    break;
            }

            if (newAccount == null)
                throw new ArgumentNullException("Ошибка создания счета!");

            if (accounts == null)
            {
                accounts = new List<T>();
            }
            accounts.Add(newAccount);

            newAccount.Added += addSumHandler;
            newAccount.Withdrawed += withdrawSumHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Calculated += calculationHandler;

            newAccount.Open();
        }
        public void Close(int _id)
        {
            var account = FindAccount(_id, out int index);

            if (account == null)
                throw new ArgumentNullException("Данный счет не найден!");
            accounts.RemoveAt(index);

            account.Close();
        }

        public void Put(int _id, decimal _sum)
        {
            var account = FindAccount(_id);
            if (account == null)
            {
                throw new ArgumentNullException("Данный счет не найден!");
            }
            account.Put(_sum);
        }
        public void Withdraw(int _id, decimal _sum)
        {
            var account = FindAccount(_id);
            if (account == null)
            {
                throw new ArgumentNullException("Данный счет не найден!");
            }
            account.Widthdraw(_sum);
        }

        public void CalculatePercentage()
        {
            if (accounts == null)
                return;

            foreach(var a in accounts)
            {
                a.IncrementDays();
                a.Calculate();
            }
        }

        public T FindAccount(int _id)
        {
            foreach(var a in accounts)
            {
                if(a.Id == _id)
                {
                    return a;
                }
            }

            return null;
        }
        public T FindAccount(int _id, out int index)
        {
            foreach (var a in accounts)
            {
                if (a.Id == _id)
                {
                    index = accounts.IndexOf(a);
                    return a;
                }
            }

            index = -1;
            return null;
        }

    }
}
