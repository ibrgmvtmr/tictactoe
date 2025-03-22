namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int Size { get; private set; }
        public string[] Board { get; set; }
        private const string SaveFileName = "save.txt";

        public TicTacToeGame(int size)
        {
            Size = size; Board = new string[size * size];
        }

        public void Load()
        {
            var lines = File.ReadAllLines(SaveFileName);
            Size = int.Parse(lines[0]);
            Board = new string[Size * Size];
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var symbol = lines[row + 1][col];
                    Board[row * Size + col] = symbol switch
                    {
                        'X' => "X",
                        'O' => "O",
                        _ => null
                    };
                }
            }
        }

        public void Save()
        {
            using (var writer = new StreamWriter(SaveFileName))
            {
                writer.WriteLine(Size);
                for (int i = 0; i < Board.Length; i++)
                {
                    writer.Write(Board[i] ?? ".");
                    if ((i + 1) % Size == 0)
                        writer.WriteLine();
                }
            }
        }

        public bool IsBoardFull() => Board.All(space => space != null);

        public string GetNextTurn()
        {
            int xCount = Board.Count(cell => cell == "X");
            int oCount = Board.Count(cell => cell == "O");
            return xCount <= oCount ? "X" : "O";
        }

        public string CheckWinner()
        {
            int numRows = Size;
            for (int row = 0; row < numRows; row++)
            {
                if (Board[row * numRows] != null &&
                    Enumerable.Range(0, numRows).All(col => Board[row * numRows + col] == Board[row * numRows]))
                {
                    MarkWinning(row, true);
                    return Board[row * numRows];
                }
            }

            for (int col = 0; col < numRows; col++)
            {
                if (Board[col] != null &&
                    Enumerable.Range(0, numRows).All(row => Board[row * numRows + col] == Board[col]))
                {
                    MarkWinning(col, false);
                    return Board[col];
                }
            }

            if (Board[0] != null &&
                Enumerable.Range(0, numRows).All(row => Board[row * numRows + row] == Board[0]))
            {
                for (int i = 0; i < numRows; i++)
                    Board[i * numRows + i] += "!";
                return Board[0];
            }

            if (Board[numRows - 1] != null &&
                Enumerable.Range(0, numRows).All(row => Board[row * numRows + (numRows - 1 - row)] == Board[numRows - 1]))
            {
                for (int i = 0; i < numRows; i++)
                    Board[i * numRows + (numRows - 1 - i)] += "!";
                return Board[numRows - 1];
            }

            return null;
        }

        private void MarkWinning(int index, bool isRow)
        {
            for (int i = 0; i < Size; i++)
            {
                if (isRow)
                    Board[index * Size + i] += "!";
                else
                    Board[i * Size + index] += "!";
            }
        }

        public static bool HasSave() => File.Exists(SaveFileName);
        public static void DeleteSave() => File.Delete(SaveFileName);
    }
}
