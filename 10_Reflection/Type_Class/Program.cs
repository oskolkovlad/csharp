using System;

namespace Type_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type1 = typeof(User);
            Console.WriteLine(type1);

            Type type2 = Type.GetType("Type_Class.User", false, true);
            Console.WriteLine(type2);

            User user = new User("Tom", 23);
            Type type3 = user.GetType();
            Console.WriteLine(type3);


            //******************************************************************************************//


            Console.ReadKey();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
