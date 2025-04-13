using ChessLibrary;

namespace ChessGame
{
    public partial class ChessGame : Form
    {
        private Board board;

        private PieceColor playerColor = PieceColor.White;
        private bool isPieceSelected = false;
        private bool isKingChecked = false;
        private Coord kingCoords = null;
        private Coord selectedPieceCoords = null;
        private HashSet<Coord> availableMoves = null;

        public ChessGame()
        {
            InitializeComponent();
            this.InitLayout();

            this.board = new Board();
            this.Render();
            //hello
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
                            if (existingPieceControl.Piece.Equals(piece))
                            {
                                continue;
                            }
                            this.boardTableLayoutPanel.Controls.Remove(control);
                        }

                        var size = this.boardTableLayoutPanel.Height * 0.125;

                        var pieceControl = new PieceControl(piece);
                        pieceControl.Height = (int)size;
                        pieceControl.Width = (int)size;

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

            if (this.kingCoords != null && this.isKingChecked)
            {
                if (this.kingCoords.X == e.Column && this.kingCoords.Y == e.Row)
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                }
            }


            if (this.isPieceSelected)
            {
                if (this.selectedPieceCoords.X == e.Column && this.selectedPieceCoords.Y == e.Row)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds);
                }

                if (this.availableMoves.Contains(new Coord(e.Column, e.Row)))
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
            if (!point.HasValue)
            {
                return;
            }

            var coords = new Coord(point.Value);

            HandleMove(coords);
        }

        private void HandleMove(Coord coords)
        {
            if (this.isPieceSelected)
            {
                if (this.availableMoves.Contains(coords))
                {
                    this.board.MovePiece(this.selectedPieceCoords, coords);
                    this.playerColor = OppositeColor(this.playerColor);


                    if (this.board.IsCheckMate(this.playerColor))
                    {
                        MessageBox.Show("Checkmate", $"{OppositeColor(this.playerColor)} won");
                        this.board = new Board();
                    }

                    this.ResetState();
                    this.Render();
                    return;
                }
            }

            var piece = board.GetPiece(coords);
            if (piece != null && piece.Color == this.playerColor)
            {
                var pieceControl = boardTableLayoutPanel.GetControlFromPosition(coords.X, coords.Y);

                this.selectedPieceCoords = coords;
                this.isPieceSelected = true;
                Console.WriteLine("Handling click on {0}, getting available moves...", coords);
                this.availableMoves = new HashSet<Coord>(this.board.GetAvailableMoves(coords));
            }
            else
            {
                this.ResetState();
            }

            this.Refresh();
        }

        private PieceColor OppositeColor(PieceColor color)
        {
            return color == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }


        private void ResetState()
        {
            this.selectedPieceCoords = null;
            this.isPieceSelected = false;
            this.availableMoves = null;
            this.isKingChecked = this.board.IsKingChecked(this.playerColor);
            this.kingCoords = this.board.GetPieceCoords(this.playerColor, typeof(King));
        }
    }
}
