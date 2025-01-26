namespace ChessExample;

public class Bishop : Piece
{
    public Bishop(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        List<Coord> coords = new();

        for (int i = 0; i < Board.SIZE; i++)
        {
            coords.Add(new Coord(coord.X + i, coord.Y + i));
            coords.Add(new Coord(coord.X - i, coord.Y - i));
            coords.Add(new Coord(coord.X + i, coord.Y - i));
            coords.Add(new Coord(coord.X - i, coord.Y + i));
        }

        return coords.ToArray();
    }
}