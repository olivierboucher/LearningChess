namespace ChessExample;

public class Pawn : Piece
{
    public Pawn(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        List<Coord> coords = new();

        if (Color == PieceColor.White)
        {
            if (coord.Y == 1)
            {
                coords.Add(new Coord(coord.X, coord.Y + 2));
            }

            coords.Add(new Coord(coord.X, coord.Y + 1));
        }

        if (Color == PieceColor.Black)
        {
            if (coord.Y == Board.SIZE - 2)
            {
                coords.Add(new Coord(coord.X, coord.Y - 2));
            }

            coords.Add(new Coord(coord.X, coord.Y - 1));
        }


        return coords.ToArray();
    }

    public override Piece Copy()
    {
        return new Pawn(Color);
    }
}