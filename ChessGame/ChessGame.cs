using ChessLibrary;

namespace ChessGame
{
    public partial class ChessGame : Form
    {
        private Board board;

        private PieceColor playerColor = PieceColor.White;
        private bool isPieceSelected = false;
        private Coord selectedPieceCoords = null;
        private HashSet<Coord> availableMoves = null;

        public ChessGame()
        {
            InitializeComponent();
            this.InitLayout();

            this.board = new Board();
            this.Render();
        }


        private void InitLayout()
        {
            //this.boardTableLayoutPanel.
        }

        private void Render()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    var piece = board.GetPiece(new Coord(i, j));

                    if (piece == null)
                    {
                        var control = this.boardTableLayoutPanel.GetControlFromPosition(i, j);
                        if (control != null)
                        {
                            this.boardTableLayoutPanel.Controls.Remove(control);
                        }
                    }
                    else
                    {

                        var pieceName = piece.Name() + " " + piece.Color.ToString();

                        var control = this.boardTableLayoutPanel.GetControlFromPosition(i, j);

                        if (control != null)
                        {
                            var existingPieceControl = control as PieceControl;
                            if (existingPieceControl.Piece.Equals(piece)) {
                                continue;
                            }
                            this.boardTableLayoutPanel.Controls.Remove(control);
                        }

                        var pieceControl = new PieceControl(piece);
                        this.boardTableLayoutPanel.Controls.Add(pieceControl, i, j);
                    }
                }
            }

            //this.Refresh();
        }

        private void boardTableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Row + e.Column) % 2 == 0)
            {
                // Pale
                e.Graphics.FillRectangle(Brushes.Beige, e.CellBounds);
            }
            else
            {
                // Foncé
                e.Graphics.FillRectangle(Brushes.Wheat, e.CellBounds);
            }

            if(this.isPieceSelected)
            {
                if(this.selectedPieceCoords.X == e.Column && this.selectedPieceCoords.Y == e.Row)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds);
                }

                if(this.availableMoves.Contains(new Coord(e.Column, e.Row)))
                {

                    e.Graphics.FillRectangle(Brushes.Green, e.CellBounds);
                }
            }
        }

        private Point? GetIndex(TableLayoutPanel tlp, Point point)
        {
            // Method adapted from: stackoverflow.com/a/15449969
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = 0, h = 0;
            int[] widths = tlp.GetColumnWidths(), heights = tlp.GetRowHeights();

            int i;
            for (i = 0; i < widths.Length && point.X > w; i++)
            {
                w += widths[i];
            }
            int col = i - 1;

            for (i = 0; i < heights.Length && point.Y + tlp.VerticalScroll.Value > h; i++)
            {
                h += heights[i];
            }
            int row = i - 1;

            return new Point(col, row);
        }

        private void boardTableLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var point = GetIndex(boardTableLayoutPanel, e.Location);
            if(!point.HasValue)
            {
                return;
            }

            var coords = new Coord(point.Value);

            if (this.isPieceSelected)
            {
                if(this.availableMoves.Contains(coords))
                {
                    this.board.MovePiece(this.selectedPieceCoords, coords);
                    this.playerColor = this.playerColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    this.ResetState();
                    this.Render();
                    return;
                }
            }

            var piece = board.GetPiece(coords);
            if (piece != null && piece.Color == this.playerColor)
            {
                var pieceControl = boardTableLayoutPanel.GetControlFromPosition(point.Value.X, point.Value.Y);

                this.selectedPieceCoords = coords;
                this.isPieceSelected = true;
                this.availableMoves = new HashSet<Coord>(this.board.GetAvailableMoves(coords));
            }
            else
            {
                this.ResetState();
            }

            this.Refresh();
        }

        private void ResetState()
        {
            this.selectedPieceCoords = null;
            this.isPieceSelected = false;
            this.availableMoves = null;
        }
    }
}
