using static System.Console;

namespace OperatorOverload_Const_ReadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c1 = new Counter(25, 7000);
            Counter c2 = new Counter(75);

            Counter c = c2 - c1;
            WriteLine($"c1 - c2: {c.Value}");

            c = c2 + c1;
            WriteLine($"c1 + c2: {c.Value}");

            c++;
            WriteLine($"\nc++: {c.Value}");

            WriteLine($"\nc1 > c2: {c1 > c2}");
            WriteLine($"c > c2: {c > c2}");
            WriteLine($"c1 < c2: {c1 < c2}");
            WriteLine($"c < c2: {c < c2}");


            //**********************************//


            WriteLine($"\nConst: {Counter.PI.ToString().Replace(',', '.')}");

            WriteLine($"ReadO Static: {Counter.K}");
            WriteLine($"ReadO c1: {c1.KK}");
            WriteLine($"ReadO c2: {c2.KK}\n");


            //**********************************//


            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            WriteLine(sandwich.Weight);  // 100


            //**********************************//


            ReadKey();
        }
    }
}
