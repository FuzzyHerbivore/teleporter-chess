using TeleporterChess.Model;

namespace TeleporterChessTests;

struct GameSpy(Player.Color currentPlayerColor = Player.Color.Black)
{
    public bool updateWasCalled = false;
    public bool switchPlayerWasCalled = false;
    public bool getCurrentPlayerColorWasCalled = false;

    public Player.Color currentPlayerColorMock = currentPlayerColor;

    public void UpdateDataSpy()
    {
        updateWasCalled = true;
    }

    public void SwitchPlayerSpy()
    {
        switchPlayerWasCalled = true;
    }

    public Player.Color GetCurrentPlayerColorSpy()
    {
        getCurrentPlayerColorWasCalled = true;
        return currentPlayerColorMock;
    }
}

public class BoardModelTests
{
    [Fact]
    public void BoardConstructorInitializesEmptyData()
    {
        Board board = new(() => { }, () => { }, () => { return Player.Color.Black; });

        var data = board.Data;

        Assert.Empty(data.placedPieces);
    }

    // [Theory]
    // [InlineData(Piece.Type.Pawn, Column.A, Row._2, Column.A, Row._3)]
    // [InlineData(Piece.Type.Pawn, Column.E, Row._2, Column.E, Row._3)]
    // [InlineData(Piece.Type.Pawn, Column.A, Row._2, Column.H, Row._3)]
    // public void TryPlacingSucceeds(Piece.Type pieceType, Column fromColumn, Row fromRow, Column toColumn, Row toRow)
    // {
    //     GameSpy gameSpy = new(Player.Color.Black);
    //     Board board = new(gameSpy.UpdateDataSpy, gameSpy.SwitchPlayerSpy, gameSpy.GetCurrentPlayerColorSpy);

    //     var piece = new Piece(pieceType, Player.Color.Black);
    //     Square fromSquare = new(fromColumn, fromRow);
    //     Square toSquare = new(toColumn, toRow);

    //     Assert.True(board.TryPlacing(piece, fromSquare, toSquare));

    //     Assert.True(gameSpy.updateWasCalled);
    //     Assert.True(gameSpy.switchPlayerWasCalled);
    //     Assert.True(gameSpy.getCurrentPlayerColorWasCalled);
    // }

    [Theory]
    [InlineData(Column.A, Row._1)]
    [InlineData(Column.E, Row._5)]
    [InlineData(Column.H, Row._8)]
    public void GetPieceAtReturnsNullForEmtptySquare(Column emptyColumn, Row emptyRow)
    {
        Board board = new(() => { }, () => { }, () => { return Player.Color.Black; });

        Square square = new(emptyColumn, emptyRow);

        Assert.Null(board.GetPieceAt(square));
    }

    [Fact]
    public void ResetPlacesPiecesToStartPositions()
    {
        Board board = new(() => { }, () => { }, () => { return Player.Color.Black; });

        var piece = new Piece();
        Square squareToBeCleared = new(Column.E, Row._5);
        board.TryPlacing(piece, null, squareToBeCleared);

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
        Board board = new(() => { }, () => { }, () => { return Player.Color.Black; });

        Piece piece = new();
        Square square = new(column, row);

        board.TryPlacing(piece, null, square);

        Assert.Equal(piece, board.GetPieceAt(square));
    }
}
