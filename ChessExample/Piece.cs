namespace ChessExample;

public abstract class Piece
{
    protected Piece(PieceColor color)
    {
    }

    public PieceColor Color { get; private set; }
    
    public abstract Coord[] GetAvailableMoves(Coord coord);
}