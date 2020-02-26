namespace Delegate_Event
{
    class Acount
    {
        public delegate void MessageHandler(string message);
        MessageHandler _msg;

        public void RegistratorHandler(MessageHandler msg)
        {
            _msg += msg;
        }

        public void UnregistratorHandler(MessageHandler msg)
        {
            _msg -= msg;
        }


        double _sum;

        public Acount(double sum)
        {
            _sum = sum;
        }

        public double CurrentBalance { get => _sum; }

        public void Put(double money)
        {
            _sum += money;
            _msg($"На счет было положено {money.ToString()} рублей...");
        }

        public void Withdraw(double money)
        {
            if (_sum >= money)
            {
                _sum -= money;
                _msg($"Со счета было снято {money.ToString()} рублей...");
            }
            else
            {
                _msg("На счете недостаточно средств!");
            }
        }
    }
}
