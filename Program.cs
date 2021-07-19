using System;

namespace Biogense
{
    class Program
    {
        static void Main(string[] args)
        {
            //const char ALIVE = 'o';
            //const char DEAD = ' ';
            Console.WriteLine("Hello World!");
            var grid = new Grid(4);
            grid.Print();
        }
    }
}
