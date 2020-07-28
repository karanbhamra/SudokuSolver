using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace SudokuSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = LoadFileToArray("input.txt");
            var solver = new SudokuSolver(board);

            var stopwatch = Stopwatch.StartNew();
            
            var result = solver.Solve();
            
            stopwatch.Stop();

            var timeTaken = stopwatch.ElapsedMilliseconds;
            
            if (result)
            {
                solver.PrintBoard();
                Console.WriteLine($"Took {timeTaken}ms.");
            }
            else
            {
                Console.WriteLine("Cannot solve.");
            }
        }

        private static int[][] LoadFileToArray(string filename)
        {
            const int size = 9;
            var board = new int[size][];

            var fileLines = File.ReadAllLines(filename);

            var row = 0;
            foreach (var line in fileLines)
            {
                board[row] = line.Select(x => x - '0').ToArray();
                row++;
            }

            return board;
        }
    }
}