namespace ChessLibrary;

public class King : Piece
{
    public King(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Board board, Coord coord)
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

    public override string Name()
    {
        return "King";
    }

    public override bool Equals(Piece? other)
    {
        if (other == null) return false;
        if (other == this) return true;

        if (other is King)
        {
            var otherBishop = (King)other;
            if (otherBishop.Color == Color) return true;
        }

        return false;
    }
}