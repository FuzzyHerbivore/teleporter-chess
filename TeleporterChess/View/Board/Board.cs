#nullable enable

using System.Collections.Generic;
using Godot;
using TeleporterChess.Model;
using TeleporterChess.Utils;

namespace TeleporterChess.View;

public partial class Board : Node3D
{
    private GridMap? placementGrid;

    private Controller.Movement? moveController;

    public override void _Ready()
    {
        placementGrid = GetNode<GridMap>("%PlacementGrid");

        moveController = GetNode<Controller.Movement>("%MovementController");
    }

    public void SetPlacedPieces(Dictionary<Square, Piece> placedPieces)
    {
        placementGrid?.Clear();

        foreach ((Square square, Piece piece) in placedPieces)
        {
            placementGrid?.SetCellItem(square.GetGridMapCoordinates(), GridMapIdMapper.MapPieceToGridMapId(piece));
        }
    }

    public void SetAvailableActions(BoardActions availableActions)
    {
        moveController?.SetAvailableActions(availableActions);
    }
}
