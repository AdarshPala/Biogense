using System;
using System.Text;
namespace Biogense
{
    public class Grid
    {
        const char ALIVE = 'o';
        const char DEAD = ' ';
        readonly int Size;
        char[,] Cells;

        public Grid(int size)
        {
            Size = size;
            // 4x4
            //Cells = new char[,] { { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' }, { 'o', ' ', ' ', 'o' } };
            //Cells = new char[,] { { ' ', ' ', ' ', ' ' }, { ' ', 'o', 'o', 'o' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
            //Cells = new char[,] { { ' ', ' ', ' ', ' ' }, { 'o', 'o', 'o', 'o' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
            Cells = new char[,] { { ' ', ' ', ' ', ' ' }, { ' ', 'o', 'o', 'o' }, { ' ', ' ', ' ', ' ' }, { ' ', 'o', 'o', ' ' } };
        }

        public void Update()
        {
            char[,] updatedCells = new char[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    bool isAlive = Cells[row, col] == ALIVE;
                    int neighbourCount = GetAliveNeighbourCount(GetNeighbours(row, col));
                    updatedCells[row, col] = GetNewState(isAlive, neighbourCount);
                }
            }

            Cells = updatedCells;
        }

        char[] GetNeighbours(int row, int col)
        {
            return new char[]
            {
                Cells[Mod(row - 1, Size), Mod(col - 1, Size)],
                Cells[Mod(row - 1, Size), col],
                Cells[Mod(row - 1, Size), Mod(col + 1, Size)],
                Cells[row, Mod(col - 1, Size)],
                Cells[row, Mod(col + 1, Size)],
                Cells[Mod(row + 1, Size), Mod(col - 1, Size)],
                Cells[Mod(row + 1, Size), col],
                Cells[Mod(row + 1, Size), Mod(col + 1, Size)],
            };
        }

        static int Mod(int dividend, int divisor)
        {
            int remainder = dividend % divisor;
            return remainder < 0 ? remainder + divisor : remainder;
        }

        static int GetAliveNeighbourCount(char[] neighbours)
        {
            int aliveNeighbourCount = 0;
            foreach (char cell in neighbours)
            {
                if (cell == ALIVE)
                {
                    aliveNeighbourCount++;
                }
            }

            return aliveNeighbourCount;
        }

        static char GetNewState(bool isAlive, int neighbourCount)
        {
            if (isAlive && (neighbourCount == 3 || neighbourCount == 2))
            {
                return ALIVE;
            }
            else if (!isAlive && neighbourCount == 3)
            {
                return ALIVE;
            }
            return DEAD;
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

                output.Append('\n');
            }

            Console.Write(output.ToString());
        }
    }
}
