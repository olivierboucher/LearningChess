namespace ChessLibrary;

public class Queen : Piece
{
    public Queen(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Board board, Coord coord)
    {
        List<Coord> coords = new();

        //Bishop
        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X + i, coord.Y + i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X - i, coord.Y - i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X + i, coord.Y - i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }


        for (int i = 1; i < Board.SIZE; i++)
        {
            var possibleMove = new Coord(coord.X - i, coord.Y + i);
            coords.Add(possibleMove);

            if (board.GetPiece(possibleMove) != null)
            {
                break;
            }
        }

        //Rook
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
        return new Queen(Color);
    }

    public override string Name()
    {
        return "Queen";
    }

    public override bool Equals(Piece? other)
    {
        if (other == null) return false;
        if (other == this) return true;

        if (other is Queen)
        {
            var otherBishop = (Queen)other;
            if (otherBishop.Color == Color) return true;
        }

        return false;
    }
}