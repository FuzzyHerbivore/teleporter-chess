#nullable enable

using Godot;

namespace TeleporterChess.View;

public partial class Board : Node3D
{
    private Model.BoardData? data;
    private Controller.Board? controller;

    public override void _Ready()
    {
        controller = GetNode<Controller.Board>("%Controller");
    }

    public void SetData(Model.BoardData data)
    {
        this.data = data;
    }

    public void SetCallbacks(Model.GameCallbacks callbacks)
    {
        controller?.SetCallbacks(callbacks);
    }
}
