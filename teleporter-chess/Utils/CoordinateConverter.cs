using Godot;
using TeleporterChess.Model;

namespace TeleporterChess.Utils;

public struct CoordinateConverter
{
    const int GRIDMAP_OFFSET = 4;

    public static Square ConvertGridMapCoordinatesToSquare(Vector3I gridMapCoordinates)
    {
        return new Square((Column)gridMapCoordinates.X + GRIDMAP_OFFSET, (Row)gridMapCoordinates.Z + GRIDMAP_OFFSET);
    }

    public static Vector3I ConvertSquareToGridMapCoordinates(Square square)
    {
        Vector3I result = Vector3I.Zero;
        result.X = (int)square.Column - GRIDMAP_OFFSET;
        result.Z = (int)square.Row - GRIDMAP_OFFSET;
        return result;
    }
}
