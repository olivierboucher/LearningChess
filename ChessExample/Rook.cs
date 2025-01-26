namespace ChessExample;

public class Rook : Piece
{
    public Rook(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        List<Coord> coords = new();

        for (int i = 0; i < Board.SIZE; i++)
        {
            coords.Add(new Coord(coord.X + i, coord.Y));
            coords.Add(new Coord(coord.X - i, coord.Y));
            coords.Add(new Coord(coord.X, coord.Y + i));
            coords.Add(new Coord(coord.X, coord.Y - i));
        }

        return coords.ToArray();
    }
}