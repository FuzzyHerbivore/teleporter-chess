using TeleporterChess.Model;

namespace TeleporterChessTests;

public class BoardModelTests
{
    [Fact]
    public void BoardConstructorInitializesEmptyData()
    {
        Board board = new();
        var data = board.Data;

        Assert.Empty(data.placedPieces);
    }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void TryPlacingSucceeds(Column column, Row row)
    {
        Board board = new();
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
        Board board = new();
        Square square = new(emptyColumn, emptyRow);

        Assert.Null(board.GetPieceAt(square));
    }

    [Fact]
    public void ResetPlacesPiecesToStartPositions()
    {
        Board board = new();
        var piece = new Piece();
        Square square = new(Column.A, Row._1);
        board.TryPlacing(piece, square);

        board.Reset();

        Assert.Empty(board.Data.placedPieces); // TODO: This needs to check for the start setup
    }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void GetPieceAtReturnsPieceForOccupiedSquare(Column column, Row row)
    {
        Board board = new();
        Piece piece = new();
        Square square = new(column, row);

        board.TryPlacing(piece, square);

        Assert.Equal(piece, board.GetPieceAt(square));
    }
}
