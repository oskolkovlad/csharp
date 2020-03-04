using System;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank<Account>("RocketBank");

            ConsoleColor simple = ConsoleColor.White;
            ConsoleColor menu = ConsoleColor.DarkGreen;
            ConsoleColor error = ConsoleColor.Red;

            while (true)
            {
                Console.ForegroundColor = menu;
                Console.WriteLine("\t| *** МЕНЮ *** |\n" +
                                  "Выберите один из следующих пунктов меню:\n" +
                                  "\t1. Открыть счет.\n" +
                                  "\t2. Вывести средства.\n" +
                                  "\t3. Добавить на счет.\n" +
                                  "\t4. Закрыть счет.\n" +
                                  "\t5. Пропустить день.\n" +
                                  "\t6. Выход.\n");
                Console.ForegroundColor = simple;

                try
                {
                    var command = int.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            break;
                        case 6:
                            return;
                    }

                    bank.CalculatePercentage();
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = error;
                    Console.WriteLine("\n" + ex.Message + "\n");
                    Console.ForegroundColor = simple;
                }

            }
        }
        private static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("\nВыберите тип счета:\n" +
                              "\t1. Счет до востребования.\n" +
                              "\t2. Депозитный счет.");
            int typeAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nВведите сумму для создания счета:");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal sum))
                {
                    bank.Open((AccountType)typeAccount, sum, AddSumHandler,
                                                                WithdrawSumHandler,
                                                                OpenAccountHandler,
                                                                CloseAccountHandler,
                                                                (o, e) => Console.WriteLine(e.Message));
                    break;
                }
                else
                {
                    Console.WriteLine("Вы неправильно ввели сумму...Попробуйте еще!");
                    continue;
                }
            }

        }
        private static void Withdraw(Bank<Account> bank)
        {
            Console.WriteLine("\nВведите ID счета, который надо закрыть:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Укажите сумму, чтобы положить на счет:");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal sum))
                {
                    bank.Withdraw(id, sum);
                    break;
                }
                else
                {
                    Console.WriteLine("Вы точно ввели число? Попробуйте еще раз...");
                }
            }
        }
        private static void Put(Bank<Account> bank)
        {
            Console.WriteLine("\nВведите ID счета, который надо закрыть:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Укажите сумму, чтобы положить на счет:");
            while(true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal sum))
                {
                    bank.Put(id, sum);
                    break;
                }
                else
                {
                    Console.WriteLine("Вы точно ввели число? Попробуйте еще раз...");
                }
            }
        }
        private static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("\nВведите ID счета, который надо закрыть:");
            int id = int.Parse(Console.ReadLine());

            bank.Close(id);
        }

        // Обработчики событий класса Account
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Идем тратить деньги");
        }
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
