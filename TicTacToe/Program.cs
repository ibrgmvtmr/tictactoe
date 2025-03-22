using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GameController();
            bool stillPlaying = true;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("-----------------------");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("-----------------------\n");
            Console.ResetColor();

            while (stillPlaying)
            {
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("1. Start a new game");
                Console.WriteLine("2. Continue last saved game");
                Console.WriteLine("3. Quit\n");
                Console.Write("Type a number and hit <enter>: ");

                var choice = GetUserInput("[123]");

                switch (choice)
                {
                    case "1":
                        string numRowsChoice = null;
                        while (numRowsChoice == null)
                        {
                            Console.Write("How many rows? (3, 4, or 5): ");
                            numRowsChoice = GetUserInput("[345]");
                        }
                        controller.StartNewGame(int.Parse(numRowsChoice));
                        Console.Clear();
                        break;
                    case "2":
                        if (TicTacToeGame.HasSave())
                        {
                            controller.ContinueGame();
                        }
                        else
                        {
                            Console.WriteLine("No saved game found.");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    case "3":
                        stillPlaying = false;
                        break;
                }
            }
        }

        private static string GetUserInput(string validPattern = null)
        {
            var input = Console.ReadLine()?.Trim();
            if (validPattern != null && !Regex.IsMatch(input, validPattern))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\"{input}\" is not valid.\n");
                Console.ResetColor();
                return null;
            }
            return input;
        }
    }
}
