#nullable enable

using Godot;
using Godot.Collections;

public partial class Board : Node3D
{
    private const float RAYCAST_DISTANCE = 10.0f;

    [ExportGroup("Physics")]
    [Export(PropertyHint.Layers3DPhysics)] private uint gridSelectionLayers = 1;
    [Export(PropertyHint.Layers3DPhysics)] private uint pieceSelectionLayers = 1;

    [ExportGroup("Dependencies")]
    [Export] private GridMap? gridMapOption;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            var raycastResultOption = RaycastResultFromScreenPosition(mouseMotion.Position, gridSelectionLayers);
            if (raycastResultOption is not Dictionary raycastResult) return;

            if (!raycastResult.TryGetValue("position", out Variant hitPositionVariant)) return;
            Vector3 hitPosition = (Vector3)hitPositionVariant;

            // TODO: Move some stuff to GridMap script

            if (gridMapOption is not GridMap gridMap) return;
            var cellPosition = gridMap.LocalToMap(hitPosition);

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

            if (gridMapOption is not GridMap gridMap) return;
            var cellPosition = gridMap.LocalToMap(hitPosition);
            GD.Print($"Gridmap cell: {cellPosition}");
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
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
