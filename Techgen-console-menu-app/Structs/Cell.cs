namespace Techgen_console_menu_app.Structs
{
    public struct Cell
    {
        public int Row { get; }
        public int Col { get; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int ToIndex() => Row * 3 + Col;

        public Cell MoveUp() => Row > 0 ? new Cell(Row - 1, Col) : this;
        public Cell MoveDown() => Row < 2 ? new Cell(Row + 1, Col) : this;
        public Cell MoveLeft() => Col > 0 ? new Cell(Row, Col - 1) : this;
        public Cell MoveRight() => Col < 2 ? new Cell(Row, Col + 1) : this;
    }
}
