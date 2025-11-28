using TeleporterChess.Model;

namespace TeleporterChessTests;

public class BoardModelTests
{
    [Fact]
    public void BoardConstructorInitializesEmptyData()
    {
        TeleporterChess.Model.Board board = new();
        var data = board.Data;

        Assert.Empty(data.placedPieces);
    }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void TryPlacingSucceeds(Column column, Row row)
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();

        Square square = new(column, row);

        Assert.True(board.TryPlacing(piece, square));
    }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void GetPieceAtReturnsNullForEmtptySquare(Column emptyColumn, Row emptyRow)
    {
        TeleporterChess.Model.Board board = new();

        Square square = new(emptyColumn, emptyRow);

        Assert.Null(board.GetPieceAt(square));
    }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void GetPieceAtReturnsPieceForOccupiedSquare(Column column, Row row)
    {
        TeleporterChess.Model.Board board = new();
        Piece piece = new();
        Square square = new(column, row);

        board.TryPlacing(piece, square);

        Assert.Equal(piece, board.GetPieceAt(square));
    }
}
