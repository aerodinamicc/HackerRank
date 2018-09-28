using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int n = Int32.Parse(Console.ReadLine());

        char[,] grid = new char[n,n];

        for (int i = 0; i < n; i++)
        {
            var chars = Console.ReadLine().ToCharArray();
            for (int j = 0; j < n; j++)
            {
                grid[i, j] = chars[j];
            }
        }
            

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
        var pStart = new Point(arr[0], arr[1]);
        var pTarget = new Point(arr[2], arr[3]);

        int count = BFS(grid, pStart, pTarget);

        Console.WriteLine(count);
    }

    public static int BFS(char[,] grid, Point pStart, Point pTarget)
    {
        var queue = new Queue<Point>();
        queue.Enqueue(pStart);

        grid[pStart.Y,pStart.X] = '*';

        while (queue.Any())
        {
            Point pCurrent = queue.Dequeue();

            if (pCurrent.Y == pTarget.Y && pCurrent.X == pTarget.X)
                return pCurrent.Depth;

            for (int y = pCurrent.Y - 1; y >= 0 && grid[y,pCurrent.X] != 'X'; y--)
            {
                if (grid[y,pCurrent.X] != '*')
                {
                    queue.Enqueue(new Point(y, pCurrent.X, pCurrent.Depth + 1));
                    grid[y,pCurrent.X] = '*';
                }
            }

            for (int y = pCurrent.Y + 1; y < grid.GetLength(1) && grid[y,pCurrent.X] != 'X'; y++)
            {
                if (grid[y,pCurrent.X] != '*')
                {
                    queue.Enqueue(new Point(y, pCurrent.X, pCurrent.Depth + 1));
                    grid[y,pCurrent.X] = '*';
                }
            }

            for (int x = pCurrent.X - 1; x >= 0 && grid[pCurrent.Y,x] != 'X'; x--)
            {
                if (grid[pCurrent.Y,x] != '*')
                {
                    queue.Enqueue(new Point(pCurrent.Y, x, pCurrent.Depth + 1));
                    grid[pCurrent.Y,x] = '*';
                }
            }

            for (int x = pCurrent.X + 1; x < grid.GetLength(0) && grid[pCurrent.Y, x] != 'X'; x++)
            {
                if (grid[pCurrent.Y,x] != '*')
                {
                    queue.Enqueue(new Point(pCurrent.Y, x, pCurrent.Depth + 1));
                    grid[pCurrent.Y,x] = '*';
                }
            }
        }

        return -1;
    }
}

struct Point
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Depth { get; private set; }

    public Point(int y, int x)
    {
        Y = y;
        X = x;
        Depth = 0;
    }

    public Point(int y, int x, int depth) : this(y, x)
    {
        Depth = depth;
    }
}