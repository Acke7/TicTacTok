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
        public string Name { get; set; } // Player's username
                                         // Constructor to create a player with a specific symbol x and o
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        string CenterText(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int spaces = (consoleWidth - text.Length) / 2;
            return new string(' ', spaces) + text;
        }
        // Method to ask the player to choose a move (1-9)
        public int GetMove()
        {
          
            string borderColor2 = "\u001b[38;5;240m";
            Console.WriteLine();
            Console.WriteLine(CenterText($"{borderColor2}Player {Name} {Symbol}, enter a number between 1 and 9 for your move: "));
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9)
            {
                Console.WriteLine(CenterText($"{borderColor2} input! Please enter a valid number between 1 and 9."));
            }
            return move;
        }
    }
}
