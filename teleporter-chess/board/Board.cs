#nullable enable

using Godot;
using Godot.Collections;
using Model = TeleporterChess.Model;

namespace TeleporterChess.View;

public partial class Board : Node3D
{
    private const float RAYCAST_DISTANCE = 10.0f;

    [ExportGroup("Physics")]
    [Export(PropertyHint.Layers3DPhysics)] private uint gridSelectionLayers = 1;
    [Export(PropertyHint.Layers3DPhysics)] private uint pieceSelectionLayers = 1;

    [ExportGroup("Dependencies")]
    [Export] private GridMap? gridMap;

    private Model.BoardData? data;
    private BoardController? controller;

    public override void _Ready()
    {
        controller = GetNode<BoardController>("%Controller");
    }

    public void Init(Model.BoardData data)
    {
        this.data = data;
        controller?.Init(data);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            var raycastResult = RaycastResultFromScreenPosition(mouseMotion.Position, gridSelectionLayers);
            if (raycastResult is not Dictionary someRaycastResult) return;

            if (!someRaycastResult.TryGetValue("position", out Variant hitPositionVariant)) return;
            Vector3 hitPosition = (Vector3)hitPositionVariant;

            if (gridMap is not GridMap someGridMap) return;
            var cellPosition = someGridMap.LocalToMap(hitPosition);

            // TODO: When piece is selected, highlight hovered cells with valid/invalid color/shape
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
            var cellPosition = someGridMap.LocalToMap(hitPosition);
            GD.Print($"Gridmap cell: {cellPosition}");
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
