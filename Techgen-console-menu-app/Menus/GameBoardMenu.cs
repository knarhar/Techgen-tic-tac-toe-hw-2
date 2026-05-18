using MenuLib;
using Techgen_console_menu_app.Contracts;
using Techgen_console_menu_app.Core;
using Techgen_console_menu_app.Enums;
using Techgen_console_menu_app.Game;
using Techgen_console_menu_app.Structs;

namespace Techgen_console_menu_app.Menus
{
    public class GameBoardMenu : Menu
    {
        private readonly GameBoard _board;
        private readonly IGamePlayer[] _players;
        private int _currentPlayerIndex;

        public GameBoardMenu() : base("Tic Tac Toe")
        {
            _board = new GameBoard();
            _currentPlayerIndex = 0;
            _players = new IGamePlayer[2];
            _players[0] = new HumanPlayer(Session.Username1, Session.Player1Sign);
            _players[1] = Session.GameMode == GameModeTypes.PvP
                ? (IGamePlayer)new HumanPlayer(Session.Username2, Session.Player2Sign)
                : new ComputerPlayer(Session.Player2Sign);
        }

        protected override void InternalDisplay() { }

        public override NavigationResult Display()
        {
            RunGame();
            _board.ClearCells();
            return NavigationResult.GoTo(new MainMenu());
        }

        private void RunGame()
        {
            while (true)
            {
                IGamePlayer current = _players[_currentPlayerIndex];

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{_players[0].Name} ({_players[0].Sign}) vs {_players[1].Name} ({_players[1].Sign})");
                Console.ResetColor();
                Console.WriteLine();
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
                        if (!placed) continue;
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(result.IsDraw ? "It's a draw!" : $"{current.Name} ({current.Sign}) wins!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey(true);
                    return;
                }

                _currentPlayerIndex = (_currentPlayerIndex + 1) % 2;
            }
        }

        protected override NavigationResult HandleOption(string option)
        {
            return NavigationResult.None();
        }
    }
}
