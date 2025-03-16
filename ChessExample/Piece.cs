namespace ChessLibrary;

public abstract class Piece: IEquatable<Piece>
{
    protected Piece(PieceColor color)
    {
        this.Color = color;
    }

    public PieceColor Color { get; private set; }
    
    public bool HasMoved { get; set; }

    
    public abstract Coord[] GetAvailableMoves(Board board, Coord coord);

    public abstract Piece Copy();

    public abstract String Name();

    public abstract bool Equals(Piece? other);
}