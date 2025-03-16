using System.Drawing;

namespace ChessLibrary;

public class Coord
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coord(Point point)
    {
        X = point.X;
        Y = point.Y;
    }

    private bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Coord)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}