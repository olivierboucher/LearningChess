namespace ChessExample;

public class Board
{
    public static int SIZE = 8;

    private Piece?[,] _pieces = new Piece?[SIZE, SIZE];

    public Board()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                _pieces[i, j] = null;
            }
        }

        _pieces[0, 0] = new Rook(PieceColor.White);
        _pieces[1, 0] = new Knight(PieceColor.White);
        _pieces[2, 0] = new Bishop(PieceColor.White);
        _pieces[3, 0] = new Queen(PieceColor.White);
        _pieces[4, 0] = new King(PieceColor.White);
        _pieces[5, 0] = new Bishop(PieceColor.White);
        _pieces[6, 0] = new Knight(PieceColor.White);
        _pieces[7, 0] = new Rook(PieceColor.White);

        for (int i = 0; i < SIZE; i++)
        {
            _pieces[i, 1] = new Pawn(PieceColor.White);
        }

        _pieces[0, 7] = new Rook(PieceColor.Black);
        _pieces[1, 7] = new Knight(PieceColor.Black);
        _pieces[2, 7] = new Bishop(PieceColor.Black);
        _pieces[3, 7] = new Queen(PieceColor.Black);
        _pieces[4, 7] = new King(PieceColor.Black);
        _pieces[5, 7] = new Bishop(PieceColor.Black);
        _pieces[6, 7] = new Knight(PieceColor.Black);
        _pieces[7, 7] = new Rook(PieceColor.Black);

        for (int i = 0; i < SIZE; i++)
        {
            _pieces[6, i] = new Pawn(PieceColor.Black);
        }
    }

    // Click sur bouton 1,1, Coord = 1,1

    public Coord[] GetAvailableMoves(Coord coord)
    {
        if (coord.X >= 0 && coord.X < SIZE && coord.Y >= 0 && coord.Y < SIZE)
        {
            var piece = _pieces[coord.X, coord.Y];
            if (piece != null)
            {
                var coords = piece.GetAvailableMoves(coord);
                var validMoves = new List<Coord>();

                // Valide que chaque move est une coordonnée réelle
                foreach (var possibleCoord in coords)
                {
                    if (coord.X >= 0 && coord.X < SIZE && coord.Y >= 0 && coord.Y < SIZE)
                    {
                        // Si une piece à cet endroit est de la même couleur, on ignore l'ajout de la position
                        if (_pieces[possibleCoord.X, possibleCoord.Y]?.Color == piece.Color)
                        {
                            continue;
                        }
                        validMoves.Add(possibleCoord);
                    }
                }

                /**
                 * Ajout des mouvements spéciaux *
                 */
                
                // Pawn
                if (piece is Pawn)
                {
                    if (piece.Color == PieceColor.White)
                    {
                        if (_pieces[coord.X + 1, coord.Y + 1]?.Color == PieceColor.Black)
                        {
                            validMoves.Add(new Coord(coord.X + 1, coord.Y + 1));
                        }

                        if (_pieces[coord.X - 1, coord.Y + 1]?.Color == PieceColor.Black)
                        {
                            validMoves.Add(new Coord(coord.X - 1, coord.Y + 1));
                        }
                    }
                    else if (piece.Color == PieceColor.Black)
                    {
                        if (_pieces[coord.X + 1, coord.Y - 1]?.Color == PieceColor.White)
                        {
                            validMoves.Add(new Coord(coord.X + 1, coord.Y - 1));
                        }

                        if (_pieces[coord.X - 1, coord.Y - 1]?.Color == PieceColor.White)
                        {
                            validMoves.Add(new Coord(coord.X - 1, coord.Y - 1));
                        }
                    }
                }
                
                //Castle
                if (piece is Rook)
                {
                    if (piece.Color == PieceColor.White)
                    {
                        // Position du roi
                        // Position du rook
                        
                        // TODO: calcul si le roi tombe en échec
                    }
                }

                return validMoves.ToArray();
            }
        }

        return [];
    }

    public void MovePiece(Coord from, Coord to)
    {
        var possibleMoves = GetAvailableMoves(from);
        // Vérifier si "to" est dans la liste des moves possible, sinon, on fait rien
        
        
    }
}