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
        Square squareToBeCleared = new(Column.E, Row._5);
        board.TryPlacing(piece, squareToBeCleared);

        board.Reset();

        Assert.False(board.Data.placedPieces.TryGetValue(squareToBeCleared, out _));

        Piece expectedRookWhite = board.Data.placedPieces[new Square(Column.A, Row._1)];
        Piece expectedKingWhite = board.Data.placedPieces[new Square(Column.E, Row._1)];
        Piece expectedRookBlack = board.Data.placedPieces[new Square(Column.A, Row._8)];
        Piece expectedKingBlack = board.Data.placedPieces[new Square(Column.E, Row._8)];

        Assert.Equal(new Piece(Piece.Type.Rook, Player.Color.White), expectedRookWhite);
        Assert.Equal(new Piece(Piece.Type.King, Player.Color.White), expectedKingWhite);
        Assert.Equal(new Piece(Piece.Type.Rook, Player.Color.Black), expectedRookBlack);
        Assert.Equal(new Piece(Piece.Type.King, Player.Color.Black), expectedKingBlack);
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
