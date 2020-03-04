namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal _sum, int _per) : base(_sum, _per) { }

        protected internal override void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый депозитный счет. ID счета: {this.Id}!", this.Sum)); // TODO
        }

        public override void Put(decimal _sum)
        {
            if (_days % 30 == 0)
            {
                base.Put(_sum);
            }
            else
            {
                OnAdded(new AccountEventArgs("На счет можно положить только после 30-ти дневного периода", 0));
            }
        }

        public override decimal Widthdraw(decimal _sum)
        {
            if (_days % 30 == 0)
            {
                base.Widthdraw(_sum);
            }
            else
            {
                OnAdded(new AccountEventArgs("Вывести средства можно только после 30-ти дневного периода", 0));
            }

            return 0;
        }
        // Начисление процентов
        protected internal override void Calculate()
        {
            if (_days % 30 == 0)
                base.Calculate();
        }
    }
}
