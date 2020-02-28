using System;
using System.Collections;
using System.Linq;

namespace Extension_Method
{
    // Класс должен быть статичным
    static class Helper
    {
        // Должен иметь модификатор доступа "public"
        public static bool IsEven(this int digit) => digit % 2 == 0;
        public static bool IsDivided(this int digit, int a) => digit % a == 0;

        public static string ConvertToString(this IEnumerable collection)
        {
            var result = "";
            foreach (var item in collection)
            {
                result += item.ToString() + ";\n";
            }

            return result;
        }

        public static Road CreateRandomRoad(this Road road, int min, int max)
        {
            var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));

            road.Number = rnd.Next(1, 30);
            road.Length = rnd.Next(min, max);

            return road;
        }
    }
}
