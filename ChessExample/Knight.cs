namespace ChessLibrary;

public class Knight : Piece
{
    public Knight(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Board board, Coord coord)
    {
        return new[]
        {
            new Coord(coord.X + 1, coord.Y + 2),
            new Coord(coord.X - 1, coord.Y + 2),
            new Coord(coord.X + 1, coord.Y - 2),
            new Coord(coord.X - 1, coord.Y - 2),

            new Coord(coord.X + 2, coord.Y + 1),
            new Coord(coord.X - 2, coord.Y + 1),
            new Coord(coord.X + 2, coord.Y - 1),
            new Coord(coord.X - 2, coord.Y - 1),
        };
    }

    public override Piece Copy()
    {
        return new Knight(Color);
    }

    public override string Name()
    {
        return "Knight";
    }

    public override bool Equals(Piece? other)
    {
        if (other == null) return false;
        if (other == this) return true;

        if (other is Knight)
        {
            var otherBishop = (Knight)other;
            if (otherBishop.Color == Color) return true;
        }

        return false;
    }
}