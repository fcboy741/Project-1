using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Input number y: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("x + y = " + (x + y));
            Console.WriteLine("x - y = " + (x - y));
            Console.WriteLine("x * y = " + (x * y));
            Console.WriteLine("x / y = " + ((float)x / y));
        }
    }
}
