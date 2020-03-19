using System;

namespace Type_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type1 = typeof(User);
            Console.WriteLine(type1);

            // Первый параметр указывает на полное имя класса с пространством имен. В данном случае класс User находится в
            // пространстве имен TestConsole. Второй параметр указывает, будет ли генерироваться исключение, если класс
            // не удастся найти. В данном случае значение false означает, что исключение не будет генерироваться. 
            // И третий параметр указывает, надо ли учитывать регистр символов в первом параметре. Значение true означает, что регистр игнорируется.

            // В данном случае класс основной программы и класс User находятся в одном проекте и компилируются в одну сборку exe.
            // Однако может быть, что нужный нам класс находится в другой сборке dll.
            // Для этого после полного имени класса через запятую указывается имя сборки, например, "TestConsole.User, MyLibrary".
            Type type2 = Type.GetType("Type_Class.User", false, true);
            Console.WriteLine(type2);

            // В отличие от предыдущего примера здесь, чтобы получить тип, надо создавать объект класса.
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
        private int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
