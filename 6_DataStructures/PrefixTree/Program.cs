using System;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Add("Привет", 50);
            tree.Add("Мир", 100);
            tree.Add("Приз", 200);
            tree.Add("мирный", 50);
            tree.Add("подарок", 100);
            tree.Add("проект", 200);
            tree.Add("прапорщик", 100);
            tree.Add("правый", 200);
            tree.Add("год", 200);
            tree.Add("герой", 200);
            tree.Add("голубь", 200);
            tree.Add("прокрастинация", 1000);

            tree.Remove("правый");
            tree.Remove("мир");

            Search(tree, "правый");
            Search(tree, "мир");
            Search(tree, "облако");
            Search(tree, "мирный");
            Search(tree, "герой");
            Search(tree, "Приз");
            Search(tree, "прапорщик");


            Console.ReadKey();
        }

        static void Search(Tree<int> tree, string key)
        {
            if (tree.TrySearch(key, out int value))
            {
                Console.WriteLine(key + " : " + value);
            }
            else
            {
                Console.WriteLine("Не найдено!");
            }
        }
    }
}
