using System.Drawing;

namespace ChessLibrary;

public class Board
{
    public static int SIZE = 8;

    private Piece?[,] _pieces = new Piece?[SIZE, SIZE];

    private bool isSimuated = false;

    public Board(bool isSimulated): this()
    {
        this.isSimuated = isSimulated;
    }

    public Board()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                _pieces[i, j] = null;
            }
        }

        _pieces[0, 0] = new Rook(PieceColor.Black);
        _pieces[1, 0] = new Knight(PieceColor.Black);
        _pieces[2, 0] = new Bishop(PieceColor.Black);
        _pieces[3, 0] = new Queen(PieceColor.Black);
        _pieces[4, 0] = new King(PieceColor.Black);
        _pieces[5, 0] = new Bishop(PieceColor.Black);
        _pieces[6, 0] = new Knight(PieceColor.Black);
        _pieces[7, 0] = new Rook(PieceColor.Black);

        for (int i = 0; i < SIZE; i++)
        {
            _pieces[i, 1] = new Pawn(PieceColor.Black);
        }

        _pieces[0, 7] = new Rook(PieceColor.White);
        _pieces[1, 7] = new Knight(PieceColor.White);
        _pieces[2, 7] = new Bishop(PieceColor.White);
        _pieces[3, 7] = new Queen(PieceColor.White);
        _pieces[4, 7] = new King(PieceColor.White);
        _pieces[5, 7] = new Bishop(PieceColor.White);
        _pieces[6, 7] = new Knight(PieceColor.White);
        _pieces[7, 7] = new Rook(PieceColor.White);

        for (int i = 0; i < SIZE; i++)
        {
            _pieces[i, 6] = new Pawn(PieceColor.White);
        }
    }

    // Click sur bouton 1,1, Coord = 1,1

    public Coord? GetPieceCoords(PieceColor color, Type clazz)
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                Piece? currentPiece = _pieces[i, j];

                if (currentPiece != null && currentPiece.Color == color && currentPiece.GetType() == clazz)
                {
                    return new Coord(i, j);
                }
            }
        }

        return null;
    }

    private List<Coord> GetAllPieceCoords(PieceColor color, Type clazz)
    {
        List<Coord> coords = new List<Coord>();

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                Piece? currentPiece = _pieces[i, j];

                if (currentPiece != null && currentPiece.Color == color && currentPiece.GetType() == clazz)
                {
                    coords.Add(new Coord(i, j));
                }
            }
        }

        return coords;
    }

    public Piece? GetPiece(Coord coord)
    {
        if (coord.X >= 0 && coord.X < SIZE && coord.Y >= 0 && coord.Y < SIZE)
        {
            return _pieces[coord.X, coord.Y];
        }

        return null;
    }

    public Coord[] GetAvailableMoves(Coord coord)
    {
        return GetAvailableMoves(coord, false);
    }

    public Coord[] GetAttackMoves(Coord coord)
    {
        if (coord.X >= 0 && coord.X < SIZE && coord.Y >= 0 && coord.Y < SIZE)
        {
            var piece = _pieces[coord.X, coord.Y];
            if (piece != null)
            {
                var coords = piece.GetAttackMoves(this, coord);
                var validMoves = new List<Coord>();

                // Valide que chaque move est une coordonnée réelle
                foreach (var possibleCoord in coords)
                {
                    if (possibleCoord.X >= 0 && possibleCoord.X < SIZE && possibleCoord.Y >= 0 && possibleCoord.Y < SIZE)
                    {
                        // Si une piece à cet endroit est de la même couleur, on ignore l'ajout de la position
                        if (_pieces[possibleCoord.X, possibleCoord.Y]?.Color == piece.Color)
                        {
                            continue;
                        }

                        validMoves.Add(possibleCoord);
                    }
                }

                return validMoves.ToArray();
            }
        }

        return [];
    }

    public Coord[] GetAvailableMoves(Coord coord, bool ignoreThreatheningMoves)
    {
        if (coord.X >= 0 && coord.X < SIZE && coord.Y >= 0 && coord.Y < SIZE)
        {
            var piece = _pieces[coord.X, coord.Y];
            if (piece != null)
            {
                Console.WriteLine("Getting available moves for {0} situated at {1}", piece, coord);
                var coords = piece.GetAvailableMoves(this, coord);
                var validMoves = new List<Coord>();

                // Valide que chaque move est une coordonnée réelle
                foreach (var possibleCoord in coords)
                {
                    if (possibleCoord.X >= 0 && possibleCoord.X < SIZE && possibleCoord.Y >= 0 && possibleCoord.Y < SIZE)
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

                //Castle
                if (piece is King king)
                {
                    var color = piece.Color;
                    var threateningMoves = ignoreThreatheningMoves ? new HashSet<Coord>() : GetThreateningMoves(color == PieceColor.White ? PieceColor.Black : PieceColor.White);
                    var kingCoord = GetPieceCoords(color, typeof(King));
                    if (king.HasMoved == false)
                    {
                        var rookPositions = GetAllPieceCoords(piece.Color, typeof(Rook));
                        foreach (var rookPosition in rookPositions)
                        {
                            var rookPiece = GetPiece(rookPosition);
                            if (rookPiece.HasMoved == false && !IsKingPositionChecked(color,kingCoord))
                            {
                                if(rookPosition.X == 7 && _pieces[rookPosition.X-1,rookPosition.Y] == null && _pieces[rookPosition.X - 2, rookPosition.Y] == null && !IsKingPositionChecked(color, new Coord(kingCoord.X + 1,kingCoord.Y)) && !IsKingPositionChecked(color, new Coord(kingCoord.X + 2, kingCoord.Y)))
                                {
                                    validMoves.Add(new Coord(rookPosition.X - 1,rookPosition.Y));
                                }
                                if (rookPosition.X == 0 && _pieces[rookPosition.X + 1, rookPosition.Y] == null && _pieces[rookPosition.X + 2, rookPosition.Y] == null && !IsKingPositionChecked(color, new Coord(kingCoord.X - 1, kingCoord.Y)) && !IsKingPositionChecked(color, new Coord(kingCoord.X - 2, kingCoord.Y)))
                                {
                                    validMoves.Add(new Coord(rookPosition.X + 2, rookPosition.Y));
                                }

                            }
                        }
                    }

                    // On enlève tout les mouvement ou le roi serait mis en échec
                    validMoves.RemoveAll(x => threateningMoves.Contains(x));
                }
                

                //TODO: En passant


                if(!ignoreThreatheningMoves && this.IsKingChecked(piece.Color))
                {
                    var solveCheckmateMoves = new HashSet<Coord>();

                    foreach (Coord validMove in validMoves)
                    {
                        if(this.SolvesCheck(piece.Color, coord, validMove))
                        {
                            solveCheckmateMoves.Add(validMove);
                        }
                    }
                    return solveCheckmateMoves.ToArray();
                }

                return validMoves.ToArray();
            }
        }

        return [];
    }

    public bool MovePiece(Coord from, Coord to)
    {
        var currentPiece = GetPiece(from);
        var possibleMoves = GetAvailableMoves(from);

        // Vérifier si "to" est dans la liste des moves possible, sinon, on fait rien
        if (possibleMoves.Contains(to))
        {
            var destinationPiece = GetPiece(to);

            // Déplacement sur une case vide

            if (destinationPiece == null)
            {
                // Pour le castle
                if (_pieces[from.X, from.Y] is King && from.X - to.X == 2 || _pieces[from.X, from.Y] is King && from.X - to.X == -2)
                { 
                    currentPiece.HasMoved = true;
                    if (to.X > 4)
                    {
                        _pieces[to.X, to.Y] = currentPiece;
                        _pieces[to.X - 1, to.Y] = new Rook(currentPiece.Color);
                        _pieces[to.X + 1, to.Y] = null;
                    }
                    if (to.X < 4)
                    {
                        _pieces[to.X, to.Y] = currentPiece;
                        _pieces[to.X + 1, to.Y] = new Rook(currentPiece.Color);
                        _pieces[to.X - 2, to.Y] = null;
                    }
                }
                _pieces[to.X, to.Y] = _pieces[from.X, from.Y];
                _pieces[to.X, to.Y].HasMoved = true;
                _pieces[from.X, from.Y] = null;
                
            }
            
            // Déplcament sur une case ennemi
            else if (currentPiece.Color != destinationPiece.Color)
            {
                //TODO: on peut garder une liste des pieces morte au besoin
                var deadPiece = _pieces[to.X, to.Y];
                var attackingPiece = _pieces[from.X, from.Y];

                _pieces[from.X, from.Y] = null;
                _pieces[to.X, to.Y] = attackingPiece;
            }



            return true;
        }

        return false;
    }

    public bool MovePieceOverride(Coord from, Coord to)
    {
        var currentPiece = GetPiece(from);
        var destinationPiece = GetPiece(to);

        // Déplacement sur une case vide

        if (destinationPiece == null)
        {
            // Pour le castle
            if (_pieces[from.X, from.Y] is King && from.X - to.X == 2 || _pieces[from.X, from.Y] is King && from.X - to.X == -2)
            {                
                currentPiece.HasMoved = true;
                if (to.X > 4)
                {
                    _pieces[to.X, to.Y] = currentPiece;
                    _pieces[to.X - 1, to.Y] = new Rook(currentPiece.Color);
                    _pieces[to.X + 1, to.Y] = null;
                }
                if (to.X < 4)
                {
                    _pieces[to.X, to.Y] = currentPiece;
                    _pieces[to.X + 1, to.Y] = new Rook(currentPiece.Color);
                    _pieces[to.X - 2, to.Y] = null;
                }
            }
            _pieces[to.X, to.Y] = _pieces[from.X, from.Y];
            _pieces[to.X, to.Y].HasMoved = true;
            _pieces[from.X, from.Y] = null;            
        }
        
        // Déplcament sur une case ennemi
        else if (currentPiece.Color != destinationPiece.Color)
        {
            //TODO: on peut garder une liste des pieces morte au besoin
            var deadPiece = _pieces[to.X, to.Y];
            var attackingPiece = _pieces[from.X, from.Y];

            _pieces[from.X, from.Y] = null;
            _pieces[to.X, to.Y] = attackingPiece;
        }

        return true;
    }


    public HashSet<Coord> GetThreateningMoves(PieceColor color)
    {
        var threateningMoves = new HashSet<Coord>();

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                var currentPiece = _pieces[i, j];

                //On est seulement intéressé aux pièces qui match la couleur spécifiée
                if (currentPiece != null && currentPiece.Color == color)
                {
                    // On ajoute les déplacement possibles de la pièce dans la liste
                    threateningMoves.UnionWith(GetAttackMoves(new Coord(i, j)));
                }
            }
        }

        return threateningMoves;
    }

    public Board Copy()
    {
        var copy = new Board(true);

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                copy._pieces[i, j] = _pieces[i, j]?.Copy() ?? null;
            }
        }

        return copy;
    }

    public bool IsKingChecked(PieceColor color)
    {
        var kingCoords = GetPieceCoords(color, typeof(King));
        var ennemyColor = color == PieceColor.White ? PieceColor.Black : PieceColor.White;

        //Détecte le check
        var threateningMoves = GetThreateningMoves(ennemyColor);
        // On vérifie si le roi se situe sur un des décplaments ennemi possibles
        return threateningMoves.Contains(kingCoords);
    }

    private bool IsKingPositionChecked(PieceColor color, Coord kingCoords)
    {
        var ennemyColor = color == PieceColor.White ? PieceColor.Black : PieceColor.White;
       
        var threateningMoves = GetThreateningMoves(ennemyColor);
        return threateningMoves.Contains(kingCoords);
    }

    public bool IsCheckMate(PieceColor color)
    {
        var kingCoords = GetPieceCoords(color, typeof(King));

        if (!IsKingChecked(color))
        {
            return false;
        }

        var kingAvailableMoves = GetAvailableMoves(kingCoords);

        if (kingAvailableMoves.Length > 0)
        {
            return false;
        }

        //Le roi ne peut pas se déplacer, donc le seul cas ou il n'est pas échec et mat est si une piece peut bloquer
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                var currentPiece = _pieces[i, j];

                if (currentPiece != null && currentPiece.Color == color)
                {
                    var possibleMoves = GetAvailableMoves(new Coord(i, j));
                    foreach (var possibleMove in possibleMoves)
                    {
                        var simulatedBoard = Copy();
                        simulatedBoard.MovePieceOverride(new Coord(i, j), possibleMove);

                        if (!simulatedBoard.IsKingChecked(color))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public bool SolvesCheck(PieceColor color, Coord from, Coord to)
    {
        var simulatedBoard = Copy();
        simulatedBoard.MovePieceOverride(from, to);
        return !simulatedBoard.IsKingChecked(color);
    }
}