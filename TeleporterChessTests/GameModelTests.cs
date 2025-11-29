using TeleporterChess.Model;

namespace TeleporterChessTests;

public class GameModelTests
{
    [Fact]
    public void GameConstructorInitializesDefaultData()
    {
        Game game = new();
        GameData data = game.Data;

        Piece expectedRookWhite = data.CurrentBoardData.placedPieces[new Square(Column.A, Row._1)];
        Piece expectedKingWhite = data.CurrentBoardData.placedPieces[new Square(Column.E, Row._1)];
        Piece expectedRookBlack = data.CurrentBoardData.placedPieces[new Square(Column.A, Row._8)];
        Piece expectedKingBlack = data.CurrentBoardData.placedPieces[new Square(Column.E, Row._8)];

        Assert.Equal(GameState.Playing, data.CurrentGameState);
        Assert.Equal(Player.Color.White, data.CurrentPlayer.color);
        Assert.Null(data.Winner);

        Assert.Equal(new Piece(Piece.Type.Rook, Player.Color.White), expectedRookWhite);
        Assert.Equal(new Piece(Piece.Type.King, Player.Color.White), expectedKingWhite);
        Assert.Equal(new Piece(Piece.Type.Rook, Player.Color.Black), expectedRookBlack);
        Assert.Equal(new Piece(Piece.Type.King, Player.Color.Black), expectedKingBlack);

    }
}
