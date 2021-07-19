using System;
using System.Text;
namespace Biogense
{
    public class Grid
    {
        int Size;
        char[,] Cells;

        public Grid(int size)
        {
            Size = size;
            Cells = new char[,] { { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' } };
        }

        public void Print()
        {
            var output = new StringBuilder();
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    output.Append(Cells[row, col]);
                }

                Console.WriteLine(output.ToString());
                output.Clear();
            }
        }
    }
}
