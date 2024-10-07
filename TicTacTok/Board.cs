using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTok
{
    internal class Board
    {

        string text = @"
 __ __| _)           __ __|                __ __|            
    |    |   __|        |   _` |   __|        |   _ \    _ \ 
    |    |  (           |  (   |  (           |  (   |   __/ 
   _|   _| \___|       _| \__,_| \___|       _| \___/  \___| 
                                                             ";

        string CenterText(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int spaces = (consoleWidth - text.Length) / 2;
            return new string(' ', spaces) + text;
        }
        private char[] cells = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public void DrawBoard()
        {

            int consoleWidth = Console.WindowWidth;

            // Split the text into lines
            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                // Calculate the number of spaces needed to center the line
                int spacesToPad = (consoleWidth - line.Length) / 2;

                // Create a padded line with leading spaces
                string centeredLine = new string(' ', spacesToPad) + line;
                string textColor = "\u001b[38;2;65;105;225m";
                // Write the centered line to the console
                Console.WriteLine(textColor+centeredLine);
            }
            string borderColor = "\u001b[38;2;148;0;211m";
            // Set border color
            Console.WriteLine(CenterText($"{borderColor}┌─────────────┬─────────────┬─────────────┐"));

            // Set symbol color
            Console.WriteLine(CenterText($"{borderColor}│      {GetSymbol(cells[0])}      │      {GetSymbol(cells[1])}      │      {GetSymbol(cells[2])}      │"));

            // Set border color
            Console.WriteLine(CenterText($"{borderColor}├─────────────┼─────────────┼─────────────┤"));

            // Set symbol color
            Console.WriteLine(CenterText($"{borderColor}│      {GetSymbol(cells[3])}      │      {GetSymbol(cells[4])}      │      {GetSymbol(cells[5])}      │"));

            // Set border color
            Console.WriteLine(CenterText($"{borderColor}├─────────────┼─────────────┼─────────────┤"));

            // Set symbol color
            Console.WriteLine(CenterText($"{borderColor}│      {GetSymbol(cells[6])}      │      {GetSymbol(cells[7])}      │      {GetSymbol(cells[8])}      │"));

            // Set border color
            Console.WriteLine(CenterText($"{borderColor}└─────────────┴─────────────┴─────────────┘"));

            // Reset color
            Console.ResetColor();
        }

        private string GetSymbol(char cell)
        {
            switch (cell)
            {
                case 'X':
                    
                    return "X";  // Display X as a red cross emoji
                case 'O':
                    return "O";  // Display O as a blue circle emoji
                default:
                    return cell.ToString();  // Display the number if the cell is not yet occupied
            }
        }
        public bool IsMoveLegal(int move)
        {
            // Get the cell at the index corresponding to the move
            char cell = cells[move - 1];

            // Check if the cell is occupied by 'X' or 'O'
            if (cell == 'X' || cell == 'O')
            {
                return false;  // If the cell is already occupied, the move is not legal
            }
            else
            {
                return true;  // If the cell is not occupied, the move is legal
            }
        }

        public void DoMove(int move, char playerSymbol)
        {
            // If the move is valid (the cell is not taken by 'X' or 'O')
            if (IsMoveLegal(move))
            {
                // Place the player's symbol (X or O) in the chosen cell
                cells[move - 1] = playerSymbol;
            }
        }
        // Method to check if all the board cells are filled
        public bool IsFull()
        {
            foreach (char cell in cells)
            {
                if (char.IsDigit(cell)) // If any cell still has a number, the board isn't full yet
                    return false;
            }
            return true; // If no numbers left, the board is full
        }
        // Get the current board cells (useful for checking the winner)
        public char[] GetCells()
        {
            return cells;
        }
    }

}
