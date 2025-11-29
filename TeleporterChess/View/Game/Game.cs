#nullable enable

using Godot;
using TeleporterChess.Model;

namespace TeleporterChess.View;

public partial class Game : Node
{
    private readonly Model.Game model = new();

    private Board? boardView;

    public GameData data;

    private Controller.ResetController? resetController;

    public override void _EnterTree()
    {
        model.DataChanged += Model_DataChanged;
    }

    public override void _Ready()
    {
        boardView = GetNode<Board>("%Board");

        resetController = GetNode<Controller.ResetController>("%ResetController");

        model.Reset();
    }

    public override void _ExitTree()
    {
        model.DataChanged -= Model_DataChanged;
    }

    private void Model_DataChanged(GameData data)
    {
        // TODO: Deal with UI

        boardView?.SetPlacedPieces(data.CurrentBoardData.placedPieces);
        boardView?.SetAvailableActions(data.AvailableBoardActions);

        resetController?.SetAvailableActions(model.AvailableActions);
    }
}
