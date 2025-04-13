using ChessLibrary;

namespace TestChessLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Board board = new Board();
            //King
            board.MovePieceOverride(new Coord(4, 0), new Coord(4, 1));

            // Attacking white Pawn
            board.MovePieceOverride(new Coord(3, 6), new Coord(3, 2));


            Assert.IsTrue(board.IsKingChecked(PieceColor.Black));


            var availableMoves = board.GetAvailableMoves(new Coord(2, 1));

            // The only possible move should be attacking the white pawn threathening the king at new Coord(3, 2)
            Assert.AreEqual(1, availableMoves.Count());

            Assert.AreEqual(availableMoves[0], new Coord(3, 2));
        }
    }
}