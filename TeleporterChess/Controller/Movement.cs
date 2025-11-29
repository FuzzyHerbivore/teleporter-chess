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

    [ExportGroup("Dependencies")]
    [Export] private GridMap? gridMap;

    Func<Square, bool>? InteractWithSquare;
    Action? DeselectAll;

    public void SetAvailableActions(BoardActions actions)
    {
        InteractWithSquare = actions.InteractWithSquareAction;
        DeselectAll = actions.DeselectAllAction;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // TODO: Highlight hovered squares
        }

        if (@event.IsActionPressed("select"))
        {
            if (@event is not InputEventMouseButton mouseButton) return;

            Square? hitSquare = GetSquareFromScreenPosition(mouseButton.Position, gridSelectionLayers);
            if (hitSquare is not Square someHitSquare) return;

            bool? result = InteractWithSquare?.Invoke(someHitSquare);
        }

        if (@event.IsActionPressed("deselect"))
        {
            DeselectAll?.Invoke();
        }
    }

    private Square? GetSquareFromScreenPosition(Vector2 screenPosition, uint? collisionMask)
    {
        Vector3? hitPosition = GetWorldPositionFromScreenPosition(screenPosition, collisionMask);
        if (hitPosition is not Vector3 someHitPosition) return null;

        if (gridMap is not GridMap someGridMap) return null;
        var gridMapPosition = someGridMap.LocalToMap(ToLocal(someHitPosition));

        return new Square(gridMapPosition);
    }

    private Vector3? GetWorldPositionFromScreenPosition(Vector2 screenPosition, uint? collisionMask)
    {
        var raycastResultOption = GetRaycastResultFromScreenPosition(screenPosition, collisionMask);
        if (raycastResultOption is not Dictionary raycastResult) return null;

        if (!raycastResult.TryGetValue("position", out Variant hitPositionVariant)) return null;
        return (Vector3)hitPositionVariant;
    }

    private Dictionary? GetRaycastResultFromScreenPosition(Vector2 screenPosition, uint? collisionMask)
    {
        Camera3D camera = GetViewport().GetCamera3D();
        if (!IsInstanceValid(camera)) return null;

        var raycastFrom = camera.ProjectRayOrigin(screenPosition);
        var raycastTo = raycastFrom + camera.ProjectRayNormal(screenPosition) * RAYCAST_DISTANCE;

        var raycastParams = PhysicsRayQueryParameters3D.Create(raycastFrom, raycastTo, collisionMask ?? 0b11111111111111111111111111111111);
        var raycastResult = GetWorld3D().DirectSpaceState.IntersectRay(raycastParams);

        return raycastResult;
    }
}
