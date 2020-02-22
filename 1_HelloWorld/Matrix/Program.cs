using System;
using System.Threading;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            String [] phrases = { "Wake up, Neo...", "The Matrix has you.", "Folow the white rabbit.", "Knock, knock, Neo." };

            foreach (String phrase in phrases)
            {
                foreach (char c in phrase)
                {
                    Console.Write(c);
                    Thread.Sleep(200);
                }

                Thread.Sleep(3000);
                Console.Clear();
            }

            //Console.ReadKey();
        }
    }
}
