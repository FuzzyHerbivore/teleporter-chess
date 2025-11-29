using System;

namespace TeleporterChess.Model;

public enum GameState
{
    Playing,
    GameOver,
}

public class Game
{
    GameState currentGameState;

    GameData data;
    public GameData Data => data;

    GameActions availableActions;
    public GameActions AvailableActions => availableActions;

    readonly Board board;

    readonly Player[] players = [new() { color = Player.Color.White }, new() { color = Player.Color.Black }];
    Player currentPlayer;

    public event Action<GameData> DataChanged;

    public Game()
    {
        board = new(UpdateData, SwitchCurrentPlayer, GetCurrentPlayerColor);

        availableActions = new(Reset, SwitchCurrentPlayer);

        Reset();
    }

    public void Reset()
    {
        currentGameState = GameState.Playing;
        currentPlayer = players[0];

        board.Reset();

        UpdateData();
    }

    public Player.Color GetCurrentPlayerColor()
    {
        return currentPlayer.color;
    }

    public void SwitchCurrentPlayer()
    {
        if (currentPlayer == players[0])
        {
            currentPlayer = players[1];
        }
        else
        {
            currentPlayer = players[0];
        }

        UpdateData();
    }

    private void UpdateData()
    {
        data = new(currentGameState, currentPlayer, board.Data, board.AvailableActions);

        DataChanged?.Invoke(data);
    }
}
