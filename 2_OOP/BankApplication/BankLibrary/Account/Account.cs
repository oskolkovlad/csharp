namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        protected internal event AccountStateHandler Added;
        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Opened;
        protected internal event AccountStateHandler Closed;
        protected internal event AccountStateHandler Calculated;


        static int counter = 0; // счетчик для Id
        protected int _days = 0; // время с момента открытия счета


        public int Id { get; private set; }
        public decimal Sum { get; private set; }
        public int Percentage { get; private set; }

        public Account(decimal _sum, int _per)
        {
            Id = ++counter;
            Sum = _sum;
            Percentage = _per;
        }


        private void CallEvent(AccountStateHandler _event, AccountEventArgs e)
        {
            if(e != null)
            {
                _event.Invoke(this, e);
            }
        }

        // Вызов отдельных событий. Для каждого события определяется свой виртуальный метод.
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(Added, e);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(Withdrawed, e);
        }
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(Opened, e);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(Closed, e);
        }
        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(Calculated, e);
        }


        public virtual void Put(decimal _sum)
        {
            Sum += _sum;
            OnAdded(new AccountEventArgs($"На счет поступило {_sum}", _sum));
        }

        public virtual decimal Widthdraw(decimal _sum)
        {
            if(Sum >= _sum)
            {
                Sum -= _sum;
                OnWithdrawed(new AccountEventArgs($"Сумма {_sum} снята со счета {Id}", _sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs($"Недостаточно средств на счете {Id}", 0));
            }

            return _sum;
        }

        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый счет {Id}!", Sum));
        }
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Был закрыт счет {Id}. Итоговая сумма: {Sum}", Sum));
        }

        protected internal void IncrementDays()
        {
            _days++;
        }

        // Начисление процентов
        protected internal virtual void Calculate()
        {
            var increment = Sum * Percentage / 100;
            Sum += increment;
            OnCalculated(new AccountEventArgs($"Зачислены проценты на счет в размере: {increment}", increment));
        }
    }
}
