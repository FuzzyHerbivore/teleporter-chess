#nullable enable

using Godot;
using TeleporterChess.Model;

namespace TeleporterChess.View;

public partial class Game : Node
{
    private readonly Model.Game model = new();
    private Board? view;

    public GameData data;

    public override void _Ready()
    {
        view = GetNode<Board>("%Board");

        model.DataChanged += Model_DataChanged;

        model.Reset();
    }

    private void Model_DataChanged(GameData data)
    {
        // TODO: Deal with UI

        view?.SetData(data);
    }
}
