using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class PieceControl: PictureBox
    {

        private Piece piece;

        public PieceControl(Piece piece)
        {
            this.piece = piece;
            this.BackColor = Color.Transparent;

            if(piece is Rook && piece.Color == PieceColor.Black)
            {   
               this.Image = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.rook_black.png"));
            }
        }

        public Piece Piece { get => piece; }
    }
}
