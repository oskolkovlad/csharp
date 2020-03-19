using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User("Tom", 16);
            User alex = new User("Alex", 18);

            var tomVal = ValidateUser(tom);
            var alexVal = ValidateUser(alex);

            Console.WriteLine(tomVal);
            Console.WriteLine(alexVal);


            Console.ReadKey();
        }

        static bool ValidateUser(User user)
        {
            Type typeUser = user.GetType();
            var attr = typeUser.GetCustomAttributes(false);

            foreach(AgeValidationAttribute a in attr)
            {
                if (user.Age < a.Age)
                    return false;
                else
                    return true;
            }
            return true;
        }
    }

    
}
