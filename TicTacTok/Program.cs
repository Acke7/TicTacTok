namespace TicTacTok
{
    internal class Program
    {
        public enum GameStatus { Undecided, Won, Draw }
        static void Main(string[] args)
        {
            
                // Get  game board
                Board board = new Board();

                // Create two players: Player 'X' and Player 'O'
                Player playerX = new Player('X');
                Player playerO = new Player('O');
                Player currentPlayer = playerX; // Player 'X' goes first
                
                // The current state of the game, starting as undecided
                GameStatus gameState = GameStatus.Undecided;

                // The main game loop, running while no one has won and the board is not full
                while (gameState == GameStatus.Undecided && !board.IsFull())
                {
                    Console.Clear(); // Clear the console before each turn
                    board.DrawBoard(); // Show the board

                    // Get the current player's move
                    int move = currentPlayer.GetMove();
                    // If the move is legal, apply it
                    if (board.IsMoveLegal(move))
                    {
                        board.DoMove(move, currentPlayer.Symbol); // Update the board
                        gameState = CheckWinner.Check(board.GetCells()); // Check if there's a winner

                        // Switch to the other player if the game isn't over yet
                        if (gameState == GameStatus.Undecided)
                        {
                        if (currentPlayer == playerX)
                        {
                            currentPlayer = playerO;
                        }
                        else
                        {
                            currentPlayer = playerX;
                        }
                    }
        }
                        else
                        {
                        Console.WriteLine("Invalid move! Try again.");
                        Console.ReadKey(); // Wait for the player to press a key before continuing
                        }
                }

                Console.Clear(); // Clear the console after the game ends
                board.DrawBoard(); // Show the final board
                // Display the result of the game
                if (gameState == GameStatus.Won)
                {
                    Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }
            } 
    }
}
