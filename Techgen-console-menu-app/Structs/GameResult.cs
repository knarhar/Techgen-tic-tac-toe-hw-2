namespace Techgen_console_menu_app.Structs
{
    public struct GameResult
    {
        public bool IsFinished { get; }
        public bool IsDraw { get; }
        public char WinnerSign { get; }

        private GameResult(bool isFinished, bool isDraw, char winnerSign)
        {
            IsFinished = isFinished;
            IsDraw = isDraw;
            WinnerSign = winnerSign;
        }

        public static GameResult NotFinished() => new GameResult(false, false, '\0');
        public static GameResult Draw() => new GameResult(true, true, '\0');
        public static GameResult Win(char sign) => new GameResult(true, false, sign);
    }
}
