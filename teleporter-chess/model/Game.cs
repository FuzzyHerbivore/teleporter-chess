using System;
using System.Collections.Generic;

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

    readonly Board board = new();

    readonly Player[] players = [new() { color = Player.Color.White }, new() { color = Player.Color.Black }];
    Player currentPlayer;

    public event Action<GameData> DataChanged;

    public void Reset()
    {
        currentGameState = GameState.Playing;
        currentPlayer = players[0];

        board.Reset();

        UpdateData();
    }

    private void UpdateData()
    {
        data = new(currentGameState, board.Data, currentPlayer);

        DataChanged.Invoke(data);
    }
}
