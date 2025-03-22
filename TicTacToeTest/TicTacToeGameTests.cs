namespace TicTacToe.Tests
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void Should_Create_Empty_Board_With_Correct_Size()
        {
            var game = new TicTacToeGame(3);

            Assert.Equal(9, game.Board.Length);
            Assert.All(game.Board, cell => Assert.Null(cell));
        }

        [Fact]
        public void Should_Determine_First_Turn_As_X()
        {
            var game = new TicTacToeGame(3);

            Assert.Equal("X", game.GetNextTurn());
        }

        [Fact]
        public void Should_Alternate_Turns_Based_On_Board()
        {
            var game = new TicTacToeGame(3);
            game.Board[0] = "X";

            Assert.Equal("O", game.GetNextTurn());

            game.Board[1] = "O";
            Assert.Equal("X", game.GetNextTurn());
        }

        [Fact]
        public void Should_Detect_Winner_On_Row()
        {
            var game = new TicTacToeGame(3);
            game.Board[0] = "X";
            game.Board[1] = "X";
            game.Board[2] = "X";

            var winner = game.CheckWinner();
            Assert.StartsWith("X", winner);
        }

        [Fact]
        public void Should_Detect_Winner_On_Column()
        {
            var game = new TicTacToeGame(3);
            game.Board[0] = "O";
            game.Board[3] = "O";
            game.Board[6] = "O";

            var winner = game.CheckWinner();
            Assert.StartsWith("O", winner);
        }

        [Fact]
        public void Should_Detect_Winner_On_Diagonal()
        {
            var game = new TicTacToeGame(3);
            game.Board[0] = "X";
            game.Board[4] = "X";
            game.Board[8] = "X";

            var winner = game.CheckWinner();
            Assert.StartsWith("X", winner);
        }

        [Fact]
        public void Should_Detect_Winner_On_Reverse_Diagonal()
        {
            var game = new TicTacToeGame(3);
            game.Board[2] = "O";
            game.Board[4] = "O";
            game.Board[6] = "O";

            var winner = game.CheckWinner();
            Assert.StartsWith("O", winner);
        }

        [Fact]
        public void Should_Detect_Draw_When_Board_Full_And_No_Winner()
        {
            var game = new TicTacToeGame(3);
            game.Board = new string[]
            {
                "X", "O", "X",
                "X", "O", "O",
                "O", "X", "X"
            };

            Assert.Null(game.CheckWinner());
            Assert.True(game.IsBoardFull());
        }

        [Fact]
        public void Should_Save_And_Load_Game()
        {
            var game = new TicTacToeGame(3);
            game.Board[0] = "X";
            game.Board[4] = "O";
            game.Save();

            var loadedGame = new TicTacToeGame(3);
            loadedGame.Load();

            Assert.Equal(game.Size, loadedGame.Size);
            Assert.Equal(game.Board, loadedGame.Board);

            TicTacToeGame.DeleteSave();
        }
    }
}
