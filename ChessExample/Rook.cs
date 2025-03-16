namespace ChessLibrary;

public class Rook : Piece
{
    public Rook(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Board board, Coord coord)
    {
        List<Coord> coords = new();

        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X + i, coord.Y);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X - i, coord.Y);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X, coord.Y + i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X, coord.Y - i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }

        return coords.ToArray();
    }

    public override Piece Copy()
    {
        return new Rook(Color);
    }

    public override string Name()
    {
        return "Rook";
    }

    public override bool Equals(Piece? other)
    {
        if (other == null) return false;
        if (other == this) return true;

        if (other is Rook)
        {
            var otherBishop = (Rook)other;
            if (otherBishop.Color == Color) return true;
        }

        return false;
    }
}