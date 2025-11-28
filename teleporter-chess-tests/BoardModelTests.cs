namespace TeleporterChessTests;

public class BoardModelTests
{
    [Fact]
    public void BoardDataIsInitialized()
    {
        TeleporterChess.Model.Board board = new();
        var data = board.Data;

        Assert.Equal<uint>(8, data.columnCount);
        Assert.Equal<uint>(8, data.rowCount);
        Assert.Empty(data.squares);
    }

    [Fact]
    public void IsPlaceableReturnsFalseOutsideOfBoard()
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();
        uint legalColumnNumber = 0;
        uint overflowingColumnNumber = 8;
        uint legalRowNumber = 0;
        uint overflowingRowNumber = 8;

        Assert.False(board.IsPlaceable(piece, legalColumnNumber, overflowingRowNumber));
        Assert.False(board.IsPlaceable(piece, overflowingColumnNumber, legalRowNumber));
        Assert.False(board.IsPlaceable(piece, overflowingColumnNumber, overflowingRowNumber));
    }

    [Fact]
    public void IsPlaceableReturnsTrueOnBoard()
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();
        uint legalColumnNumber = 0;
        uint legalRowNumber = 4;

        Assert.True(board.IsPlaceable(piece, legalColumnNumber, legalRowNumber));
    }

    [Fact]
    public void TryPlacingFailsOutsideOfBoard()
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();
        uint legalColumnNumber = 0;
        uint overflowingColumnNumber = 8;
        uint legalRowNumber = 0;
        uint overflowingRowNumber = 8;

        Assert.False(board.TryPlacing(piece, legalColumnNumber, overflowingRowNumber));
        Assert.False(board.TryPlacing(piece, overflowingColumnNumber, legalRowNumber));
        Assert.False(board.TryPlacing(piece, overflowingColumnNumber, overflowingRowNumber));
    }

    [Fact]
    public void TryPlacingSucceedsOnBoard()
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();
        uint legalRowNumber = 0;
        uint legalColumnNumber = 0;

        Assert.True(board.TryPlacing(piece, legalColumnNumber, legalRowNumber));
    }

    // TODO: Replace next two tests with tests on Data to make GetSquare private again

    [Fact]
    public void GetSquareReturnsNullForEmtptySquare()
    {
        TeleporterChess.Model.Board board = new();
        uint emptyColumnNumber = 0;
        uint emptyRowNumber = 0;

        Assert.Null(board.GetSquare(emptyColumnNumber, emptyRowNumber));
    }

    [Fact]
    public void GetSquareReturnsPieceForOccupiedSquare()
    {
        TeleporterChess.Model.Board board = new();
        var piece = new Piece();

        uint occupiedColumnNumber = 0;
        uint occupiedRowNumber = 0;

        board.TryPlacing(piece, occupiedColumnNumber, occupiedRowNumber);

        Assert.Equal(piece, board.GetSquare(occupiedColumnNumber, occupiedRowNumber));
    }
}
