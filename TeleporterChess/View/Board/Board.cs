#nullable enable

using Godot;
using TeleporterChess.Model;
using TeleporterChess.Utils;

namespace TeleporterChess.View;

public partial class Board : Node3D
{
    private GameData? data;
    private Controller.Movement? moveController;
    private GridMap? placementGrid;

    public override void _Ready()
    {
        moveController = GetNode<Controller.Movement>("%MovementController");
        placementGrid = GetNode<GridMap>("%PlacementGrid");
    }

    public void SetData(GameData data)
    {
        this.data = data;

        placementGrid?.Clear();

        foreach ((Square square, Piece piece) in data.CurrentBoardData.placedPieces)
        {
            placementGrid?.SetCellItem(square.GetGridMapCoordinates(), GridMapIdMapper.MapPieceToGridMapId(piece));
        }
    }

    public void SetCallbacks(GameCallbacks callbacks)
    {
        moveController?.SetCallbacks(callbacks);
    }
}
