#nullable enable

namespace TeleporterChess.Model;

public struct GameData(GameState gameState, BoardData boardData, Player currentPlayer)
{
    public GameState CurrentGameState { get; private set; } = gameState;
    public Player CurrentPlayer { get; private set; } = currentPlayer;
    public BoardData CurrentBoardData { get; private set; } = boardData;
    public Player? Winner { get; private set; }
}
