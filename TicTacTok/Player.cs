using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTok
{
    internal class Player
    {
        public char Symbol { get; set; } // The symbol for the player, either 'X' or 'O'

        // Constructor to create a player with a specific symbol x and o
        public Player(char symbol)
        {
            Symbol = symbol;
        }

        // Method to ask the player to choose a move (1-9)
        public int GetMove()
        {
            Console.WriteLine($"Player {Symbol}, enter a number between 1 and 9 for your move: ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9)
            {
                Console.WriteLine("Invalid input! Please enter a valid number between 1 and 9.");
            }
            return move;
        }
    }
}
