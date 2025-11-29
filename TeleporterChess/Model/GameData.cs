#nullable enable

namespace TeleporterChess.Model;

public struct GameData(GameState gameState, Player currentPlayer, BoardData boardData, BoardActions availableBoardActions)
{
    public GameState CurrentGameState { get; private set; } = gameState;
    public Player CurrentPlayer { get; private set; } = currentPlayer;
    public BoardData CurrentBoardData { get; private set; } = boardData;
    public BoardActions AvailableBoardActions { get; private set; } = availableBoardActions;
    public Player? Winner { get; private set; }
}
