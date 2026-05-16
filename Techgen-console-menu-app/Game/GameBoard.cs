using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Game
{
    public class GameBoard : IRenderable
    {
        private char[] _cells;
        private Cell _cursor;

        public GameBoard()
        {
            _cells = new char[9];
            _cursor = new Cell(0, 0);
        }

        public void MoveCursor(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow: _cursor = _cursor.MoveUp(); break;
                case ConsoleKey.DownArrow: _cursor = _cursor.MoveDown(); break;
                case ConsoleKey.LeftArrow: _cursor = _cursor.MoveLeft(); break;
                case ConsoleKey.RightArrow: _cursor = _cursor.MoveRight(); break;
            }
        }

        public bool TryPlaceSign(char sign)
        {
            int index = _cursor.ToIndex();
            if (_cells[index] != '\0') return false;
            _cells[index] = sign;
            return true;
        }

        public void PlaceSignAt(int index, char sign)
        {
            _cells[index] = sign;
        }

        public char[] GetCells() => _cells;
        public Cell GetCursor() => _cursor;

        public void ClearCells()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = '\0';
            }
        }

        public GameResult CheckResult()
        {
            int[][] wins = {
                new[]{0,1,2}, new[]{3,4,5}, new[]{6,7,8},
                new[]{0,3,6}, new[]{1,4,7}, new[]{2,5,8},
                new[]{0,4,8}, new[]{2,4,6}
            };

            foreach (var combo in wins)
            {
                char a = _cells[combo[0]];
                char b = _cells[combo[1]];
                char c = _cells[combo[2]];

                if (a != '\0' && a == b && b == c)
                    return GameResult.Win(a);
            }

            foreach (var cell in _cells)
                if (cell == '\0')
                    return GameResult.NotFinished();

            return GameResult.Draw();
        }

        public void Render(string player1Name, char player1Sign, string player2Name, char player2Sign, string currentPlayerName, char currentPlayerSign)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player1Name} ({player1Sign}) vs {player2Name} ({player2Sign})");
            Console.ResetColor();
            Console.WriteLine();

            for (int row = 0; row < 3; row++)
            {
                Console.Write("  ");
                for (int col = 0; col < 3; col++)
                {
                    int index = row * 3 + col;
                    bool isCursor = (_cursor.Row == row && _cursor.Col == col);

                    if (isCursor)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    char cell = _cells[index];
                    if (cell == '\0')
                        Console.Write($" {index + 1} ");
                    else
                        Console.Write($" {cell} ");

                    Console.ResetColor();

                    if (col < 2)
                        Console.Write(" | ");
                }
                Console.WriteLine();
                if (row < 2)
                    Console.WriteLine(" -----+-----+-----");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current Turn: {currentPlayerName} ({currentPlayerSign})");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Use Arrow Keys to navigate,\nEnter to place {currentPlayerSign}");
        }
    }
}
