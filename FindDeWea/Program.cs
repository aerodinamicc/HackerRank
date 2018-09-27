using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDeWea
{
    public class Program
    {
        private const string NO_PASS_SYMBOL = "X";
        private const string PASS = ".";

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string[,] grid = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                var gridItem = Console.ReadLine().Split(' ').ToArray();
                for (int element = 0; element < gridItem.Length; element++)
                {
                    grid[i, element] = gridItem[element];
                }
            }

            string[] startXStartY = Console.ReadLine().Split(' ');

            int startX = Convert.ToInt32(startXStartY[0]);

            int startY = Convert.ToInt32(startXStartY[1]);

            int goalX = Convert.ToInt32(startXStartY[2]);

            int goalY = Convert.ToInt32(startXStartY[3]);

            int result = minimumMoves(grid, startX, startY, goalX, goalY);

            Console.WriteLine(result);
        }

        public static int minimumMoves(string[,] grid, int startX, int startY, int goalX, int goalY)
        {
            int counter = 0;

            if (startX == goalX && startY == goalY)
            {
                return 1;
            }

            int up = MoveUp(grid, startX, startY, goalX, goalY);
            int left = MoveLeft(grid, startX, startY, goalX, goalY);
            int down = MoveDown(grid, startX, startY, goalX, goalY);
            int right = MoveRight(grid, startX, startY, goalX, goalY);

            counter += Math.Min(Math.Min(up, left), Math.Min(down, right));

            return counter;
        }

        private static int MoveRight(string[,] grid, int startX, int startY, int goalX, int goalY)
        {
            while (startX + 1 < grid.GetLength(0) && grid[startX + 1, startY] == PASS)
            {
                startX += 1;
            }

            return minimumMoves(grid, startX, startY, goalX, goalY);
        }

        private static int MoveDown(string[,] grid, int startX, int startY, int goalX, int goalY)
        {
            while (startY + 1 < grid.GetLength(1) && grid[startX, startY + 1] != NO_PASS_SYMBOL)
            {
                startY += 1;
            }

            return minimumMoves(grid, startX, startY, goalX, goalY);
        }

        private static int MoveLeft(string[,] grid, int startX, int startY, int goalX, int goalY)
        {
            while (startX - 1 > 0 && grid[startX - 1, startY] != NO_PASS_SYMBOL)
            {
                startX -= 1;
            }

            return minimumMoves(grid, startX, startY, goalX, goalY);
        }

        private static int MoveUp(string[,] grid, int startX, int startY, int goalX, int goalY)
        {
            while (startY - 1 > 0 && grid[startX, startY] != NO_PASS_SYMBOL)
            {
                startY -= 1;
            }

            return minimumMoves(grid, startX, startY, goalX, goalY);
        }
    }
}
