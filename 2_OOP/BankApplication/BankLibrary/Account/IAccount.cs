namespace BankLibrary
{
    interface IAccount
    {
        // Положить деньги на счет
        void Put(decimal _sum);

        // Снять деньги со счета
        decimal Widthdraw(decimal _sum);
    }
}
