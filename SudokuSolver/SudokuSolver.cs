using System;

namespace SudokuSolver
{
    // 800000000
    // 003600000
    // 070090200
    // 050007000
    // 000045700
    // 000100030
    // 001000068
    // 008500010
    // 090000400
    public class SudokuSolver
    {
        private readonly int[][] _board;
        private const int Size = 9;

        public SudokuSolver(int[][] board)
        {
            _board = board;
        }

        public void PrintBoard()
        {
            for (var row = 0; row < Size; row++)
            {
                for (var col = 0; col < Size; col++)
                {
                    var ch = ' ';
                    if ((col + 1) % 3 == 0 && col > 0)
                    {
                        ch = '\t';
                    }

                    Console.Write($"{_board[row][col]}{ch}");
                }

                if ((row + 1) % 3 == 0 && row > 0 && row < Size - 1)
                {
                    Console.WriteLine();
                }

                if (row < Size)
                {
                    Console.WriteLine();
                }
            }
        }

        public bool Solve()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (_board[row][col] == 0) // empty
                    {
                        for (int guess = 1; guess <= 9; guess++)
                        {
                            if (IsValid(row, col, guess))
                            {
                                _board[row][col] = guess;

                                if (Solve())
                                {
                                    return true;
                                }
                                else
                                {
                                    _board[row][col] = 0;
                                }
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValid(int row, int col, int guess)
        {
            return IsRowValid(row, guess) &&
                   IsColValid(col, guess) &&
                   IsSquareValid(row, col, guess);
        }

        private bool IsRowValid(int row, int guess)
        {
            for (var col = 0; col < Size; col++)
            {
                if (_board[row][col] == guess)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsColValid(int col, int guess)
        {
            for (var row = 0; row < Size; row++)
            {
                if (_board[row][col] == guess)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSquareValid(int row, int col, int guess)
        {
            var r = row - row % 3;
            var c = col - col % 3;

            for (var i = r; i < r + 3; i++)
            {
                for (var j = c; j < c + 3; j++)
                {
                    if (_board[i][j] == guess)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}