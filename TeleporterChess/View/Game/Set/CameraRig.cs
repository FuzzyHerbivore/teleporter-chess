using Godot;

[Tool]
public partial class CameraRig : Node3D
{
    [ExportGroup("Camera Settings")]
    [Export] private float cameraHeight = 0.4f;
    [Export] private float cameraZOffset = 0.4f;

    [ExportGroup("Dependencies")]
    [Export] private Camera3D camera;

    public override void _Process(double delta)
    {
        if (camera == null) return;

        camera.Position = new Vector3(0, cameraHeight, cameraZOffset);
        camera.LookAt(Position);
    }
}
