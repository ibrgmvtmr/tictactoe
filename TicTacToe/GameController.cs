namespace TicTacToe
{
    public class GameController
    {
        private TicTacToeGame game;

        public void StartNewGame(int size)
        {
            game = new TicTacToeGame(size);
            GameLoop();
        }

        public void ContinueGame()
        {
            game = new TicTacToeGame(3); 
            game.Load();
            GameLoop();
        }

        private void GameLoop()
        {
            string turn = game.GetNextTurn();

            while (true)
            {
                Console.Clear();
                var winner = game.CheckWinner();
                if (winner != null)
                {
                    View.AnnounceResult(winner[0] + " WINS!!!", game.Board);
                    TicTacToeGame.DeleteSave();
                    break;
                }

                if (game.IsBoardFull())
                {
                    View.AnnounceResult("It's a tie!!!", game.Board);
                    TicTacToeGame.DeleteSave();
                    break;
                }

                Console.WriteLine($"Place your {turn} (Press S to save and quit):");
                View.DrawBoard(game.Board);
                Console.WriteLine("\nUse the arrow keys and press <enter>");

                var result = View.GetMoveOrSave(game.Board, game.Size);

                if (result == -1)
                {
                    game.Save();
                    Console.WriteLine("Game saved! Returning to main menu...");
                    Console.ReadKey();
                    break;
                }

                game.Board[result] = turn;
                game.Save();
                turn = turn == "X" ? "O" : "X";
            }
        }
    }
}