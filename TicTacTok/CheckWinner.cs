using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicTacTok.Program;

namespace TicTacTok
{
    internal class CheckWinner
    {
        public static GameStatus Check(char[] cells)
        {
            // Array holding all possible winning combinations (rows, columns, and diagonals)
            int[,] winningPatterns = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},  // Rows
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},  // Columns
                {0, 4, 8}, {2, 4, 6}              // Diagonals
            };

            // Check each winning combination
            for (int i = 0; i < winningPatterns.GetLength(0); i++)
            {
                if (cells[winningPatterns[i, 0]] == cells[winningPatterns[i, 1]] &&
                    cells[winningPatterns[i, 1]] == cells[winningPatterns[i, 2]])
                {
                    return GameStatus.Won; // If there's a match, someone won
                }
            }

            return GameStatus.Undecided; // No one won yet
        }
    }
}
