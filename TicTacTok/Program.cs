namespace TicTacTok
{
    internal class Program
    {
        public enum GameStatus { Undecided, Won, Draw }

        static void Main(string[] args)
        {

            Console.WriteLine("Spelare X, ange ditt spelnamn: ");
            string usernameX = Console.ReadLine();
            Console.WriteLine($"Tjena, {usernameX}! Du kommer vara spelare X.");


            Console.WriteLine("Spelare O, ange ditt spelnamn: ");
            string usernameO = Console.ReadLine();
            Console.WriteLine($"Tjena, {usernameO}! Du kommer vara spelare O.");

            // Initialize the game board
            Board board = new Board();

            Player playerX = new Player(usernameX, 'X');
            Player playerO = new Player(usernameO, 'O');
            Player currentPlayer = playerX;

            GameStatus gameState = GameStatus.Undecided;


            while (gameState == GameStatus.Undecided && !board.IsFull())
            {
                Console.Clear();
                board.DrawBoard();

                Console.WriteLine($"{currentPlayer.Name}, Nu äre dags!");
                int move = currentPlayer.GetMove();
                if (board.IsMoveLegal(move))
                {
                    board.DoMove(move, currentPlayer.Symbol);
                    gameState = CheckWinner.Check(board.GetCells());
                    if (gameState == GameStatus.Undecided)
                    {
                        currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig rörelse, försök igen!");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            board.DrawBoard();
            if (gameState == GameStatus.Won)
            {
                Console.WriteLine($"{currentPlayer.Name} ({currentPlayer.Symbol}) vinner, skitbra spelat {currentPlayer.Name}!");
            }
            else
            {
                Console.WriteLine("Ingen vinner, tyvärr!");
            }
        }
    }
}
