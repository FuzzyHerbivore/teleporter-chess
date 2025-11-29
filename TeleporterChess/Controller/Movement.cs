#nullable enable

using System;
using Godot;
using Godot.Collections;
using TeleporterChess.Model;

namespace TeleporterChess.Controller;

public partial class Movement : Node3D
{
    private const float RAYCAST_DISTANCE = 10.0f;

    [ExportGroup("Physics")]
    [Export(PropertyHint.Layers3DPhysics)] private uint gridSelectionLayers = 1;
    [Export(PropertyHint.Layers3DPhysics)] private uint pieceSelectionLayers = 1;

    [ExportGroup("Dependencies")]
    [Export] private GridMap? gridMap;

    Func<Square, bool>? SelectSquareAction;
    Action? DeselectAllAction;

    public void SetAvailableActions(BoardActions actions)
    {
        SelectSquareAction = actions.SelectSquareAction;
        DeselectAllAction = actions.DeselectAllAction;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            var raycastResult = RaycastResultFromScreenPosition(mouseMotion.Position, pieceSelectionLayers);
            if (raycastResult is not Dictionary someRaycastResult) return;

            if (!someRaycastResult.TryGetValue("position", out Variant hitPositionVariant)) return;
            Vector3 hitPosition = (Vector3)hitPositionVariant;

            if (gridMap is not GridMap someGridMap) return;
            var gridMapPosition = someGridMap.LocalToMap(hitPosition);
        }

        if (@event.IsActionPressed("select"))
        {
            if (@event is not InputEventMouseButton mouseButton) return;
            GD.Print($"Selected!");

            var raycastResultOption = RaycastResultFromScreenPosition(mouseButton.Position, gridSelectionLayers);
            if (raycastResultOption is not Dictionary raycastResult) return;
            GD.Print($"Collision position: {raycastResult}");

            if (!raycastResult.TryGetValue("position", out Variant hitPositionVariant)) return;
            Vector3 hitPosition = (Vector3)hitPositionVariant;

            if (gridMap is not GridMap someGridMap) return;
            var gridMapPosition = someGridMap.LocalToMap(hitPosition);
            GD.Print($"Gridmap cell: {gridMapPosition}");

            SelectSquareAction?.Invoke(new Square(gridMapPosition));
        }

        if (@event.IsActionPressed("deselect"))
        {
            DeselectAllAction?.Invoke();
        }
    }

    private Dictionary? RaycastResultFromScreenPosition(Vector2 screenPosition, uint collisionMask = 0b11111111111111111111111111111111)
    {
        Camera3D camera = GetViewport().GetCamera3D();
        if (!IsInstanceValid(camera)) return null;

        var raycastFrom = camera.ProjectRayOrigin(screenPosition);
        var raycastTo = raycastFrom + camera.ProjectRayNormal(screenPosition) * RAYCAST_DISTANCE;

        var raycastParams = PhysicsRayQueryParameters3D.Create(raycastFrom, raycastTo, collisionMask);
        var raycastResult = GetWorld3D().DirectSpaceState.IntersectRay(raycastParams);

        return raycastResult;
    }
}
