using System;
using System.Threading;

namespace Biogense
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(4);
            for (int i = 0; i < 20; i++)
            {
                Console.Clear();
                grid.Print();
                grid.Update();
                Thread.Sleep(700);
            }
        }
    }
}
