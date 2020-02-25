namespace OperatorOverload_Const_ReadOnly
{
    class Counter
    {
        public Counter(int value)
        {
            Value = value;
        }

        public Counter(int value, int KK)
        {
            Value = value;
            this.KK = KK;
        }

        static Counter()
        {
            K = 500;
        }

        public int Value { get; set; } = 0;


        // - Константы должны быть определены во время компиляции,
        // а поля для чтения могут быть определены во время выполнения программы.

        // - Соответственно инициализировать константу можно установить только при ее определении.
        // Поле для чтения можно инициализировать либо при его определении, либо в конструкторе класса.

        // - Константы не могут использовать модификатор static, так как уже неявно являются статическими.
        // Поля для чтения могут быть как статическими, так и не статическими.

        public static readonly int K = 10;
        public readonly int KK = 10;

        public const double PI = 3.14;


        // Можно перегружать:
        //унарные операторы +, -, !, ~, ++, --
        //бинарные операторы +, -, *, /, %
        //операции сравнения ==, !=, <, >, <=, >=
        //логические операторы &&, ||

        //Нельзя перегрузить операцию равенства = или тернарный оператор ?: (полный список: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading#overloadable-operators)

        public static Counter operator + (Counter c1, Counter c2)
        {
            return new Counter(c1.Value + c2.Value);
        }

        public static Counter operator - (Counter c1, Counter c2)
        {
            return new Counter(c1.Value - c2.Value);
        }

        public static bool operator > (Counter c1, Counter c2)
        {
            return c1.Value > c2.Value;
        }

        public static bool operator < (Counter c1, Counter c2)
        {
            return c1.Value < c2.Value;
        }

        public static Counter operator ++ (Counter c1)
        {
            return new Counter(c1.Value + 1000);
        }
    }
}
