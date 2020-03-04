namespace BankLibrary
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal _sum, int _per) : base(_sum, _per) { }

        protected internal override void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый счет до востребования. ID счета: {this.Id}!", this.Sum)); // TODO
        }
    }
}
