namespace TeleporterChessTests;

public class BoardModelTests
{
    [Fact]
    public void BoardDataIsInitialized()
    {
        TeleporterChess.model.Board board = new();
        var data = board.Data;

        Assert.Equal<uint>(8, data.columnCount);
        Assert.Equal<uint>(8, data.rowCount);
        Assert.Empty(data.squares);
    }
}
