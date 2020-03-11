using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncSteams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach(var i in GetNumAsync())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            People peoples = new People();
            IAsyncEnumerable<string> peoplesAsyncEnum = peoples.GetPeopleAsync();

            await foreach (var p in peoplesAsyncEnum)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }

        static async IAsyncEnumerable<int> GetNumAsync()
        {
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }

    class People
    {
        string[] people = { "Tom", "Kate", "Alex", "Ched", "Shved" };

        public async IAsyncEnumerable<string> GetPeopleAsync()
        {
            foreach(var p in people)
            {
                await Task.Delay(100);
                yield return p;
            }
        }
    }
}
