namespace TicTacToe
{
    public static class View
    {
        public static int GetMoveOrSave(string[] board, int size)
        {
            int curRow = 0, curCol = 0;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null)
                {
                    curRow = i / size;
                    curCol = i % size;
                    break;
                }
            }

            while (true)
            {
                Console.SetCursorPosition(curCol * 4 + 2, curRow * 4 + 3);
                var keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(curCol * 4 + 2, curRow * 4 + 3);
                Console.Write(board[curRow * size + curCol] ?? " ");

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow: if (curCol > 0) curCol--; break;
                    case ConsoleKey.RightArrow: if (curCol + 1 < size) curCol++; break;
                    case ConsoleKey.UpArrow: if (curRow > 0) curRow--; break;
                    case ConsoleKey.DownArrow: if (curRow + 1 < size) curRow++; break;
                    case ConsoleKey.S: return -1;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (board[curRow * size + curCol] == null)
                            return curRow * size + curCol;
                        break;
                }
            }
        }

        public static void DrawBoard(string[] board)
        {
            var numRows = (int)Math.Sqrt(board.Length);
            Console.WriteLine();

            for (int row = 0; row < numRows; row++)
            {
                if (row != 0)
                    Console.WriteLine(" " + string.Join("|", Enumerable.Repeat("---", numRows)));

                Console.Write(" " + string.Join("|", Enumerable.Repeat("   ", numRows)) + "\n ");
                for (int col = 0; col < numRows; col++)
                {
                    if (col != 0) Console.Write("|");
                    var space = board[row * numRows + col] ?? " ";
                    if (space.Length > 1)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" " + space[0] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine("\n " + string.Join("|", Enumerable.Repeat("   ", numRows)));
            }

            Console.WriteLine();
        }

        public static void AnnounceResult(string message, string[] board)
        {
            Console.WriteLine();
            DrawBoard(board);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();

            Console.Write("\nPress any key to continue...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
        }
    }
}
