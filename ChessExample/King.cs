namespace ChessExample;

public class King : Piece
{
    public King(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        return
        [
            new Coord(coord.X - 1, coord.Y - 1),
            new Coord(coord.X - 1, coord.Y),
            new Coord(coord.X - 1, coord.Y + 1),
            new Coord(coord.X, coord.Y - 1),
            new Coord(coord.X, coord.Y + 1),
            new Coord(coord.X + 1, coord.Y - 1),
            new Coord(coord.X + 1, coord.Y),
            new Coord(coord.X + 1, coord.Y + 1),
        ];
    }

    public override Piece Copy()
    {
        return new King(Color);
    }
}