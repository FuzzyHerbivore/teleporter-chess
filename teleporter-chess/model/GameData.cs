#nullable enable

namespace TeleporterChess.Model;

public struct GameData
{
    public GameState CurrentGameState { get; private set; }
    public BoardData CurrentBoardData { get; private set; }
    public Player CurrentPlayer { get; private set; }
    public Player? Winner { get; private set; }

    public GameData(GameState gameState, BoardData boardData, Player currentPlayer)
    {
        CurrentGameState = gameState;
        CurrentBoardData = boardData;
        CurrentPlayer = currentPlayer;
    }
}
