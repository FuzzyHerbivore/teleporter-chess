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

    readonly Board board = new();

    readonly Player[] players = [new() { color = Player.Color.White }, new() { color = Player.Color.Black }];
    Player currentPlayer;
    Square? selectedSquare;

    public event Action<GameData> DataChanged;

    public Game()
    {
        Reset();
    }

    public void Reset()
    {
        currentGameState = GameState.Playing;
        currentPlayer = players[0];

        board.Reset();

        UpdateData();
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
    }

    public void SelectSquare(Square square)
    {
        selectedSquare = square;
    }

    public void DeselectAll()
    {
        selectedSquare = null;
    }

    private void UpdateData()
    {
        data = new(currentGameState, board.Data, currentPlayer);

        DataChanged?.Invoke(data);
    }
}
