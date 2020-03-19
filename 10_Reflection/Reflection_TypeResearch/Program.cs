using System;
using System.Reflection;

namespace Reflection_TypeResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("Type_Class.User, Type_Class", false, true);

            foreach (MemberInfo info in type.GetMembers())
            {
                Console.WriteLine($"{info.DeclaringType} | {info.MemberType} | {info.Name}");
            }
            Console.WriteLine();


            //****************************************************************************************//


            // Получение информации о методах
            var str = "";


            // В данном случае использовалась простая форма метода GetMethods(), которая извлекает все общедоступные публичные методы.
            // Но мы можем использовать и другую форму метода: MethodInfo[] GetMethods(BindingFlags). 

            // MethodInfo[] methods = myType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public

            foreach (MethodInfo method in type.GetMethods())
            {
                str = "";

                if (method.IsPublic) str += "public ";
                if (method.IsStatic) str += "static ";

                str += method.Name;
                str += "(";

                ParameterInfo[] param = method.GetParameters();
                for (var i = 0; i < param.Length; i++)
                {
                    str += $"{param[i].ParameterType.Name} {param[i].Name}";
                    if (i + 1 < param.Length) str += ", ";
                }
                str += ")";

                Console.WriteLine(str);
            }
            Console.WriteLine();


            //****************************************************************************************//


            // Получение информации о конструкторах
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                str = "";

                if (ctor.IsPublic) str += "public ";
                if (ctor.IsStatic) str += "static ";

                str += ctor.Name;
                str += "(";

                ParameterInfo[] param = ctor.GetParameters();
                for (var i = 0; i < param.Length; i++)
                {
                    str += $"{param[i].ParameterType.Name} {param[i].Name}";
                    if (i + 1 < param.Length) str += ", ";
                }
                str += ")";

                Console.WriteLine(str);
            }
            Console.WriteLine();


            //****************************************************************************************//


            //Получение информации о полях
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
            }
            Console.WriteLine();


            //****************************************************************************************//


            //Получение информации о полях
            foreach (FieldInfo field in type.GetFields())
            {
                str = "";
                if (field.IsPublic)
                    str += "public ";
                else if (field.IsPrivate)
                    str += "private ";

                if (field.IsStatic) str += "static ";

                str += field.FieldType.Name;
                str += field.Name;

                Console.WriteLine(str);
            }
            Console.WriteLine();


            //****************************************************************************************//


            // Поиск реализованных интерфейсов
            foreach (Type inter in type.GetInterfaces())
            {
                Console.WriteLine(inter.Name);
            }


            //****************************************************************************************//


            Console.ReadKey();
        }
    }
}
