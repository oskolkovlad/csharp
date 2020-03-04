using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ListStack<int> easyStack = new ListStack<int>();

            easyStack.Push(3);
            easyStack.Push(1);
            easyStack.Push(2);
            easyStack.Push(7);
            easyStack.Push(13);

            Console.WriteLine(easyStack);
            Console.WriteLine(easyStack.Peek());
            Console.WriteLine(easyStack.Pop());
            Console.WriteLine(easyStack.Peek());
            Console.WriteLine(easyStack.IsEmpty);
            Console.WriteLine(easyStack);

            Console.WriteLine(new string('-', 50));


            //**************************************************************//


            LinkedStack<int> stack = new LinkedStack<int>();

            stack.Push(4);
            stack.Push(5);
            stack.Push(765);
            stack.Push(2);
            stack.Push(25);
            stack.Push(45);

            Console.WriteLine(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.IsEmpty);
            Console.WriteLine(stack);
            Console.WriteLine();

            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine(new string('-', 50));


            //**************************************************************//


            ArrayStack<int> arrayStack = new ArrayStack<int>();

            arrayStack.Push(4);
            arrayStack.Push(5);
            arrayStack.Push(765);
            arrayStack.Push(2);
            arrayStack.Push(25);
            arrayStack.Push(45);

            Console.WriteLine(arrayStack);
            Console.WriteLine(arrayStack.Peek());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Peek());
            Console.WriteLine(arrayStack.IsEmpty);
            Console.WriteLine(arrayStack);


            //**************************************************************//


            Console.ReadKey();
        }
    }
}