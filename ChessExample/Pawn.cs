namespace ChessLibrary;

public class Pawn : Piece
{
    public Pawn(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Board board, Coord coord)
    {
        List<Coord> coords = new();

        if (Color == PieceColor.White)
        {
            if (coord.Y == 6)
            {
                var possibleMove = new Coord(coord.X, coord.Y - 2);
                if (board.GetPiece(possibleMove) == null)
                {
                    coords.Add(possibleMove);
                }
            }

            coords.Add(new Coord(coord.X, coord.Y - 1));
        }

        if (Color == PieceColor.Black)
        {
            if (coord.Y == 1)
            {
                var possibleMove = new Coord(coord.X, coord.Y + 2);
                if(board.GetPiece(possibleMove) == null)
                {
                    coords.Add(possibleMove);
                }
            
            }

            coords.Add(new Coord(coord.X, coord.Y + 1));
        }


        return coords.ToArray();
    }

    public override Piece Copy()
    {
        return new Pawn(Color);
    }

    public override string Name()
    {
        return "Pawn";
    }

    public override bool Equals(Piece? other)
    {
        if (other == null) return false;
        if (other == this) return true;

        if (other is Pawn)
        {
            var otherBishop = (Pawn)other;
            if (otherBishop.Color == Color) return true;
        }

        return false;
    }
}