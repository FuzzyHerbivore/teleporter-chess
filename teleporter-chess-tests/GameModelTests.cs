using TeleporterChess.Model;

namespace TeleporterChessTests;

public class GameModelTests
{
    [Fact]
    public void GameConstructorInitializesDefaultData()
    {
        Game game = new();
        var data = game.Data;

        Assert.Equal(GameState.Playing, data.CurrentGameState);
        Assert.Equal(Player.Color.White, data.CurrentPlayer.color);
        Assert.Empty(data.CurrentBoardData.placedPieces);
        Assert.Null(data.Winner);
    }
}
