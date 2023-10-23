using System;
using StackOfNumbers;

namespace StackClientProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            Console.WriteLine("Pushing numbers onto the stack:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                stack.Push(i);
            }

            Console.WriteLine("\nPeeking the top item: " + stack.Peek());

            Console.WriteLine("\nPopping numbers from the stack:");
            while (true)
            {
                try
                {
                    Console.WriteLine(stack.Pop());
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("The stack is now empty!");
                    break;
                }
            }

            Console.WriteLine("\nTrying to pop from an empty stack...");
            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}