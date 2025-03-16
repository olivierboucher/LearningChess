// See https://aka.ms/new-console-template for more information

using ChessLibrary;


Board board = new Board();


// Méthode click de bouton
Coord[] coords = board.GetAvailableMoves(new Coord(1, 1));

// Pour tout les coord