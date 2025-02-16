namespace ChessExample;

public class Knight : Piece
{
    public Knight(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        return new[]
        {
            new Coord(coord.X + 1, coord.Y + 3),
            new Coord(coord.X - 1, coord.Y + 3),
            new Coord(coord.X + 1, coord.Y - 3),
            new Coord(coord.X - 1, coord.Y - 3),

            new Coord(coord.X + 3, coord.Y + 1),
            new Coord(coord.X - 3, coord.Y + 1),
            new Coord(coord.X + 3, coord.Y - 1),
            new Coord(coord.X - 3, coord.Y - 1),
        };
    }

    public override Piece Copy()
    {
        return new Knight(Color);
    }
}