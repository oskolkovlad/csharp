namespace Delegate_Event
{
    class AcountDelegate
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

        public AcountDelegate(double sum)
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

    class AcountEvent
    {
        //public delegate void AcountHandler(string message);
        public delegate void AcountHandlerWithArgs(object sender, AcountEventArgs e);
        public event AcountHandlerWithArgs _acountEventHandler;

        public event AcountHandlerWithArgs AcountEventHandler
        {
            add
            {
                _acountEventHandler += value;

                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                System.Console.WriteLine("\nБыл добавлен {0}\n", value.Method.Name);
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
            remove
            {
                _acountEventHandler -= value;

                System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                System.Console.WriteLine("\nБыл удален {0}\n", value.Method.Name);
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
        }

        public int Sum { get; private set; }

        public AcountEvent(int sum)
        {
            Sum = sum;
        }

        public void Put(int sum)
        {
            Sum += sum;

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            //_acountEventHandler?.Invoke($"На счет поступило {sum}...");
            _acountEventHandler?.Invoke(this, new AcountEventArgs($"На счет поступило {sum}...", sum));
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public void Take(int sum)
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                //_acountEventHandler?.Invoke(($"Со счета снято {sum}..."));
                _acountEventHandler?.Invoke(this, new AcountEventArgs($"Со счета снято {sum}...", sum));
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                //_acountEventHandler?.Invoke(("Недостаточно средств на счете!!!"));
                _acountEventHandler?.Invoke(this, new AcountEventArgs($"Недостаточно средств на счете!!!", sum));
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
        }
    }

    class AcountEventArgs
    {
        public string Message { get;}
        public int Sum { get;}

        public AcountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}
