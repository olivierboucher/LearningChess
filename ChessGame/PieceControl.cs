using ChessLibrary;

namespace ChessGame
{
    internal class PieceControl : PictureBox
    {

        private Piece piece;

        public PieceControl(Piece piece)
        {
            this.piece = piece;
            this.BackColor = Color.Transparent;
            this.Enabled = false;

            if (piece is Rook)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.rook_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.rook_white.png"));
            }
            else if (piece is Bishop)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.bishop_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.bishop_white.png"));
            }
            else if (piece is King)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.king_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.king_white.png"));
            }
            else if (piece is Knight)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.knight_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.knight_white.png"));
            }
            else if (piece is Pawn)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.pawn_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.pawn_white.png"));
            }
            else if (piece is Queen)
            {
                this.Image = piece.Color == PieceColor.Black ?
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.queen_black.png")) :
                     new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("ChessGame.Assets.queen_white.png"));
            }

            this.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public Piece Piece { get => piece; }
    }
}
