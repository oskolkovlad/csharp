using System;


namespace Tuples_and_Struct
{
    struct User
    {
        public string name;
        public byte age;

        public User(string name, byte age)
        {
            this.name = name;
            this.age = age;
        }

        public void GetInfo()
        {
            Console.WriteLine("Name: {0},\tAge: {1}.", name, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tuple = (10, 30);
            Console.WriteLine("Tuple:\t Item1 - {0}; Item2 - {1}", tuple.Item1, tuple.Item2);
            tuple.Item2 = 25;
            Console.WriteLine("Tuple:\t Item1 - {0}; Item2 - {1}\n", tuple.Item1, tuple.Item2);

            (string, int, double) man = ("Alex", 23, 74.5);
            Console.WriteLine("Man:\t Item1 - {0}; Item2 - {1}; Item3 - {2}\n", man.Item1, man.Item2, man.Item3);

            var woman = (name: "Page", age: 23, weigth: 74.5);
            Console.WriteLine("Woman:\t Name - {0}; Age - {1}; Weigth - {2}\n", woman.name, woman.age, woman.weigth);

            string name;
            int age;
            double weigth;
            (name, age, weigth) = ("Misha", 24, 81.97);
            Console.WriteLine("Man:\t Name - {0}; Age - {1}; Weigth - {2}\n", name, age, weigth);

            Console.WriteLine("GetValues:\t Item1 - {0}; Item2 - {1}", GetValues().Item1, GetValues().Item2);
            var res = GetData(("Manisha", 27), 1);
            Console.WriteLine("GetData:\t Name - {0}; Age - {1}\n", res.name, res.age);

            User tom;
            tom.name = "Tom";
            tom.age = 45;
            tom.GetInfo();
            User masha = new User("Masha", 18);
            masha.GetInfo();
                       

            Console.ReadKey();
        }

        static (int, int) GetValues()
        {
            return (10, 10);
        }

        static (string name, int age) GetData ((string n, int a) tuple, int x)
        {
            var res = (name: tuple.n, age: tuple.a + x);
            return res;
        }
    }
}
