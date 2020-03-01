using System;

namespace Patrial_LocalMethod_PatternMatching_Deconstrucor
{
    // Частичный класс
    partial class Person
    {
        public int Age { get; set; }

        // Частичный метод
        partial void DoAction()
        {
            Console.WriteLine("Walking...");
        }

        // Деконструктор
        public void Deconstruct(out string name, out int age)
        {
            name = this.Name;
            age = this.Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Локальная функция
            int[] array = { 1, 2, 3, 4, 5 };
            Console.WriteLine(DoSomething1(array));
            Console.WriteLine(DoSomething2(array));

            Console.WriteLine();

            // Частичный класс/метод и деконструктор
            Person person = new Person("Tom", 23);
            (string name, int age) = person;
            Console.WriteLine(name + " " + age);

            Console.WriteLine();

            // Pattern matching
            Employee emp = new Manager(); //Employee();
            UseEmployee(emp);


            Console.ReadKey();
        }

        #region Варианты проверок UseEmployee

        static void UseEmployee1(Employee emp)
        {
            Manager man = emp as Manager;
            if (man != null && !man.IsVacation)
            {
                man.Work();
            }
            else
            {
                Console.WriteLine("Неверное преобразование!");
            }
        }

        static void UseEmployee2(Employee emp)
        {
            try
            {
                Manager man = (Manager)emp;
                if (man != null && !man.IsVacation)
                {
                    man.Work();
                }
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UseEmployee3(Employee emp)
        {
            if (emp is Manager)
            {
                Manager man = (Manager)emp;
                if (!man.IsVacation)
                {
                    man.Work();
                }
            }
            else
            {
                Console.WriteLine("Неверное преобразование!");
            }
        }

        #endregion

        // Pattern matching
        static void UseEmployee(Employee emp)
        {
            // Pattern matching фактически выполняет сопоставление с некоторым шаблоном. Здесь выполняется
            // сопоставление с типом Manager. То есть в данном случае речь идет о type pattern - в качестве шаблона
            // выступает тип Manager. Если сопоставление прошло успешно, в переменной manager оказывается объект emp.
            if (emp is Manager man && !man.IsVacation)
            {
                man.Work();
            }
            else
            {
                Console.WriteLine("Неверное преобразование!");
            }

            // OR

            switch (emp)
            {
                case Manager manager when manager.IsVacation == false:
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                default:
                    Console.WriteLine("Объект не менеджер");
                    break;
            }
        }

        #region Локальная функция

        static int DoSomething1(int[] array)
        {
            var limit = 0;

            // При использовании локальных функций следует помнить, что они не могут иметь
            // модификаторов доступа (public, private, protected). Нельзя определить в одном методе несколько локальных
            // функций с одним и тем же именем, даже если у них будет разный список параметров. Кроме того, не имеет
            // значения, определены локальные функции до своего вызова или после.
            
            // Локальная функция
            bool LocalMethod(int i) => i > limit;

            var result = 0;
            foreach(var a in array)
            {
                if (LocalMethod(a))
                {
                    result += a;
                }
            }

            return result;
        }

        static int DoSomething2(int[] array)
        {
            // Начиная с версии C# 8.0 можно определять статические локальные функции.

            // Локальная функция
            static bool LocalMethod(int i)
            {
                var limit = 0;
                return i > limit;
            }

            var result = 0;
            foreach (var a in array)
            {
                if (LocalMethod(a))
                {
                    result += a;
                }
            }

            return result;
        }

        #endregion
    }
}
