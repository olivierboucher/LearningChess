namespace ChessExample;

public class Queen: Piece
{
    public Queen(PieceColor color) : base(color)
    {
    }

    public override Coord[] GetAvailableMoves(Coord coord)
    {
        List<Coord> coords = new();

        for (int i = 0; i < Board.SIZE; i++)
        {
            //Bishop
            coords.Add(new Coord(coord.X + i, coord.Y + i));
            coords.Add(new Coord(coord.X - i, coord.Y - i));
            coords.Add(new Coord(coord.X +i, coord.Y - i));
            coords.Add(new Coord(coord.X - i, coord.Y + i));
            
            //Rook
            coords.Add(new Coord(coord.X + i, coord.Y));
            coords.Add(new Coord(coord.X - i, coord.Y));
            coords.Add(new Coord(coord.X, coord.Y + i));
            coords.Add(new Coord(coord.X, coord.Y - i));
        }

        return coords.ToArray();
    }

    public override Piece Copy()
    {
        return new Queen(Color);
    }
}