namespace ChessExample;

public abstract class Piece
{
    protected Piece(PieceColor color)
    {
    }

    public PieceColor Color { get; private set; }
    
    public bool HasMoved { get; set; }

    
    public abstract Coord[] GetAvailableMoves(Coord coord);

    public abstract Piece Copy();
}