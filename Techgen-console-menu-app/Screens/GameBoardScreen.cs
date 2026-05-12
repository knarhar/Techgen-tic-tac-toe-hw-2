using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Game;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Screens
{
    public class GameBoardScreen : BaseScreen
    {
        private readonly GameBoard _board;
        private readonly IGamePlayer[] _players;
        private int _currentPlayerIndex;

        public GameBoardScreen() : base("Tic Tac Toe")
        {
            _board = new GameBoard();
            _currentPlayerIndex = 0;

            _players = new IGamePlayer[2];
            _players[0] = new HumanPlayer(Session.Username, Session.Player1Sign);

            if (Session.GameMode == GameModeTypes.PvP)
                _players[1] = new HumanPlayer("Player 2", Session.Player2Sign);
            else
                _players[1] = new ComputerPlayer(Session.Player2Sign);
        }

        protected override void RenderContent() { }

        protected override ScreenResult HandleOption(string input)
        {
            return ScreenResult.None();
        }

        public ScreenResult Run()
        {
            while (true)
            {
                IGamePlayer current = _players[_currentPlayerIndex];

                _board.Render(
                    _players[0].Name, _players[0].Sign,
                    _players[1].Name, _players[1].Sign,
                    current.Name, current.Sign
                );

                if (current is ComputerPlayer)
                {
                    Thread.Sleep(600);
                    int aiIndex = current.GetMove(_board.GetCells(), _board.GetCursor());
                    _board.PlaceSignAt(aiIndex, current.Sign);
                }
                else
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Enter)
                    {
                        bool placed = _board.TryPlaceSign(current.Sign);
                        if (!placed)
                        {
                            Console.WriteLine("Cell is taken! Press any key...");
                            Console.ReadKey(true);
                            continue;
                        }
                    }
                    else
                    {
                        _board.MoveCursor(key);
                        continue;
                    }
                }

                GameResult result = _board.CheckResult();

                if (result.IsFinished)
                {
                    Console.Clear();
                    _board.Render(
                        _players[0].Name, _players[0].Sign,
                        _players[1].Name, _players[1].Sign,
                        current.Name, current.Sign
                    );
                    Console.WriteLine();

                    if (result.IsDraw)
                        Console.WriteLine("It's a draw!");
                    else
                        Console.WriteLine($"{current.Name} ({current.Sign}) wins!");

                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey(true);
                    return ScreenResult.Back();
                }

                _currentPlayerIndex = (_currentPlayerIndex + 1) % 2;
            }
        }
    }
}

